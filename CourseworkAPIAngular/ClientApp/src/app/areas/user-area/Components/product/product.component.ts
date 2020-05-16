import { Component, OnInit } from '@angular/core';
import { LibraryService } from '../../Services/library.service';
import { ProductManagerService } from 'src/app/areas/admin-area/Services/product-manager.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from 'src/app/areas/admin-area/Models/product-item.model';
import { ProductStoreItem } from 'src/app/areas/admin-area/Models/product-store-item.model';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  private routeSubscription: Subscription;
  private querySubscription: Subscription;
  Product: ProductStoreItem;

  constructor(
  private libraryService: LibraryService,
  private productService: ProductManagerService,
  private spinner: NgxSpinnerService,
  private notifier: NotifierService,
  private activatedRoute: ActivatedRoute,
  private route: ActivatedRoute) { }

   id: number;
  ngOnInit() {
    this.activatedRoute.params.subscribe((params: Params) => {
       this.id = params['id'];
      console.log(this.id);
    });
    console.log(this.id);
    this.productService.getProductStore(this.id).subscribe(
      (ProductInfo: ProductStoreItem) => {
        this.Product = ProductInfo;
      });
      console.log(this.Product);
  }

}
