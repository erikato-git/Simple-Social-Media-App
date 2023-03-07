import { createBrowserRouter, RouteObject } from "react-router-dom";
import CreateAccount from "../features/loginNRegister/CreateAccount";
import LoginOrRegister from "../features/loginNRegister/LoginOrRegister";


export const routes: RouteObject[] = [
    {
        path: '/',
        
        children: [
            // {path: '/', element: <LoginOrRegister/>},
            // {path: '/CreateAccount', element: <CreateAccount/>},
            {path: '/', element: <CreateAccount/>}
        ]
    }
]

export const router = createBrowserRouter(routes)