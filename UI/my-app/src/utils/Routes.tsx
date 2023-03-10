import { createBrowserRouter, RouteObject } from "react-router-dom";
import CreateAccount from "../features/loginNRegister/CreateAccount";
import LoginOrRegister from "../features/loginNRegister/LoginOrRegister";
import PostWall from "../features/postWall/PostWall";
import UserCMS from "../features/userCMS/UserCMS";


export const routes: RouteObject[] = [
    {
        path: '/',
        
        children: [
            // {path: '/', element: <LoginOrRegister/>},
            // {path: '/', element: <CreateAccount/>},
            // {path: '/', element: <PostWall/>},
            {path: '/', element: <UserCMS/>},
            {path: '/LoginOrRegister', element: <LoginOrRegister/>},
            {path: '/CreateAccount', element: <CreateAccount/>},
            {path: '/Home', element: <PostWall/>},
            {path: '/Profile', element: <UserCMS/>},
        ]
    }
]

export const router = createBrowserRouter(routes)