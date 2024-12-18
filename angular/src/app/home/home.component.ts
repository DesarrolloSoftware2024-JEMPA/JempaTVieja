import { AuthService, PagedResultDto } from '@abp/ng.core';
import { Component } from '@angular/core';
import { ConfigStateService, ApplicationConfigurationDto } from '@abp/ng.core';
import { NotificationDto, NotificationService } from '@proxy/notifications';
import { WatchlistService } from '@proxy/watchlists';
import { SerieDto, SerieService } from '@proxy/series';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {

  private notifications: PagedResultDto<NotificationDto>; 

  public imdbIds = ["tt5753856","tt5607976","tt11912196","tt19231492","tt4159076","tt0204993"];

  public series = [] as SerieDto[];


  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  constructor(private authService: AuthService, private config: ConfigStateService, private serieService: SerieService) {

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

 /* getSerieImdbId(imdbId:string){
    var serieDto: SerieDto;
    this.serieService.searchImdbId(imdbId).subscribe(res => serieDto = res);
    console.log(serieDto);
    return serieDto;
  }*/

  getSerieImdbId(imdbId: string) {
    var serieDto: SerieDto;
    this.serieService.searchImdbId(imdbId).subscribe(res => {
      serieDto = res;
      console.log(serieDto); // Aquí se imprimirá el valor correcto.
      this.series.push(serieDto);
      // Realiza aquí cualquier otra lógica que dependa de la respuesta.
    });
  }
   getSeriesList(imdbId:string[]){
    imdbId.forEach(id => {
      this.getSerieImdbId(id)})}

  /*getNotificationsFromUser(){
   this.notificationService
   .getNotifications()
   .subscribe(notifications => this.notifications = notifications);
  }*/

  getRowClass = (row) => {    
    console.log(row.read)
    return {
      'row-color1': row.read == false,
      'row-color2': row.read == true,
    };
   }

}
