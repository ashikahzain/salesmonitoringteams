import { Role } from "./role";

export class User{
    UserId:number;
    UserName:string;
    Password:string;
    RoleId:number;
    Role:Role;
    isActive:boolean;
}