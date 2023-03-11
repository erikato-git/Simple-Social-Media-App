import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react'
import { Navigate } from 'react-router-dom';
import Navbar from '../../components/Navbar'
import { Post } from '../../utils/models/Post';
import { useStore } from '../../utils/state_mgmt/Store';
import userAgent from '../../utils/UserAgent';


export default observer (function PostWall() {
  const { UserRequests } = userAgent;
  const { userStore } = useStore();
  const currentUser = userStore.loggedInUser;
  const [posts, setPosts] = useState<Post[]>([]);

  interface PostDTO{
    id: string,
    content: string;
  }

  // const posts: PostDTO[] = [
  //   {
  //     id: "1",
  //     content: "content 1"
  //   },
  //   {
  //     id: "2",
  //     content: "content 2"
  //   },
  //   {
  //     id: "3",
  //     content: "content 3"
  //   }
  // ]

  console.log(currentUser?.userId);

  useEffect(() => {
    async function fetchPosts(){
      try {
        if(currentUser){
          const result = await userAgent.PostRequests.getPostsByUserid(currentUser.userId)
          setPosts(result)
        }
      } catch (error) {
        console.log(error);
      }
    }
    fetchPosts();
  },[])

  console.log(posts)


  return (

    <div>

      {
        currentUser ?
  
        <div className='container relative mx-auto'>
        <Navbar />
          {/* PostWall-sidebar */}
          <div className='py-5 flex flex-row'>
            <div className='w-1/5'>
              <nav className="flex flex-col w-1/5 text-left space-y-12 pt-10">
                  <a href="/Chats" className="text-black hover:text-darkGrayishBlue">Chats</a>
                  <a href="/Pictures" className="text-black hover:text-darkGrayishBlue">Pictures</a>
                  <a href="/Followers" className="text-black hover:text-darkGrayishBlue">Followers</a>
              </nav>
            </div>
    
            <div className='w-4/5 mx-auto text-center mt-6'>
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
            </div>
    
          </div>
    
          {/* Post-form */}
    
    
          {/* Post-overview: ordered in dato descending order newest -> oldest */}
    
          {/* - Lav en fake-posts-list til at bygge front-end op først */}
    
        </div>


      :
        <Navigate to={'/LoginOrRegister'} />
      }
    </div>



)
})