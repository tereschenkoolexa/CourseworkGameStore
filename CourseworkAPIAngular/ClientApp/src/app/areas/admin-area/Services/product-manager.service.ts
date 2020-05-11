import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResult } from 'src/app/Models/result.model';
import { ProductAdd } from '../Models/product-add.model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductManagerService {

  constructor(private http: HttpClient) { }
  baseUrl = '/api/Product';

  ProductAdd(model: ProductAdd): Observable<ApiResult> {
    return this.http.post<ApiResult>(this.baseUrl + '/addProduct', model);
  }

  getAllProducts() {
    return this.http.get(this.baseUrl);
  }

  RemoveProduct(id: number){
    return this.http.post(this.baseUrl + '/RemoveProduct' + '/' + id, id)

  }
}
