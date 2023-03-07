import userAgent from '../../utils/UserAgent';
import { LoginDTO } from '../../utils/DTOs/LoginDTO';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import * as Yup from "yup";
import { UserCreateDTO } from '../../utils/DTOs/UserCreateDTO';
import { ChangeEvent, useState } from 'react';



const createSchema = Yup.object().shape({
    full_name: Yup.string()
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

    // const { UserRequests } = userAgent;
    const [confirmPassword, setConfirmPassword] = useState('')

    const { register, handleSubmit, formState: { errors } } = useForm<UserCreateDTO>({
        resolver: yupResolver(createSchema)
    })


    function handleConfirmPasswordChange(event: ChangeEvent<HTMLInputElement>) {
        const eventInput = event.target.value;
        setConfirmPassword(eventInput)
        console.log(eventInput);
    }


    function submitForm(data: UserCreateDTO) {
        // if(data.password !== confirmPassword){
        //     alert("password and confirmed password are not the same")
        //     return
        // }
        console.log("HEJ");


    }


    return (
        <div className="flex flex-col items-center justify-center min-h-screen bg-gray-500">
          <div className="w-full max-w-md p-9 bg-white rounded-md shadow-md">
            <h2 className="text-giant font-big text-gray-900 mb-6 flex flex-col items-center justify-center">Create account</h2>

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

              <div className="mb-4">
                <label className="block text-gray-700 font-medium mb-2">
                  Email
                </label>
                <input className="w-full p-2 border border-gray-400 rounded-md focus:outline-none focus:border-blue-500"
                  type="email"
                  placeholder="Enter your email"
                  {...register("email")}
                />
                {errors.email && <span>{errors.email.message}</span>}
              </div>

              <div className="mb-4 pt-1">
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

              <div className='pt-3'>
                <button className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 transition duration-200" type="submit"
                >
                    Create
                </button>
              </div>
            </form>

          </div>
        </div>
      );
    }

  export default CreateAccount;