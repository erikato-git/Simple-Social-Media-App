using AutoMapper;
using Simple_Social_Media_App.Controllers.DTOs;
using Simple_Social_Media_App.DataAccess.Model;

namespace Simple_Social_Media_App.Utils
{
    public class MapperService : Profile
    {
        public MapperService()
        {
            CreateMap<UserDTO, User>(); 
            CreateMap<UpdatePostDTO, Post>();
            CreateMap<CreatePostDTO, Post>();

        }
    }
}
