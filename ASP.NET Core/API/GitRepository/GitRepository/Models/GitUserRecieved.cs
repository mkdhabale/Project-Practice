using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitRepository.Models
{
    public class GitUserRecieved
    {
        [Required]
        public string login { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public string node_id { get; set; }
        [Required]
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        [Required]
        public string url { get; set; }
        [Required]
        public string html_url { get; set; }
        [Required]
        public string followers_url { get; set; }
        [Required]
        public string following_url { get; set; }
        [Required]
        public string gists_url { get; set; }
        [Required]
        public string starred_url { get; set; }
        [Required]
        public string subscriptions_url { get; set; }
        [Required]
        public string organizations_url { get; set; }
        [Required]
        public string repos_url { get; set; }
        [Required]
        public string events_url { get; set; }
        [Required]
        public string received_events_url { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public bool site_admin { get; set; }
        public string name { get; set; }
        public string company { get; set; }

        public string blog { get; set; }

        public string location { get; set; }

        public string email { get; set; }

        public bool? hireable { get; set; }

        public string bio { get; set; }

        public string twitter_username { get; set; }
        [Required]
        public int public_repos { get; set; }
        [Required]
        public int public_gists { get; set; }
        [Required]
        public int followers { get; set; }
        [Required]
        public int following { get; set; }
        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set; }


        public bool? is_found { get; set; }

        public string? error { get; set; }

        public string? message { get; set; }
        public string? documentation_url { get; set; }
    }
}
