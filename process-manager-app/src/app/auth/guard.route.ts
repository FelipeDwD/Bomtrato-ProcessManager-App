import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class GuardRoute implements CanActivate{

    constructor(private router: Router){

    }
    

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        
        var auth = sessionStorage.getItem("user-auth");

        if(auth == "1"){
            return true;
        }
        this.router.navigate(['/login'], { queryParams: {returnUrl: state.url}});
        return false;
    }
    

}
