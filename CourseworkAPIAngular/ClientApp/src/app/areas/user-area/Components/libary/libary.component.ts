import { Component, OnInit } from '@angular/core';
import { LibraryService } from '../../Services/library.service';
import { ProductManagerService } from 'src/app/areas/admin-area/Services/product-manager.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from 'src/app/areas/admin-area/Models/product-item.model';
import { LibraryItem } from '../../Models/library-item.modul';

@Component({
  selector: 'app-libary',
  templateUrl: './libary.component.html',
  styleUrls: ['./libary.component.css']
})
export class LibaryComponent implements OnInit {

  constructor(
    private libraryService: LibraryService,
    private productService: ProductManagerService,
    private spinner: NgxSpinnerService,
    private notifier: NotifierService) { }

    listOfData: ProductItem[] = [];
    listOfSearch: ProductItem[] = [];
    listIdProduct: number[] = [];

    searchText: string;

    ngOnInit() {
      this.spinner.show();

      const token = localStorage.getItem('token');

      const jwtToken = token.split('.')[1];
      const decodedJwtJsonToken = window.atob(jwtToken);
      const decodedJwtToken = JSON.parse(decodedJwtJsonToken);

      this.productService.getLibrary(decodedJwtToken.id).subscribe(
        (AllProductsId: number[]) => {
          this.listIdProduct = AllProductsId;
        }
      )

      this.productService.getAllProducts().subscribe(
      (AllProducts: ProductItem[]) => {
        for(let i = 0;i < AllProducts.length;i++)
        {
          for(let j = 0 ; j< this.listIdProduct.length; j++)
          {
            if ( AllProducts[i].id === this.listIdProduct[j] ) {
            this.listOfData.push(AllProducts[i]);
            this.listOfSearch.push(AllProducts[i]);
          }}

        }
      this.spinner.hide();
    });
    }

    Search(){
      this.listOfSearch = this.listOfData.filter(t => t.name.includes(this.searchText) ||
      t.companyName.includes(this.searchText));
    }
}
