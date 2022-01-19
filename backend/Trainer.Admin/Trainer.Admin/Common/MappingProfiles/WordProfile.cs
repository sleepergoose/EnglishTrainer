using AutoMapper;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.Common.MappingProfiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordEdit>().ReverseMap();
            CreateMap<Word, WordWrite>().ReverseMap();
            CreateMap<Word, WordRead>().ReverseMap();
        }
    }
}
