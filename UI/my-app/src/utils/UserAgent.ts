import axios, { AxiosResponse } from "axios";
import { User } from "./models/User";


axios.defaults.baseURL = 'http://localhost:5245/';
    
axios.interceptors.response.use(
    (response) => {
      console.log(response);
      return response;
    },
    (error) => {
      return Promise.reject(error);
    }
  );


const responseBody = <T> (response: AxiosResponse<T>) => response.data;

// Generic requests from our base-url, we can later attach the particular API-part
const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody)
}

// Get domain-specific requests and makes it type-safety
const Users = {
    getAll: () => requests.get<User[]>('/Users/get_all_users'),
    getById: (id: string) => requests.get<User>(`Users/get_user/${id}`),
    create: (user: User) => requests.post<void>(`Users/create_user`,user),
    update: (user: User) => requests.put<void>(`Users/update_user/${user.UserId}`,user),
    delete: (id: string) => requests.delete<void>(`/Users/delete_user/${id}`)
}





const userAgent = {
    Users
}

export default userAgent;
