using API_Bibliotek.Models;
using API_Bibliotek.Models.DTOs;
using AutoMapper;

namespace API_Bibliotek
{
    public class MappingConfige : Profile
    {
        public MappingConfige()
        {
            CreateMap<Book, CreateBookDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, UpdateBookDTO>().ReverseMap();
        }
    }
}
