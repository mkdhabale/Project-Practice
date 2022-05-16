using GitRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Repository
{
    public interface IGitServices
    {
        Task<List<GitUserSent>> RetrieveUsers(List<string> usernames);
        int AddValue(int x1, int x2);
    }
}
