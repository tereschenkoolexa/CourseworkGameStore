import { Component, OnInit } from '@angular/core';
import { RegisterModel } from '../Models/register.model';
import { ApiService } from '../core/api.service';
import { NotifierService } from 'angular-notifier';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model = new RegisterModel;
  confirmPassword: string;
  isError: boolean;
  constructor(
    private apiService: ApiService,
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
    if (this.model.fullName === null) {
      this.notifier.notify('error', 'Please, enter full name!');
      this.isError = true;
    }
    if (this.confirmPassword !== this.model.password) {
      this.notifier.notify('error', 'Confirm password is not correct!');
      this.isError = true;
    }
    if (!this.validateEmail(this.model.email)) {
      this.notifier.notify('error', 'Email is not correct format!');
      this.isError = true;
    }
    if (this.model.age === null) {
      this.notifier.notify('error', 'Please, enter age!');
      this.isError = true;
    }
    if (this.model.address === null) {
      this.notifier.notify('error', 'Please, enter address!');
      this.isError = true;
    }
    if (this.model.phoneNumber === null) {
      this.notifier.notify('error', 'Please, enter phone number!');
      this.isError = true;
    }
    if (this.isError === false) {

      this.apiService.SignUp(this.model).subscribe(
        data => {
          console.log(data);
          if (data.status === 200) {
            this.notifier.notify('success', 'You registered!');
            this.router.navigate(['/login']);
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

  validateEmail(email: string) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }
}
