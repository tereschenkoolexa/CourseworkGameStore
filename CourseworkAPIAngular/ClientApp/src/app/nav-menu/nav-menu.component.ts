import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../core/api.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedIn: boolean;
  isAdmin: boolean;

  constructor(private apiService: ApiService,
    private router: Router) {

      this.isLoggedIn = this.apiService.isLoggedin();
      this.isAdmin = this.apiService.isAdmin();

      this.apiService.loginStatus.subscribe((status) => {
        this.isLoggedIn = status;
        this.isAdmin = this.apiService.isAdmin();
      });

    }

  LogOut(){
      this.apiService.LogOut();
      this.router.navigate(['/']);
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
