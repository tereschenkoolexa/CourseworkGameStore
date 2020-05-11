import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterModel } from '../Models/register.model';
import { Observable } from 'rxjs';
import { ApiResult } from '../Models/result.model';
import { LoginModel } from '../Models/login.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

constructor(private http: HttpClient) { }
baseUrl = '/api/Account';
loginStatus = new EventEmitter<boolean>();

SignUp(model: RegisterModel): Observable<ApiResult> {
  return this.http.post<ApiResult>(this.baseUrl + '/register', model);
}

SignIn(model: LoginModel): Observable<ApiResult> {
  return this.http.post<ApiResult>(this.baseUrl + '/login', model);
}

isAdmin(){
  const token = localStorage.getItem('token');
  if (token !== null){
    const jwtData = token.split('.')[1];
          const decodedJwtJsonData = window.atob(jwtData);
          const decodedJwtToken = JSON.parse(decodedJwtJsonData);
          if(decodedJwtToken.roles === 'User'){
            return false;
          } else if (decodedJwtToken.roles === 'Admin') {
              return true;
          }
  } else {
    return false;
  }
}

isLoggedin() {
  const token = localStorage.getItem('token');
  if (token !== null) {
    return true;
  } else {
    return false;
  }
}

LogOut(){
  localStorage.removeItem('token');
  this.loginStatus.emit(false);
}

}
