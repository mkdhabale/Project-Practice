using AutoMapper;
using BookSotre.API.Data;
using BookSotre.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Helpers.AutoMapperGlobal
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //one way or vice versa to use map
            /*CreateMap<Books, BookModel>();
            CreateMap<BookModel, Books>();*/
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
