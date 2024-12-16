import { AuthService, PagedResultDto } from '@abp/ng.core';
import { Component } from '@angular/core';
import { ConfigStateService, ApplicationConfigurationDto } from '@abp/ng.core';
import { NotificationDto, NotificationService } from '@proxy/notifications';
import { WatchlistService } from '@proxy/watchlists';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {

  private notifications: PagedResultDto<NotificationDto>; 


  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  constructor(private authService: AuthService, private config: ConfigStateService, private notificationService: NotificationService) {

  }


  login() {
    this.authService.navigateToLogin();
  }

  getCurrentUserName(){
    const currentUserName = this.config.getOne("currentUser").userName;
    
    return currentUserName;
  }

  getCurrentUserId(){
    const currentUserId = this.config.getOne("currentUser").id;
    console.log(currentUserId);
    return currentUserId;
  }

  getNotificationsFromUser(){
   this.notificationService
   .getNotifications()
   .subscribe(notifications => this.notifications = notifications);
  }

  getRowClass = (row) => {    
    console.log(row.read)
    return {
      'row-color1': row.read == false,
      'row-color2': row.read == true,
    };
   }

}
