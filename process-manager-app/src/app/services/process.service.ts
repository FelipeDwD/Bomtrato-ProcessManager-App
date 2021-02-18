import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import * as EventEmitter from "events";
import { Guid } from "guid-typescript";
import { Observable } from "rxjs";
import { Process } from "../models/process";
import { BaseService } from "./base.service";


@Injectable({
    providedIn: "root"
})
export class ProcessService extends BaseService{

    constructor(private http: HttpClient){
        super('process');
    }

    public add(process: Process): Observable<string[]>{

        this.body = {
            number: process.number,
            casueValue: process.casueValue,
            idOffice: process.idOffice,
            complainingName: process.complainingName,
            active: process.active,
            approved: process.approved
        }

        this.baseURL = `${this.urlApi}/${this.domain}`;

        return this.http.post<string[]>(this.baseURL, this.body, {headers: this.headers});

    }

    public get(): Observable<Process[]>{

        this.baseURL = `${this.urlApi}/${this.domain}`;

        return this.http.get<Process[]>(this.baseURL);
    }

    public filter(filter: string, active: number, approved: number): Observable<Process[]>{

        this.baseURL =  `${this.urlApi}/${this.domain}/${filter}/${active}/${approved}`;

        return this.http.get<Process[]>(this.baseURL);
    }

    public update(process: Process): Observable<Process>{
        
        this.body = {
            id: process.id,
            number: process.number,
            casueValue: process.casueValue,
            idOffice: process.idOffice,
            complainingName: process.complainingName,
            active: process.active,
            approved: process.approved
        }

        this.baseURL = `${this.urlApi}/${this.domain}`

        return this.http.put<Process>(this.baseURL, this.body, {headers: this.headers});
    }

    public delete(id: Guid): Observable<boolean>{

        this.baseURL = `${this.urlApi}/${this.domain}/${id}`;

        return this.http.delete<boolean>(this.baseURL);
    }
}