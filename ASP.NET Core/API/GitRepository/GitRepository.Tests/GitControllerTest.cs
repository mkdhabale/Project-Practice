using AutoMapper;
using GitRepository.Helpers.AutoMapperGlobal;
using GitRepository.Models;
using GitRepository.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace GitRepository.Tests
{
    public class GitControllerTest
    {
        private  IMapper _mapper;
        private  IMemoryCache _cache ;
        private GitServices _testignUnit = null;

        public GitControllerTest()
        {

            if (_testignUnit == null)
            {
                
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new ApplicationMapper());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }

                 _cache = new MemoryCache(new MemoryCacheOptions());
                _testignUnit = new GitServices(_mapper, _cache);
            }

        }
        [Fact]
        public void AddValue()
        {
            int x1 = 5;
            int x2 = 6;
            int expectedResult = 11;
            var actualresult = _testignUnit.AddValue(x1, x2);
            Assert.Equal(expectedResult, actualresult);

        }

        [Fact]
        public async void RetrieveUsers()
        {
            string[] useres = { "mukulk" };
            List<string> usernames = new List<string>(useres);
            List<GitUserSent> expectedResult = new List<GitUserSent>();
            GitUserSent gitUserSent = new GitUserSent();

            //this should be dynamic if changes repos count for now it is added for testing purpose
            gitUserSent.name = null;
            gitUserSent.login = "MukulK";
            gitUserSent.company = null;
            gitUserSent.followers = 0;
            gitUserSent.public_repos = 2;
            gitUserSent.public_repos = 2;
            gitUserSent.is_found = true;
            gitUserSent.error = null;
            expectedResult.Add(gitUserSent);
            
            var actualresult = await _testignUnit.RetrieveUsers(usernames);

            Assert.Equal(expectedResult.Count, actualresult.Count);
            for (int i = 0; i <  expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].is_found, actualresult[i].is_found);
            }
        }
    }
}
