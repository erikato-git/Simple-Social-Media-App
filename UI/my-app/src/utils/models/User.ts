import { Post } from "./Post";


export interface User
{
    UserId: string;
    Email: string;
    Password: string;
    Salt: number;
    Profile_Picture: any;
    Full_Name: string;
    DateOfBirgh: Date;
    Description: string;
}