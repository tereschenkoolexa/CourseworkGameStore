import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StoreComponent } from './areas/user-area/Components/store/store.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { NotFoundComponent } from './NotFound/NotFound.component';
import { DashboardComponent } from './areas/admin-area/Components/dashboard/dashboard.component';
import { AdminAreaComponent } from './areas/admin-area/admin-area.component';
import { UserManagerComponent } from './areas/admin-area/Components/user-manager/user-manager.component';
import { AdminGuard } from './guards/admin.guard';
import { NotLoginGuard } from './guards/notLogin.guard'
import { UserAreaComponent } from './areas/user-area/user-area.component';
import { ListProductComponent } from './areas/admin-area/Components/list-product/list-product.component';
import { ProductManagerComponent } from './areas/admin-area/Components/product-manager/product-manager.component';
import { StatisticsComponent } from './areas/admin-area/Components/statistics/statistics.component';
import { AccountComponent } from './areas/user-area/Components/account/account.component';
import { BasketComponent } from './areas/user-area/Components/basket/basket.component';
import { FriendsComponent } from './areas/user-area/Components/friends/friends.component';
import { LibaryComponent } from './areas/user-area/Components/libary/libary.component';
import { ProductComponent } from './areas/user-area/Components/product/product.component';

const routes: Routes = [
    { path: '', component: StoreComponent, pathMatch: 'full'},
    { path: 'login', component: LoginComponent, pathMatch: 'full', canActivate: [NotLoginGuard]},
    { path: 'register', component: RegisterComponent, pathMatch: 'full', canActivate: [NotLoginGuard]},
    { path: 'admin-panel' , component: AdminAreaComponent,
    canActivate: [AdminGuard],
    children: [
        { path: '', component: DashboardComponent, pathMatch: 'full'},
        { path: 'list-product', component: ListProductComponent, pathMatch: 'full'},
        { path: 'product-manager', component: ProductManagerComponent, pathMatch: 'full'},
        { path: 'statistics', component: StatisticsComponent, pathMatch: 'full'},
        { path: 'user-manager', component: UserManagerComponent, pathMatch: 'full'}
      ]
    },
    { path: 'user-panel', component: UserAreaComponent,
    children: [
        { path: 'account', component: AccountComponent, pathMatch: 'full'},
        { path: 'basket', component: BasketComponent, pathMatch: 'full'},
        { path: 'friends', component: FriendsComponent, pathMatch: 'full'},
        { path: 'library', component: LibaryComponent, pathMatch: 'full'},
        { path: 'product/:id', component: ProductComponent, pathMatch: 'full'},
    ]},
    { path: '**', component: NotFoundComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
