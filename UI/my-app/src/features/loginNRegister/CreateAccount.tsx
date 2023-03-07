import userAgent from '../../utils/UserAgent';
import { LoginDTO } from '../../utils/DTOs/LoginDTO';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from "yup";
import { UserCreateDTO } from '../../utils/DTOs/UserCreateDTO';
import { ChangeEvent, useState } from 'react';



const loginSchema = Yup.object().shape({
    full_Name: Yup.string()
        .required('Name is required')
        .matches(/^[a-zA-Z ]*$/, 'Name can only contain letters and spaces')
        .min(2, 'Name must be at least 2 characters')
        .max(50, 'Name must be at most 50 characters'),
    email: Yup.string()
        .required('Email is required')
        .email('Invalid email address'),
    password: Yup.string()
        // .min(8, 'Password must be at least 8 characters')
        // .max(50, 'Password cannot be more than 50 characters')
        // .matches(
        // /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})/,
        // 'Password must contain at least one uppercase letter, one lowercase letter, one number and one special character')
});


function CreateAccount() {

    const { UserRequests } = userAgent;
    const [confirmPassword, setConfirmPassword] = useState('')


    const { register, handleSubmit, formState: { errors } } = useForm<UserCreateDTO>({
        resolver: yupResolver(loginSchema)
    })

    function handleConfirmPasswordChange(event: ChangeEvent<HTMLInputElement>) {
        const eventInput = event.target.value;
        setConfirmPassword(eventInput)
    }

    const submitForm = async (data: UserCreateDTO) => {
        if(data.password !== confirmPassword){
            alert("Password and confirmed password are not the same")
            return
        }
        await UserRequests.create(data)
        // TODO: succes message
    }


    return (
        <div className="flex flex-col items-center justify-center min-h-screen bg-gray-500">
          <div className="w-full max-w-md p-9 bg-white rounded-md shadow-md">
            <h2 className="text-giant font-big text-gray-900 mb-6 flex flex-col items-center justify-center">Login</h2>

            <form className='pt-1' onSubmit={handleSubmit(submitForm)}>
              <div className="mb-4">
                <label className="block text-gray-700 font-medium mb-2">
                  Full name
                </label>
                <input className="w-full p-2 border border-gray-400 rounded-md focus:outline-none focus:border-blue-500"
                  type="text"
                  placeholder="Enter your name"
                  {...register("full_Name")}
                />
                {errors.full_Name && <span>{errors.full_Name.message}</span>}
              </div>

              <div className="mb-4 pt-1">
                <label className="block text-gray-700 font-medium mb-2">
                  Email
                </label>
                <input className="w-full p-2 border border-gray-400 rounded-md focus:outline-none focus:border-blue-500"
                  type="text"
                  placeholder="Enter your email"
                  {...register("email")}
                />
                {errors.email && <span>{errors.email.message}</span>}
              </div>

              <div className="mb-4 pt-2">
                <label className="block text-gray-700 font-medium mb-2">
                  Password
                </label>
                <input className="w-full p-2 border border-gray-400 rounded-md focus:outline-none focus:border-blue-500"
                  type="password"
                  placeholder="Enter your password"
                  {...register("password")}
                />
                {errors.password && <span>{errors.password.message}</span>}
              </div>

              <div className="mb-4 pt-1">
                <label className="block text-gray-700 font-medium mb-2">
                  Confirm password
                </label>
                <input className="w-full p-2 border border-gray-400 rounded-md focus:outline-none focus:border-blue-500"
                  type="password"
                  placeholder="Confirm password"
                  value={confirmPassword}
                  onChange={handleConfirmPasswordChange}
                />
              </div>


              <div className='pt-2'>
                <button className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 transition duration-200" type="submit"
                >
                    Login
                </button>
              </div>
            </form>

            <hr className="my-6 border-gray-300 w-full" />
            <button
              className="bg-gray-300 text-gray-700 py-2 px-4 rounded-md hover:bg-gray-400 transition duration-200"
            >
              Create Account
            </button>
          </div>
        </div>
      );
    }
  export default CreateAccount;