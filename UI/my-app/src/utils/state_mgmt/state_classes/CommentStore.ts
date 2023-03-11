import { makeAutoObservable } from "mobx";
import { Comment } from "../../models/Comment";


export default class CommentStore
{
    selectedComment: Comment | undefined;

    constructor(){
        makeAutoObservable(this)
    }
}