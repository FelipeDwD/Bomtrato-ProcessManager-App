import { HttpClient, HttpHeaders } from "@angular/common/http";


export class BaseService{
    protected baseURL: string;
    protected urlApi: string = "http://localhost:5000/api"
    
    protected headers = new HttpHeaders().set('content-type', 'application/json');
    protected body: any; 

    public domain:string;

    constructor(domain: string){
        this.domain = domain;
    }
    

}