using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Models
{
    public class GitUserSent
    {
        public string name { get; set; }
        [Required]
        public string login { get; set; }
        public string company { get; set; }
        [Required]
        public int followers { get; set; }
        [Required]
        public int public_repos { get; set; }
        public decimal avg_no_followers_per_publicrepositories
        {
            get
            {
                //handle based on requireemnt for now returning 0 is this case
                if (followers > 0 && public_repos > 0)
                    return followers / public_repos;
                else
                    return 0;
            }
        }

        public bool? is_found { get; set; }

        public string? error { get; set; }
    }
}
