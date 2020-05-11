import { Component, OnInit } from '@angular/core';
import { UserItem } from '../../Models/user-item.model';
import { UserManagerService } from '../../Services/user-manager.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { NotifierService } from 'angular-notifier';
import { ApiResult } from 'src/app/Models/result.model';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.css']
})
export class UserManagerComponent implements OnInit {

  constructor(
    private userService: UserManagerService,
    private spinner: NgxSpinnerService,
    private notifier: NotifierService
  ) {}
  listOfData: UserItem[] = [];
  listOfSearch: UserItem[] = [];
  searchText: string;

  deleteUser(id: string){
    this.userService.removeUser(id).subscribe(
      (data: ApiResult) => {
        if(data.status === 200){
          this.notifier.notify('success', 'User removed!');

          this.listOfData = this.listOfData.filter(t => t.id !== id);
          this.listOfSearch = this.listOfSearch.filter(t => t.id !== id);
        } else {
          for (var i = 0; i < data.errors;i++){
            this.notifier.notify('error', data.errors[i]);
          }
        }
      }
    )
  }

  ngOnInit(): void {
this.spinner.show();
this.userService.getAllUsers().subscribe(
  (AllUsers: UserItem[]) => {
    this.listOfData = AllUsers;
    this.listOfSearch = AllUsers;
    this.spinner.hide();
  }
)
    }

Search(){
  this.listOfSearch = this.listOfData.filter(t => t.fullName.includes(this.searchText) ||
  t.email.includes(this.searchText) || t.phone.includes(this.searchText));
}

  }


