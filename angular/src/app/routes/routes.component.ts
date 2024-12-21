import { Component, HostBinding } from "@angular/core";
import { SharedModule } from '../shared/shared.module';
import { Observable } from "rxjs";
import { CurrentUserDto,ConfigStateService } from "@abp/ng.core";

@Component({
  selector: "app-routes",
  templateUrl: "routes.component.html",
  imports: [ SharedModule],
  standalone: true
})
export class RoutesComponent {
  @HostBinding("class.mx-auto")
  marginAuto = true;

  
  currentUser$: Observable<CurrentUserDto> = this.configState.getOne$('currentUser');

  get smallScreen() {
    return window.innerWidth < 992;
  }

  constructor(private configState: ConfigStateService){

  }
}
