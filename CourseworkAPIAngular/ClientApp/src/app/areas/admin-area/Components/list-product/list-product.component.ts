import { Component, OnInit } from '@angular/core';
import { ProductManagerService } from '../../Services/product-manager.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from '../../Models/product-item.model';
import { ApiResult } from 'src/app/Models/result.model';

@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrls: ['./list-product.component.css']
})
export class ListProductComponent implements OnInit {

  constructor(
    private productService: ProductManagerService,
    private spinner: NgxSpinnerService,
    private notifier: NotifierService) { }

    listOfData: ProductItem[] = [];
    listOfSearch: ProductItem[] = [];
    searchText: string;

    deleteProduct(id: number) {
      this.spinner.show();
      this.productService.RemoveProduct(id).subscribe(
        (data: ApiResult) => {
          if(data.status === 200){
            this.notifier.notify('success', 'User removed!');

            this.listOfData = this.listOfData.filter(t => t.id !== id);
            this.listOfSearch = this.listOfSearch.filter(t => t.id !== id);
            this.spinner.hide();
          } else {
            for ( let i = 0; i < data.errors; i++) {
              this.notifier.notify('error', data.errors[i]);
            }
          }
        }
      )
    }

  ngOnInit() {
    this.spinner.show();
    this.productService.getAllProducts().subscribe(
    (AllUsers: ProductItem[]) => {
    this.listOfData = AllUsers;
    this.listOfSearch = AllUsers;
    this.spinner.hide();
  });
  }

  Search(){
    this.listOfSearch = this.listOfData.filter(t => t.name.includes(this.searchText) ||
    t.companyName.includes(this.searchText));
  }

}
