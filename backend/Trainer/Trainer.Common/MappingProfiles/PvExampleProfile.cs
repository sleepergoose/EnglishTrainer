using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class PvExampleProfile : Profile
    {
        public PvExampleProfile()
        {
            CreateMap<PvExample, PvExampleDTO>().ReverseMap();
        }
    }
}
