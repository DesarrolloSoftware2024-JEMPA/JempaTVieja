import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { ConfigStateService } from '@abp/ng.core';
import { SerieDto, SerieService } from '@proxy/series';
import { register } from 'swiper/element/bundle';

register();

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  public imdbIds = ['tt5753856', 'tt5607976', 'tt11912196', 'tt19231492', 'tt4159076', 'tt0204993'];

  public series = [] as SerieDto[];

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(
    private authService: AuthService,
    private config: ConfigStateService,
    private serieService: SerieService
  ) {}

  login() {
    this.authService.navigateToLogin();
  }

  getCurrentUserName() {
    const currentUserName = this.config.getOne('currentUser').userName;
    return currentUserName;
  }

  getCurrentUserId() {
    const currentUserId = this.config.getOne('currentUser').id;
    console.log(currentUserId);
    return currentUserId;
  }

  getCarouselItem(imdbId: string) {
    this.serieService.searchImdbId(imdbId).subscribe(serie => {
      const swiperWrapper = document.getElementById(serie.imdbID);
      const slide = document.createElement('div');
      slide.innerHTML = `<img src=${serie.poster} alt=${serie.title + ' poster'} ></img>`;
      swiperWrapper.appendChild(slide);
    });
  }

  getCarousel(imdbIds: string[]) {
    imdbIds.forEach(id => {
      this.getCarouselItem(id);
    });
  }
}
