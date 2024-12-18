import { Component, HostBinding } from "@angular/core";
import { SharedModule } from '../shared/shared.module';

@Component({
  selector: "app-routes",
  templateUrl: "routes.component.html",
  imports: [ SharedModule],
  standalone: true
})
export class RoutesComponent {
  @HostBinding("class.mx-auto")
  marginAuto = true;

  get smallScreen() {
    return window.innerWidth < 992;
  }
}
