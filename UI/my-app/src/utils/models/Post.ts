import { User } from "./User";

export interface Post
{
    PostId: string;
    Content: string | null;
    Image: number[] | null;
    CreatedAt: Date;
    UserId: string;
    User: User;
    Comments: Comment[] | null;
    
}