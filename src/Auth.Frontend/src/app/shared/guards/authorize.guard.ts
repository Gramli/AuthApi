import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from "@angular/router";
import { UserService } from "../services/user.service";

@Injectable({
  providedIn: 'root',
})
export class AuthorizeGuard implements CanActivate {

  constructor(private userService: UserService, private router: Router){}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
    if(this.userService.isAuthenticated()){
      return true;
    }

    return this.router.navigate(['login'], { });
  }
  
}
