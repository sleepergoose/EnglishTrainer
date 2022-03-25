using AutoMapper;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.Common.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookRead>().ReverseMap();
            CreateMap<Book, BookWrite>().ReverseMap();
        }
    }
}
