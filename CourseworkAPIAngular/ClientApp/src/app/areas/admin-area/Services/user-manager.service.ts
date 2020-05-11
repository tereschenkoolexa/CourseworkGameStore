import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService {

constructor(private http: HttpClient) { }
baseUrl = '/api/UserManager';

getAllUsers() {
  return this.http.get(this.baseUrl);
}

removeUser(id: string){
  return this.http.post(this.baseUrl + '/RemoveUser' + '/' + id, id)

}
}
