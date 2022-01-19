using AutoMapper;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.Common.MappingProfiles
{
    public class PhrasalVerbProfile : Profile
    {
        public PhrasalVerbProfile()
        {
            CreateMap<PhrasalVerb, PhrasalVerbWrite>().ReverseMap();
            CreateMap<PhrasalVerb, PhrasalVerbRead>().ReverseMap();
        }
    }
}
