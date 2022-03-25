using AutoMapper;
using Trainer.Common.DTO.Book;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class BookbProfile : Profile
    {
        public BookbProfile()
        {
            CreateMap<Book, BookReadDTO>().ReverseMap();
        }
    }
}
