import { makeAutoObservable } from "mobx/dist/internal";
import { Post } from "../../models/Post";



export default class PostStore
{
    selectedPost: Post | undefined;

    constructor(){
        makeAutoObservable(this)
    }

}