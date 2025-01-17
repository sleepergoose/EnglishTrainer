﻿using AutoMapper;
using Trainer.Common.DTO;
using Trainer.Common.DTO.Word;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<Word, WordDTO>().ReverseMap();
            CreateMap<Word, WordReadExamplesDTO>().ReverseMap();
        }
    }
}
