using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Common.DTO.Examples;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class WordExampleProfile : Profile
    {
        public WordExampleProfile()
        {
            CreateMap<WordExample, ExampleWriteDTO>().ReverseMap();
            CreateMap<WordExample, ExampleReadDTO>();
        }
    }
}
