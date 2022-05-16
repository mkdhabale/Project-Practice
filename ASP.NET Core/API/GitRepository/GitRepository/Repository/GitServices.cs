using AutoMapper;
using GitRepository.Helpers.GitAPICommunication;
using GitRepository.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Repository
{
    public class GitServices : IGitServices
    {
        private readonly IMapper _mapper;
        private IMemoryCache _cache;
        public GitServices(IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<List<GitUserSent>> RetrieveUsers(List<string> usernames)
        {
            List<GitUserRecieved> gitUserRecieved1 = new List<GitUserRecieved>();
            List<GitUserRecieved> gitUserRecieved = await GitAPICommunication.FetchGitDetails(usernames, _cache);
            return _mapper.Map<List<GitUserSent>>(gitUserRecieved);
        }

        public int AddValue(int x1, int x2)
        {
            return (x1 + x2);
        }
    }
}
