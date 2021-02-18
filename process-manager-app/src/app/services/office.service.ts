import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Office } from "../models/office";
import { BaseService } from "./base.service";

@Injectable({
    providedIn: "root"
})
export class OfficeService extends BaseService{
    constructor(private http: HttpClient){
        super('office');
    }

    public get(): Observable<Office[]>{
        
        this.baseURL = `${this.urlApi}/${this.domain}`;

        return this.http.get<Office[]>(this.baseURL);
    }

    public add(office: Office):Observable<boolean>{

        this.body = {
            name: office.name
        }

        this.baseURL = `${this.urlApi}/${this.domain}`;

        return this.http.post<boolean>(this.baseURL, this.body, {headers: this.headers});
    }
}