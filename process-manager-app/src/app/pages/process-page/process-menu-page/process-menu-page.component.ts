import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Filter } from 'src/app/models/filter';
import { ProcessService } from 'src/app/services/process.service';

@Component({
  selector: 'app-process-menu-page',
  templateUrl: './process-menu-page.component.html',
  styleUrls: ['./process-menu-page.component.css']
})
export class ProcessMenuPageComponent implements OnInit {

  public items: any[];
  public textFilter:string;

  public showDelete: boolean;

  constructor(private router: Router,
              private processService: ProcessService){

   }

  ngOnInit(): void {
    
  }

  new():void{
    sessionStorage.removeItem("process-session");
    this.router.navigate(['/process-form-page']);
  }  

  filter():void{
    var filter = this.getFilter();      
    
    this.processService.filter(filter.textFilter, filter.active, filter.approved)
      .subscribe(
        items => {
          this.items = items;          
        },
        err => {
          console.log(err.error);
        }
      ) 
  }  

  getFilter():Filter{
    var activeCombo = <HTMLInputElement>document.getElementById("active");
    var active = Number(activeCombo.value);

    var approvedCombo = <HTMLInputElement>document.getElementById("approved");
    var approved = Number(approvedCombo.value);    

    var filter = new Filter();

    filter.active = active;
    filter.approved = approved;    
    filter.textFilter = this.textFilter != '' ? this.textFilter : null;       

    return filter;

  }
}
