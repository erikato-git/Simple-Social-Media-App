import axios from 'axios';
import { randomUUID } from 'crypto';
import React, { useEffect, useState } from 'react'
import { User } from '../../utils/models/User';
import { Post } from '../../utils/models/Post';
import { Comment } from '../../utils/models/Comment';

function LoginNRegister() {
    const initUser = {
        UserId: "",
        Email: "init@mail.com",
        Password: "123",
        Salt: 4,
        Profile_Picture: [],
        Full_Name: "init user",
        DateOfBirgh: new Date(),
        Description: "init description"
    }
    
    const initUsers: User[] = [ initUser ];

    const [users, setUsers] = useState<User[]>(initUsers)
    
    // useEffect(() => {
    //   fetch('http://localhost:5245/get_all_users')
    //   .then(res => res.json())
    //   .then(setUsers)
    // },[])

    useEffect(() => {
        // fetch('http://localhost:5245/get_all_users')
        fetch('http://localhost:5245/login', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({
              email: 'new@mail.com',
              password: '123'
            })
          })
        .then(e => console.log(e))
      },[])
  

    return (
        <div>
            <div>LoginNRegister</div>
            {/* <tbody>
            {users.map((item) => (
                <tr>
                <th scope="row">{item.UserId}</th>
                <td>{item?.Full_Name}</td>
                <td>{item?.Email}</td>
                <td>{item?.Description}</td>
                </tr>
            ))}
        </tbody> */}
        </div>
    )
}

export default LoginNRegister