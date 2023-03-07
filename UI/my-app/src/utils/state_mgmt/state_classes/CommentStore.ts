import { makeAutoObservable } from "mobx/dist/api/makeObservable";
import { Comment } from "../../models/Comment";


export default class CommentStore
{
    selectedComment: Comment | undefined;

    constructor(){
        makeAutoObservable(this)
    }
}