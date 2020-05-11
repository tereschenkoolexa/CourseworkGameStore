import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from '../../Models/product-item.model';
import { ApiResult } from 'src/app/Models/result.model';
import { ProductManagerService } from '../../Services/product-manager.service';
import { ProductAdd } from '../../Models/product-add.model';
import { ApiService } from 'src/app/core/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  model = new ProductAdd;
  confirmPassword: string;
  isError: boolean;
  constructor(
    private productService: ProductManagerService,
    private notifier: NotifierService,
    private spiner: NgxSpinnerService,
    private router: Router
    ) { }

  ngOnInit() {
    this.isError = false;
  }

  onSubmit() {
    this.spiner.show();
    setTimeout(() => {
      this.spiner.hide();
    }, 4500);
    if (this.model.name === null) {
      this.notifier.notify('error', 'Please, enter full name!');
      this.isError = true;
    }
    if (this.model.companyName === null) {
      this.notifier.notify('error', 'Please, enter Company Name!');
      this.isError = true;
    }
    if (this.model.data === null) {
      this.notifier.notify('error', 'Please, enter data!');
      this.isError = true;
    }
    if (this.model.description === null) {
      this.notifier.notify('error', 'Please, enter description!');
      this.isError = true;
    }
    if (this.model.image === null) {
      this.notifier.notify('error', 'Please, enter image!');
      this.isError = true;
    }
    if (this.model.price === null) {
      this.notifier.notify('error', 'Please, enter price!');
      this.isError = true;
    }
    if (this.isError === false) {
      this.productService.ProductAdd(this.model).subscribe(
        data => {
          console.log(data);
          if (data.status === 200) {
            this.notifier.notify('success', 'Add product!');
            this.router.navigate(['/admin-panel/list-product']);
          } else {
            for (let i = 0; i < data.errors.length; i++) {
              this.notifier.notify('error', data.errors[i]);
            }
          }

        },
        errors => {
          console.log(errors);
        });
    }

  }
}
