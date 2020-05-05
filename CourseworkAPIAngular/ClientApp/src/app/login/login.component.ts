import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../Models/login.model';
import { ApiService } from '../core/api.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model = new LoginModel();
  isError: boolean;
  constructor(
    private apiService: ApiService,
    private spinner: NgxSpinnerService,
    private notifier: NotifierService,
    private route: Router,
  ) {}

  ngOnInit() {
    this.isError = false;
  }

  onSubmit() {
    if (this.model.email === null) {
      this.notifier.notify('error', 'Please, enter email');
      this.isError = true;
    } else if (!this.validateEmail(this.model.email)) {
      this.notifier.notify('error', 'Email is not correct format!');
      this.isError = true;
    }
    if (this.model.password === null) {
      this.notifier.notify('error', 'Please, enter password');
      this.isError = true;
    }
    if (this.isError === false) {

      this.apiService.SignIn(this.model).subscribe(
      data => {
        if (data.status === 200) {

          console.log(data);
          window.localStorage.setItem('token', data.token );

          const jwtToken = data.token.split('.')[1];
          const decodedJwtJsonToken = window.atob(jwtToken);
          const decodedJwtToken = JSON.parse(decodedJwtJsonToken);

          if(decodedJwtToken.roles === 'User'){
            this.route.navigate(['/']);
          } else if (decodedJwtToken.roles === 'Admin') {
              this.route.navigate(['/admin-panel']);
          }

        } else {
          for (let i = 0; i < data.errors.length; i++) {
            this.notifier.notify('error', data.errors[i]);
          }
        }
      });

    } else {
      this.isError = false;
    }
  }

  validateEmail(email: string) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }
}
