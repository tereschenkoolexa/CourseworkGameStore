import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ProductItem } from '../../Models/product-item.model';
import { ApiResult } from 'src/app/Models/result.model';
import { ProductManagerService } from '../../Services/product-manager.service';
import { ProductAdd } from '../../Models/product-add.model';
import { ApiService } from 'src/app/core/api.service';
import { Router } from '@angular/router';
import { LanguageItem } from '../../Models/language-item.model';
import { CategoriesItem } from '../../Models/categories-item.model';
import { SysReqAdd } from '../../Models/sysreq-add.model';

@Component({
  selector: 'app-product-manager',
  templateUrl: './product-manager.component.html',
  styleUrls: ['./product-manager.component.css']
})
export class ProductManagerComponent implements OnInit {

  listOfDataLang: LanguageItem[] = [];
  listOfDataCateg: CategoriesItem[] = [];

  selectedCategies: number[] = [];
  selectedLanguages: number[] = [];

  imageBlob: File;



  modelSysReq = new SysReqAdd;
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
    this.spiner.show();
    this.productService.getAllLanguages().subscribe(
      (AllLanguages: LanguageItem[]) => {
      this.listOfDataLang = AllLanguages;
      });
    this.productService.getAllCategories().subscribe(
      (AllCategories: CategoriesItem[]) => {
      this.listOfDataCateg = AllCategories;
      this.spiner.hide();
      });
  }

  setCategory(id: number) {
    for(let i = 0; i < this.listOfDataCateg.length; i++){
      if(this.listOfDataCateg[i].idCategory === id){
        if(this.listOfDataCateg[i].isChecked === true) {
          this.listOfDataCateg[i].isChecked = false;
        }
        else {
          this.listOfDataCateg[i].isChecked = true;
        }
        console.log(this.listOfDataCateg[i]);
        break;
      }
    }
  }

  setLanguage(id: number) {
    for(let i = 0; i < this.listOfDataLang.length; i++){
      if(this.listOfDataLang[i].idLanguage === id){
        if(this.listOfDataLang[i].isChecked === true) {
          this.listOfDataLang[i].isChecked = false;
        }
        else {
          this.listOfDataLang[i].isChecked = true;
        }
        console.log(this.listOfDataLang[i]);
        break;
      }
    }
  }

  setImage(files: FileList) {
    this.imageBlob = files.item(0);
  }

  onSubmit() {

    for(let i = 0; i < this.listOfDataCateg.length; i++){
      if(this.listOfDataCateg[i].isChecked === true){
        this.selectedCategies.push(this.listOfDataCateg[i].idCategory);
      }
    }
    console.log(this.selectedCategies);

    for(let i = 0; i < this.listOfDataLang.length; i++){
      if(this.listOfDataLang[i].isChecked === true){
        this.selectedLanguages.push(this.listOfDataLang[i].idLanguage);
      }
    }
    console.log(this.selectedLanguages);


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
    if (this.imageBlob === null) {
      this.notifier.notify('error', 'Please, enter image!');
      this.isError = true;
    }
    if (this.model.price === null) {
      this.notifier.notify('error', 'Please, enter price!');
      this.isError = true;
    }
    if (this.modelSysReq.os === null) {
      this.notifier.notify('error', 'Please, enter OS!');
      this.isError = true;
    }
    if (this.modelSysReq.processor === null) {
      this.notifier.notify('error', 'Please, enter Processor!');
      this.isError = true;
    }
    if (this.modelSysReq.graphics === null) {
      this.notifier.notify('error', 'Please, enter Graphics!');
      this.isError = true;
    }
    if (this.modelSysReq.memory === null) {
      this.notifier.notify('error', 'Please, enter Memory!');
      this.isError = true;
    }
    if (this.modelSysReq.storege === null) {
      this.notifier.notify('error', 'Please, enter Storege!');
      this.isError = true;
    }
    if (this.isError === false) {
      this.model.sysreqProduct = this.modelSysReq;
      this.model.listidCateg = this.selectedCategies;
      this.model.listidLang = this.selectedLanguages;

      console.log(this.model);
      const date = new Date().valueOf();
        let text = '';
        const possibleText = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        for (let i = 0; i < 5; i++) {
          text += possibleText.charAt(Math.floor(Math.random() * possibleText.length));
        }
        // Replace extension according to your media type

        const imageName = date + '.' + text + '.jpg';
      const imageFile = new File([this.imageBlob], imageName, { type: 'image/jpeg' });
      this.productService.ProductAdd(this.model).subscribe(
        data => {
          console.log(data);
          if (data.status === 200) {
            this.notifier.notify('success', 'Add product!');
            this.productService.uploadPhoto(imageFile).subscribe(data=>{
              console.log(data);
            }, error =>{
              console.log(error);
            });
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

    this.selectedCategies = [];
    this.selectedLanguages = [];

  }
}
