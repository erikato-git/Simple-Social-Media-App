import { observer } from 'mobx-react-lite'
import React from 'react'

export default observer (function ProfileSidebar() {
  return (
    <nav className="flex flex-col w-1/5 text-left space-y-12 pt-10">
        <a href="/Profile" className="text-black hover:text-darkGrayishBlue">Personal Info</a>
        <a href="/Security" className="text-black hover:text-darkGrayishBlue">Security</a>
    </nav>
  )
})