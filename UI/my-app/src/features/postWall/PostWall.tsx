import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react'
import { Link, Navigate } from 'react-router-dom';
import Navbar from '../../components/Navbar'
import { Post } from '../../utils/models/Post';
import { useStore } from '../../utils/state_mgmt/Store';
import userAgent from '../../utils/UserAgent';


export default observer (function PostWall() {
    const { userStore } = useStore();
    let [currentUser, setCurrentUser] = useState(userStore.loggedInUser)
    const [posts, setPosts] = useState<Post[]>(currentUser?.posts);
    const [loading, setLoading] = useState<boolean>(true);


    useEffect(() => {

      async function RefreshLoggedInUser(){
        try {
          if(!currentUser){
            const refreshedUser = await userAgent.UserRequests.refreshLoggedInUser();
            const refrehedUserData = refreshedUser.data;

            if(!refreshedUser){
              throw new Error("Couldn't refresh user")
            }

            setCurrentUser(refrehedUserData);
          }
        } catch (error) {
          console.log("Error: refresh loggedInUser: " + error);
        }
      }

      async function FetchPosts(){
        try {
          if(currentUser && !posts){
            const posts = await userAgent.PostRequests.getPostsByUserid(currentUser.userId)
            setPosts(posts)
          }
        } catch (error) {
          console.log(error);
        }
      }
      
      RefreshLoggedInUser();
      FetchPosts();

      setLoading(false)

    },[currentUser,posts,loading])



    console.log("CurrentUser: " + currentUser?.userId);
    console.log("Posts: " + posts);
    console.log("Loading: " + loading);


    function uploadImage(files: any){
      // console.log(files[0]);
    }


    return (
      <>
        {
          loading ?
          <div>
            Loading....
          </div>
          :
          <div>
            {
              true ? 
              
              <div>

                <div className='container relative mx-auto'>
                  <Navbar />
                    {/* PostWall-sidebar */}
                    <div className='py-5 flex flex-row'>
                      <div className='w-1/5'>
                        <nav className="flex flex-col w-1/5 text-left space-y-12 pt-10">
                            <Link to="/Chats" className="text-black hover:text-darkGrayishBlue">Chats</Link>
                            <Link to="/Pictures" className="text-black hover:text-darkGrayishBlue">Pictures</Link>
                            <Link to="/Followers" className="text-black hover:text-darkGrayishBlue">Followers</Link>
                        </nav>
                      </div>
          
          
                      {/* Post-form */}
                      <div>
                        <input type="file" className="" onChange={(e) => uploadImage(e.target.files)} />
                      </div>
          
              
                      {/* Post-overview: ordered in dato descending order newest -> oldest */}
                  
                      <div className='w-4/5 mx-auto text-center mt-6'>

                        {
                          posts ? 
                          <ul className='space-y-20'>
                            {posts.map(post => (
                              <li key={post.postId}>
                                <p>{post.content}</p>
                                <p>{post.createdAt?.toString()}</p>
                                <p>{post.image}</p>
                                <p>{post.userId}</p>
                                <p>{post.user?.full_Name}</p>
                              </li>
                            ))}
                          </ul>
                          :
                          <div></div>
                        }

                      </div>
              
                    </div>
                  </div>

              </div>
              :
              <div>
                <Navigate to={'/LoginOrRegister'} />
              </div>
            }
          </div>
        }
      </>
    )



    // return (
      
    //       {
    //         currentUser ?
      
    //         <div className='container relative mx-auto'>
    //         <Navbar />
    //           {/* PostWall-sidebar */}
    //           <div className='py-5 flex flex-row'>
    //             <div className='w-1/5'>
    //               <nav className="flex flex-col w-1/5 text-left space-y-12 pt-10">
    //                   <Link to="/Chats" className="text-black hover:text-darkGrayishBlue">Chats</Link>
    //                   <Link to="/Pictures" className="text-black hover:text-darkGrayishBlue">Pictures</Link>
    //                   <Link to="/Followers" className="text-black hover:text-darkGrayishBlue">Followers</Link>
    //               </nav>
    //             </div>
    
    
    //             {/* Post-form */}
    //             <div>
    //               <input type="file" className="" onChange={(e) => uploadImage(e.target.files)} />
    //             </div>
    
        
    //             {/* Post-overview: ordered in dato descending order newest -> oldest */}
            
    //             <div className='w-4/5 mx-auto text-center mt-6'>
    //               <ul className='space-y-20'>
    //                 {posts.map(post => (
    //                   <li key={post.postId}>
    //                     <p>{post.content}</p>
    //                     <p>{post.createdAt?.toString()}</p>
    //                     <p>{post.image}</p>
    //                     <p>{post.userId}</p>
    //                     <p>{post.user?.full_Name}</p>
    //                   </li>
    //                 ))}
    //               </ul>
    //             </div>
        
    //           </div>
    //         </div>
    
    //       :
    //         <Navigate to={'/LoginOrRegister'} />
    //       }
      
      

    //   </div>
    // )
  }
)