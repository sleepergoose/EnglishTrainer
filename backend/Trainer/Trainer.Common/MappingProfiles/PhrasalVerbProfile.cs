using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class PhrasalVerbProfile : Profile
    {
        public PhrasalVerbProfile()
        {
            CreateMap<PhrasalVerb, PhrasalVerbReadDTO>().ReverseMap();
            CreateMap<PhrasalVerb, PhrasalVerbWriteDTO>().ReverseMap();
        }
    }
}
