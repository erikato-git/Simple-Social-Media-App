import { User } from "./User";

export interface Post
{
    postId: string;
    content: string | null;
    image: number[] | null;
    createdAt: Date;
    userId: string;
    user: User;
    comments: Comment[] | null;
    
}