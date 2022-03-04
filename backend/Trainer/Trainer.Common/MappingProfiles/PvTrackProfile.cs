using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Common.DTO.WordTrackDTO;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class PvTrackProfile : Profile
    {
        public PvTrackProfile()
        {
            CreateMap<PvTrack, PvTrackReadDTO>().ReverseMap();
            CreateMap<PvTrack, PvTrackWriteDTO>().ReverseMap();
            CreateMap<PvTrack, TrackNameDTO>();
        }
    }
}
