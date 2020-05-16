import { Component } from '@angular/core';
import { ProductManagerService } from 'src/app/areas/admin-area/Services/product-manager.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from 'src/app/areas/admin-area/Models/product-item.model';
import { LibraryService } from '../../Services/library.service';
import { LibraryAdd } from '../../Models/library-add.modul';


@Component({
  selector: 'app-home',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent {
  listOfPosition: string[] = ['bottomLeft', 'bottomCenter', 'bottomRight', 'topLeft', 'topCenter', 'topRight'];

  constructor(
    private libraryService: LibraryService,
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

    buyProduct(idProduct: number){

      const token = localStorage.getItem('token');

      const jwtToken = token.split('.')[1];
      const decodedJwtJsonToken = window.atob(jwtToken);
      const decodedJwtToken = JSON.parse(decodedJwtJsonToken);

      // tslint:disable-next-line:prefer-const
      let libraryItem = new LibraryAdd;

      libraryItem.idProduct = idProduct;
      libraryItem.idUser = decodedJwtToken.id;

      this.libraryService.ProductBuy(libraryItem).subscribe();

    }
}
