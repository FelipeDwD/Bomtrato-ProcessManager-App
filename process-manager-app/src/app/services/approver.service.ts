import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from  "rxjs";
import { BaseService } from "./base.service";
import { Approver } from "../models/approver";


@Injectable({
    providedIn: "root"
})
export class ApproverService extends BaseService{

    constructor(private http: HttpClient){
        super('approver');
    }

    public auth(user: Approver): Observable<Approver>{
        
        this.body = {
            email: user.email,
            password: user.password
        }

        this.baseURL = `${this.urlApi}/${this.domain}/auth`;

        return this.http.post<Approver>(this.baseURL, this.body, {headers: this.headers});
    }

}