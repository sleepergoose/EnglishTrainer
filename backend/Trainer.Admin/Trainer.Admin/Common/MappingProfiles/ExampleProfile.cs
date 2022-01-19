using AutoMapper;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.Common.MappingProfiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<WordExample, Example>().ReverseMap();
            CreateMap<PvExample, Example>().ReverseMap();
        }
    }
}
