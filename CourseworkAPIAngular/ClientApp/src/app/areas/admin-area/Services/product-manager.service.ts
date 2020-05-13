import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResult } from 'src/app/Models/result.model';
import { ProductAdd } from '../Models/product-add.model';
import { Observable } from 'rxjs';
import { SysReqAdd } from '../Models/sysreq-add.model';
import { ProductEdit } from '../Models/product-edit.model';
@Injectable({
  providedIn: 'root'
})
export class ProductManagerService {

  constructor(private http: HttpClient) { }
  baseUrl = '/api/Product';

  ProductAdd(model: ProductAdd): Observable<ApiResult> {
    return this.http.post<ApiResult>(this.baseUrl + `/addProduct`, model);
  }

  getAllProducts() {
    return this.http.get(this.baseUrl);
  }

  getAllLanguages() {
    return this.http.get(this.baseUrl + '/GetLanguages');
  }

  getAllCategories() {
    return this.http.get(this.baseUrl + '/GetCategories');
  }

  editProduct(id: string, model: ProductEdit): Observable<ApiResult> {
    return this.http.post<ApiResult>(this.baseUrl + '/editProduct/' + id, model);
  }

  RemoveProduct(id: number){
    return this.http.post(this.baseUrl + '/RemoveProduct' + '/' + id, id);

  }
}
