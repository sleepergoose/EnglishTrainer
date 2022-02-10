using AutoMapper;
using Trainer.Admin.Domain.Entities;
using Trainer.Domain.Models;

namespace Trainer.Admin.Common.MappingProfiles
{
    public class PvTrackProfile : Profile
    {
        public PvTrackProfile()
        {
            CreateMap<PvTrack, PhrasalVerbTrackRead>();
        }
    }
}
