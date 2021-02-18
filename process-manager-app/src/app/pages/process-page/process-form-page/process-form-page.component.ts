import { asLiteral } from '@angular/compiler/src/render3/view/util';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Office } from 'src/app/models/office';
import { Process } from 'src/app/models/process';
import { ProcessInvalid } from 'src/app/models/process-invalid';
import { OfficeService } from 'src/app/services/office.service';
import { ProcessService } from 'src/app/services/process.service';

@Component({
  selector: 'app-process-form-page',
  templateUrl: './process-form-page.component.html',
  styleUrls: ['./process-form-page.component.css']
})
export class ProcessFormPageComponent implements OnInit {

  public process;
  public processInvalid;
  public offices: any[];
  public officesEdit: any[];
  public active: boolean;
  public approved: boolean;
  public notFind: boolean;
  public officeName: string;

  public casueValueInput: number;

  public activeSpinner: boolean;

  public messageApiError: string;
  public messageApiSucess: string;
  public messageEdit: string;
  public messageOffice: string

  public isEdit: boolean;
  public inputProcessNumber: boolean;

  public textButtonSave: string;


  

  constructor(private router: Router,
              private officeService: OfficeService,
              private processService: ProcessService){ 

  }

  ngOnInit(): void {
    var processSession = sessionStorage.getItem("process-session");           

    this.loadOffices();
    
    if(processSession){      
      this.messageEdit = "Número do processo não pode ser alterado";
      this.textButtonSave = "Editar";
      this.inputProcessNumber = false;
      this.process = JSON.parse(processSession);      
      this.active = this.process.active;
      this.approved = this.process.approved;
      this.isEdit = true;      
    }else{            
      this.messageEdit = "";
      this.textButtonSave = "Cadastrar";
      this.inputProcessNumber = true;
      this.process = new Process();
      this.isEdit = false;
      this.active = true;
      this.approved = true;
    }

    

    this.processInvalid = new ProcessInvalid();                 
}

addOffice():void{
  this.activeSpinner = true;
  this.cleanInputOffice();
  var office = new Office();
  office.name = this.officeName;
  this.officeName = null;

  this.officeService.add(office)
    .subscribe(
      data => {
        this.cancelNewOffice();
        alert(`${office.name} cadastrado com sucesso, retorne a lista para selecionar.`) ;
        this.loadOffices();
      },
      err => {
        alert(err.error);        
      }
    )
    this.activeSpinner = false;
}

save():void{
  this.activeSpinner = true;
  let isValid = this.validate() ? true : false;
  
  if(isValid){
    var process = this.getProcess();

    if(this.isEdit){
      this.update(process)
    }else{
      this.new(process);
    }

  }
  this.activeSpinner = false;
}

delete(id: Guid):void{
    var confirm = window.confirm("Deseja mesmo apagar esse processo?");

    if(confirm){
      this.processService.delete(id)
        .subscribe(
          data => {
            alert('Processo excluído com sucesso');
            this.back()
          }
        )

    }
}

loadOffices(): void{
  this.officeService.get()
    .subscribe(
      items => {
        this.offices = items;          
      },
      err => {
        console.log(err.error);          
      }
    )
}

  cleanInputOffice():void{
    var input = <HTMLInputElement> document.getElementById("newOffice");
    input.value = '';
    this.notFind = false;
  }

  newOffice():void{
    this.notFind = true;    
    var input = <HTMLInputElement> document.getElementById("newOffice");
    input.value = '';
  }

  cancelNewOffice():void{
    this.notFind = false;
  } 

  getProcess(): Process{
    var active = <HTMLInputElement> document.getElementById("active");
    var isActive = active.checked;

    var approved = <HTMLInputElement> document.getElementById("approved");
    var isApproved = approved.checked;

    var office = <HTMLInputElement> document.getElementById("office");
    var officeValue = office.value;

    this.process.active = isActive;
    this.process.approved = isApproved;
    this.process.idOffice = officeValue;   
    this.process.casueValue = this.process.casueValue;
    

    return this.process;
    
  }  

  back():void{
    this.router.navigate(['/process-menu-page']);
  }  

  update(process: Process):void{
    this.processService.update(process)
      .subscribe(
        item => {
          alert('Processo alterado com sucesso');
          this.back();
        },
        err => {
          console.log(err.error);
        }
      )
  }

  new(process: Process):void{
       
      this.processService.add(process)
        .subscribe(
          data =>{
            this.messageApiSucess = `Processo ${this.process.number} cadastrado com sucesso.`;
            this.redirect();
          },
          err => {
            this.messageApiError = err.error;
          }
      )        
}
  
  redirect():void{
    var answer = window.confirm(`${this.messageApiSucess} \n Deseja cadastrar mais processos?`);
            
    if(answer){
      location.reload();
    }else{
      this.back();
    }

  }
  
  
  validate(): boolean{
    var number = <HTMLInputElement> document.getElementById("processNumber");
    var numberValue = number.value;

    var casue = <HTMLInputElement> document.getElementById("casueValue");
    var casueValue = casue.value;

    var complainingName = <HTMLInputElement> document.getElementById("complainingName");
    var complainingNameValue = complainingName.value;

     if(numberValue.length < 12 || numberValue.length == 0){
      this.processInvalid.numberMessage = "* Atenção para preenchimento do campo"; 
      return false;
     }
      
     if(this.process.casueValue < 30000.00 || casueValue.length == 0){
      this.processInvalid.casueValueMessage = "* Atenção para preenchimento do campo"; 
      return false;
    }      

    if(complainingNameValue.length == 0){
      this.processInvalid.complainingNameMessage = "* Atenção para preenchimento do campo";
      return false;
    }      
    
    return true;

  }
  
}
