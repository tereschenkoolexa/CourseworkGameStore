import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiResult } from 'src/app/Models/result.model';
import { Observable } from 'rxjs';
import { LibraryAdd } from '../Models/library-add.modul';
import { LibraryItem } from '../Models/library-item.modul';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {

  constructor(private http: HttpClient) { this.headers = new HttpHeaders(); }
  baseUrl = '/api/Product';
  headers: HttpHeaders;

  ProductBuy(libraryItem: LibraryAdd): Observable<ApiResult> {
    return this.http.post<ApiResult>(this.baseUrl + `/buyProduct`, libraryItem);
  }

  getLibrary(id: string) {
    return this.http.get(this.baseUrl + '/getLibrary' + '/' + id);
  }

}
