﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookSotre.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is mandatory.")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
