import { observer } from 'mobx-react-lite'
import React from 'react'
import { Link } from 'react-router-dom'

export default observer (function ProfileSidebar() {
  return (
    <nav className="flex flex-col w-1/5 text-left space-y-12 pt-10">
        <Link to="/Profile" className="text-black hover:text-darkGrayishBlue">Personal Info</Link>
        <Link to="/Security" className="text-black hover:text-darkGrayishBlue">Security</Link>
    </nav>
  )
})