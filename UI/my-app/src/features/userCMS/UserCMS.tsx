import { observer } from 'mobx-react-lite'
import React from 'react'
import Navbar from '../../components/Navbar'
import ProfileSidebar from './ProfileSidebar'

export default observer (function UserCMS() {
  return (
    <div className='container relative mx-auto'>
      <Navbar />
        {/* UserCMS-sidebar */}
        <div className='py-5 flex flex-row'>
            <ProfileSidebar />
            {/* User Update Form */}
            <form action="" className='w-4/5'>
                <div className="flex flex-col md:flex-row p-10 text-left justify-between">
                    {/* Field inputs */}
                    <div className="flex flex-col w-2/5 space-y-8 mb-4">
                        <div className='space-y-4'>
                            <h6 className="">Full name</h6>
                            <input 
                                type="text" 
                                className="border border-solid border-gray-400 focus:outline-none px-12 pl-2 py-1 text-left"
                                placeholder=""
                            />
                        </div>
                        <div className='space-y-4'>
                            <h6 className="">Email</h6>
                            <input 
                                type="text" 
                                className="border border-solid border-gray-400 focus:outline-none px-12 pl-2 py-1"
                                placeholder=""
                            />
                        </div>
                        <div className='space-y-4'>
                            <h6 className="">Description</h6>
                            <textarea 
                                className="border border-solid border-gray-400 focus:outline-none px-16 py-10 pt-2 pl-2"
                                placeholder=""
                            />
                        </div>
                    </div>

                    {/* Image input */}
                    <div className='md:mx-auto w-2/5 space-y-4'>
                        <h6>Choose profile-picture</h6>

                        <div className='border border-solid border-gray-400 py-20'></div>

                        <input 
                            type="file" 
                            className=""
                            placeholder=""
                        />
                        <div className='text-center py-8'>
                            <button
                                className="px-6 py-2 text-white rounded-full bg-blue-500 hover:bg-blue-400 focus:outline-none"
                            >
                            Update
                            </button>
                        </div>
                    </div>
                    
                </div>
            </form>
        </div>



    </div>

    )
})