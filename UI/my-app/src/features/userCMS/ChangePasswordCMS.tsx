import { observer } from 'mobx-react-lite'
import React from 'react'
import Navbar from '../../components/Navbar'
import ProfileSidebar from './ProfileSidebar'

export default observer (function ChangePasswordCMS() {

    return (
        <div className='container relative mx-auto'>
          <Navbar />
            {/* UserCMS-sidebar */}
            <div className='py-5 flex flex-row'>
                <ProfileSidebar />
                {/* User Update Form */}
                <form action="" className='w-4/5'>
                    <div className="flex flex-row p-10 text-left justify-between">
                        {/* Field inputs */}
                        <div className="flex flex-col w-2/5 space-y-8">
                            <div className='space-y-4'>
                                <h6 className="">Password</h6>
                                <input 
                                    type="text" 
                                    className="border border-solid border-gray-400 focus:outline-none px-12 pl-2 py-1 text-left"
                                    placeholder=""
                                />
                            </div>
                            <div className='space-y-4'>
                                <h6 className="">Confim password</h6>
                                <input 
                                    type="text" 
                                    className="border border-solid border-gray-400 focus:outline-none px-12 pl-2 py-1"
                                    placeholder=""
                                />
                            </div>
                            <div className='py-2 text-center mx-auto pl-24'>
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