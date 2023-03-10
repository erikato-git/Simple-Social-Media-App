import React from 'react'
import Navbar from '../../components/Navbar'

function PostWall() {
  return (
    <div className='container relative mx-auto'>
      <Navbar />
      {/* PostWall-sidebar */}
      <div className='py-5'>
        <nav className="flex flex-col w-1/5 text-left space-y-12 pt-10">
            <a href="/Chats" className="text-black hover:text-darkGrayishBlue">Chats</a>
            <a href="/Pictures" className="text-black hover:text-darkGrayishBlue">Pictures</a>
            <a href="/Followers" className="text-black hover:text-darkGrayishBlue">Followers</a>
        </nav>
      </div>

      {/* Post-form */}


      {/* Post-overview: ordered in dato descending order newest -> oldest */}


    </div>
)
}

export default PostWall