import { Guid } from "guid-typescript";

export class Approver{
    id: Guid;
    email: string;
    password: string;
    name: string;
    surname: string;
    oab: string
}