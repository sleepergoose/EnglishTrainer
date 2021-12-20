using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class PvTrackProfile : Profile
    {
        public PvTrackProfile()
        {
            CreateMap<PvTrack, PvTrackReadDTO>().ReverseMap();
            CreateMap<PvTrack, PvTrackWriteDTO>().ReverseMap();
        }
    }
}
