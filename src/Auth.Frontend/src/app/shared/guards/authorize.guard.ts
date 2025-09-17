import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from "@angular/router";
import { UserAuthService } from "../services/user-auth.service";

@Injectable({
  providedIn: 'root',
})
export class AuthorizeGuard implements CanActivate {

  constructor(private userAuthService: UserAuthService, private router: Router){}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
    if(this.userAuthService.isAuthenticated()){
      return true;
    }

    return this.router.navigate(['login'], { });
  }
  
}
