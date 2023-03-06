import { Post } from "./Post";
import { User } from "./User";

export interface Comment
{
    CommentId: string;
    Content: string;
    CreatedAt: Date;
    PostId: string | null;
    Post: Post | null;
    UserId: string;
    User: User | null;

}