import { AuthService } from '@abp/ng.core';
import { Component } from '@angular/core';
import { ConfigStateService  } from '@abp/ng.core';
import { SerieDto, SerieService } from '@proxy/series';
import { register } from "swiper/element/bundle";
import Swiper from 'swiper';

register()

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {

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
  

  getSerieImdbId(imdbId: string) {
    var serieDto: SerieDto;
    this.serieService.searchImdbId(imdbId).subscribe(res => {
      serieDto = res;
      this.series.push(serieDto);
    });
  }

  getSeriesList(imdbId:string[]){
    imdbId.forEach(id => {
      this.getSerieImdbId(id)})
  }

  async  fetchProductos(){
    await this.getSeriesList(this.imdbIds);
    console.log(this.series)
    const swiperWrapper = document.getElementById('swiper-wrapper');
    this.series.forEach(serie => {
      console.log(serie)
      const slide = document.createElement('div');
                      slide.classList.add('swiper-slide');
  
                      slide.innerHTML = 
                          `<div>
                              <h1>${serie.title}</h1>
                          </div>
                          <img src="${serie.poster} alt="jempatv poster">`
                      ;
                      swiperWrapper.appendChild(slide)
      });
  
      new Swiper (".mySwiper", {
        effect: "coverflow",
        centeredSlides: true,
        slidesPerView: "auto",
        loop: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,},
        coverflowEffect: {
            depth:500,
            modifier:1,
            slideShadows: true,
            rotate:0,
            stretch:0
        }
  
        ,
        navigation: {
            nextEl: '.swiper-button-next',
            prevEl: '.swiper-button-prev',
        }})
    }
}
