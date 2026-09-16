

using AutoMapper;
using BookHub.Data.Entities;
using BookHub.Data.MappingProfiles.Inputs;
using BookHub.Data.MappingProfiles.Inputs.BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.MappingProfiles.Outputs;
using BookHub.Data.MappingProfiles.Outputs.BookHub.Data.MappingProfiles.Inputs;

namespace BookHub.Services.Mapper
{
   
        public class BookProfile : Profile
        {
            public BookProfile()
            {
                CreateMap<AddBookDto, Book>();

                CreateMap<UpdateBookDto, Book>();

                CreateMap<Book, BookShowDto>();
            }
        }
    }

