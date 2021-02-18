import { Guid } from "guid-typescript";
import { Office } from "./office";


export class Process{
    id: Guid;
    number: string;
    casueValue: number;
    idOffice: Guid;
    office: Office;
    complainingName: string;
    active: boolean;
    approved: boolean;
}