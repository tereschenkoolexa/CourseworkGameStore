import { Component } from '@angular/core';
import { ProductManagerService } from 'src/app/areas/admin-area/Services/product-manager.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from 'src/app/areas/admin-area/Models/product-item.model';


@Component({
  selector: 'app-home',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent {
  listOfPosition: string[] = ['bottomLeft', 'bottomCenter', 'bottomRight', 'topLeft', 'topCenter', 'topRight'];

  constructor(
    private productService: ProductManagerService,
    private spinner: NgxSpinnerService,
    private notifier: NotifierService) { }

    listOfData: ProductItem[] = [];
    listOfSearch: ProductItem[] = [];
    searchText: string;

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
