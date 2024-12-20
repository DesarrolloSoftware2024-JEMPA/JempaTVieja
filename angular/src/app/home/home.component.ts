import { AuthService } from '@abp/ng.core';
<<<<<<< HEAD
import { Component, OnInit} from '@angular/core';
import { ConfigStateService  } from '@abp/ng.core';
import { SerieDto, SerieService } from '@proxy/series';
import { register } from "swiper/element/bundle";


=======
import { Component } from '@angular/core';
import { ConfigStateService } from '@abp/ng.core';
import { SerieDto, SerieService } from '@proxy/series';
import { register } from 'swiper/element/bundle';
>>>>>>> e8895a6f41c75a9ac586737dfc1cd56250dfb44f

register();

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
<<<<<<< HEAD
export class HomeComponent implements OnInit {
  
  public imdbIds = ["tt5753856","tt5607976","tt11912196","tt19231492","tt4159076","tt0204993"];
=======
export class HomeComponent {
  public imdbIds = ['tt5753856', 'tt5607976', 'tt11912196', 'tt19231492', 'tt4159076', 'tt0204993'];
>>>>>>> e8895a6f41c75a9ac586737dfc1cd56250dfb44f

  public series = [] as SerieDto[];

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(
    private authService: AuthService,
    private config: ConfigStateService,
    private serieService: SerieService
  ) {}

  ngOnInit() {
    this.getSeriesList(this.imdbIds)
  }

  

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
<<<<<<< HEAD

  
  }

  
=======
}
>>>>>>> e8895a6f41c75a9ac586737dfc1cd56250dfb44f
