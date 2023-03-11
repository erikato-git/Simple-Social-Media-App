import React from 'react'
import { Link, NavLink } from 'react-router-dom'

function Navbar() {
    return (
      <div className='py-5'>
        <nav className="flex items-center justify-between text-xl">
            <a href="/Home" className="text-black hover:text-darkGrayishBlue">Home</a>
            <a href="/Profile" className="text-black hover:text-darkGrayishBlue">Profile</a>
            <p className='pt-4'>[Searchbar]</p>
            <p></p>
            <a href="About" className="text-black hover:text-darkGrayishBlue">About</a>
            <a href="#" className="text-black hover:text-darkGrayishBlue">Log out</a>
        </nav>
      </div>
    );
}

export default Navbar