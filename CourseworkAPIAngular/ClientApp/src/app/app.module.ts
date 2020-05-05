import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { StoreComponent } from './areas/user-area/Components/store/store.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NotFoundComponent } from './NotFound/NotFound.component';
import { AppRoutingModule } from './app-routing.module';
import { NotifierModule, NotifierOptions } from 'angular-notifier';
import { NgxSpinnerModule } from "ngx-spinner";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdminAreaComponent } from './areas/admin-area/admin-area.component';
import { UserAreaComponent } from './areas/user-area/user-area.component';
import { DashboardComponent } from './areas/admin-area/Components/dashboard/dashboard.component';
import { UserManagerComponent } from './areas/admin-area/Components/user-manager/user-manager.component';
import { ListProductComponent } from './areas/admin-area/Components/list-product/list-product.component';
import { StatisticsComponent } from './areas/admin-area/Components/statistics/statistics.component';
import { AccountComponent } from './areas/user-area/Components/account/account.component';
import { BasketComponent } from './areas/user-area/Components/basket/basket.component';
import { FriendsComponent } from './areas/user-area/Components/friends/friends.component';
import { LibaryComponent } from './areas/user-area/Components/libary/libary.component';
import { ProductComponent } from './areas/user-area/Components/product/product.component';
import { ProductManagerComponent } from './areas/admin-area/Components/product-manager/product-manager.component';

import { DemoNgZorroAntdModule } from './Ng-zorro-antd.module';

const notifierOptions: NotifierOptions = {
  position: {horizontal: { position: 'right' }, vertical: { position: 'top' }}
};

@NgModule({
  declarations: [
     AppComponent,
     NavMenuComponent,
     StoreComponent,
     LoginComponent,
     RegisterComponent,
     RegisterComponent,
     NotFoundComponent,
     AdminAreaComponent,
     UserAreaComponent,
     DashboardComponent,
     ProductManagerComponent,
     ListProductComponent,
     StatisticsComponent,
     UserManagerComponent,
     AccountComponent,
     BasketComponent,
     FriendsComponent,
     LibaryComponent,
     ProductComponent
  ],
  imports: [
     BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
     HttpClientModule,
     FormsModule,
     AppRoutingModule,
     NotifierModule.withConfig(notifierOptions),
     BrowserAnimationsModule,
     NgxSpinnerModule,
     DemoNgZorroAntdModule
  ],
 exports: [],
 providers: [],
 bootstrap: [AppComponent]
})
export class AppModule { }
