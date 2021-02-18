import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Process } from 'src/app/models/process';
import { ProcessService } from 'src/app/services/process.service';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'app-process-grid-page',
  templateUrl: './process-grid-page.component.html',
  styleUrls: ['./process-grid-page.component.css']
})
export class ProcessGridPageComponent implements OnInit {
 

  public items: any[];

  private _processes: any[] = [];  

  public showTable: boolean;

  
  @Input()
  public set processes(value: any[]){
    this._processes = value;
    this.items = this._processes;

    this.showTable = this.items[0] != null ? true : false;
    
  } 

  constructor(private router: Router,
              private processService: ProcessService){

   }

  ngOnInit(): void {
     this.loadProcesses();    
}

  edit(process: Process):void{
    sessionStorage.setItem("process-session", JSON.stringify(process));
    this.router.navigate(['/process-form-page']);
  }

  editStatusApproval(process: Process):void{
    var approved = process.approved ? false : true;
    process.approved = approved;

    this.update(process);
  }

  editStatus(process: Process): void{
    var active = process.active ? false : true;
    process.active = active;
    
    this.update(process);
  }

  update(process: Process):void{
    this.processService.update(process)
      .subscribe(
        item => {
          this.editOfIndex(process, item);
        },
        err => {
          console.log(err.error);
        }
      )
  }

  editOfIndex(itemOld: Process, itemNew: Process):void{
    var indexOld = this.items.find(x => x.id == itemOld.id);
    this.items[indexOld] = itemNew;
  }  

  delete(id: Guid):void{
    this.processService.delete(id)
      .subscribe(
        ok => {
          this.deleteOfItems(id);
          alert('Processo excluído');
        },
        err =>{

      })
  }

  deleteOfItems(id: Guid):void{
    var index = this.items.findIndex(x => x.id == id);
    this.items.splice(index, 1);  
  }
  

  loadProcesses():void{
    this.processService.get()
      .subscribe(
        items => {
          this.items = items;
          this.showTable = this.items[0] != null ? true : false;
        },
        err =>{
          console.log(err.error);
        }
      )      
  }

}
