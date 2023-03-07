import { Post } from "./Post";


export interface User
{
    userId : string,
    email : string,
    password : string,
    salt : number,
    full_Name : string,
    profile_Picture : any,
    dateOfBirth : any,
    description : string,
    posts : any,
    comments : any
}