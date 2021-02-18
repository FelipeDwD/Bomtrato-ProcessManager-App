import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ProcessFormPageComponent } from './pages/process-page/process-form-page/process-form-page.component';
import { ProcessGridPageComponent } from './pages/process-page/process-grid-page/process-grid-page.component';
import { ProcessMenuPageComponent } from './pages/process-page/process-menu-page/process-menu-page.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { GuardRoute } from './auth/guard.route';
import { NgSelectModule } from '@ng-select/ng-select';
import { ApproverService } from './services/approver.service';
import { OfficeService } from './services/office.service';
import { ProcessService } from './services/process.service';
import { CurrencyMaskInputMode, NgxCurrencyModule } from 'ngx-currency';

export const customCurrencyMaskConfig = {
  align: "left",
  allowNegative: true,
  allowZero: true,
  decimal: ",",
  precision: 2,
  prefix: "R$ ",
  suffix: "",
  thousands: ".",
  nullable: true,
  min: null,
  max: null,
  inputMode: CurrencyMaskInputMode.FINANCIAL
};


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,        
    ProcessFormPageComponent, 
    ProcessGridPageComponent, 
    ProcessMenuPageComponent,     
    LoginComponent    
  ],
  imports: [
    NgxCurrencyModule,
    FormsModule,
    NgSelectModule,
    BrowserModule,
    HttpClientModule,        
    NgxCurrencyModule.forRoot(customCurrencyMaskConfig),
    RouterModule.forRoot([      
      {path: '', component: LoginComponent},
      {path: 'login', component: LoginComponent},      
      {path: 'process-form-page', component: ProcessFormPageComponent, canActivate:[GuardRoute]},
      {path: 'process-menu-page', component: ProcessMenuPageComponent, canActivate:[GuardRoute]}                  
    ])
  ],
  providers: [ApproverService,
              OfficeService,
              ProcessService],
  bootstrap: [AppComponent]
})
export class AppModule { }
