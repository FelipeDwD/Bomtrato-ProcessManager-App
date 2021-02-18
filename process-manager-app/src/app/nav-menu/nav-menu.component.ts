import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public userAuth(): boolean{
    return sessionStorage.getItem("user-auth") == "1";
  }

  public logout(): void{
    sessionStorage.setItem("user-auth", "");
    this.router.navigate(['/login']);
  }  

}
