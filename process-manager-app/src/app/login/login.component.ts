import { asLiteral } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";
import { Approver } from '../models/approver';
import { ApproverService } from '../services/approver.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  public user;
  public returnUrl: string;  
  public message: string;
  public activeSpinner: boolean;

  constructor(
    private router: Router,
    private activatedRouter: ActivatedRoute,
    private approverService: ApproverService) { 
    
  }

  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];    
    this.user = new Approver();
  }

  
  login(): void{
    this.activeSpinner = true;
    this.approverService.auth(this.user)
     .subscribe(
       data => {
        sessionStorage.setItem("user-auth", "1");
      
        if(this.returnUrl == undefined){
          this.router.navigate(['/process-menu-page']);
        }else{
          this.router.navigate([this.returnUrl]);
        }
        this.activeSpinner = false;

       },
       err => {
         console.log(err.error);
         this.activeSpinner = false;
         this.message = "Usuário ou senha incorreto.";
       }
     );  
  }  

}
