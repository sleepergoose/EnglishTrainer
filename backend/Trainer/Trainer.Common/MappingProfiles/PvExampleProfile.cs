using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Common.DTO.Examples;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class PvExampleProfile : Profile
    {
        public PvExampleProfile()
        {
            CreateMap<PvExample, ExampleReadDTO>().ReverseMap();
            CreateMap<PvExample, PhrasalVerbWriteDTO>().ReverseMap();
        }
    }
}
