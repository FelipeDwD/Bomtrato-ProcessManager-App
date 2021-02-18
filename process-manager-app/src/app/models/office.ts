import { Guid } from "guid-typescript";
import { Process } from "./process";

export class Office{
    id: Guid;
    name: string;    
    processes: Process[];
}