using AutoMapper;
using GitRepository.Models;

namespace GitRepository.Helpers.AutoMapperGlobal
{
    public class ApplicationMapper : Profile
    {
        //To map objects
        public ApplicationMapper()
        {
            CreateMap<GitUserRecieved, GitUserSent>();
        }
    }
}
