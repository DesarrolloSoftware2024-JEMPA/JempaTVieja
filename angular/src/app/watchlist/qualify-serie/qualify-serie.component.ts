import { Component } from '@angular/core';
import { CalificationDto } from '@proxy/series';
import { SerieService } from '@proxy/series';


@Component({
  selector: 'app-qualify-serie',
  standalone: true,
  imports: [],
  templateUrl: './qualify-serie.component.html',
  styleUrl: './qualify-serie.component.scss'
})
export class QualifySerieComponent {

  valor:number;
  comentario:string;

  idSerie: number;
  

  constructor(private serieService:SerieService){

  }

}
