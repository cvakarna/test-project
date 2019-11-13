import { Injectable } from "@angular/core";
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from "@angular/router";
import { AuthenticationService } from "../auth/authentication.service";

@Injectable({
  providedIn: "root"
})
export class AuthgaurdService implements CanActivate {
  constructor(
    private authService: AuthenticationService,
    public router: Router
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!this.authService.isUserLoggedIn) {
      this.router.navigate(["login"], {
        queryParams: { returnUrl: state.url }
      });
      return false;
    }
    return true;
  }
}
