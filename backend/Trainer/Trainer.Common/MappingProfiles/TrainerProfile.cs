using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO.Trainer;
using Trainer.Domain.Models;

namespace Trainer.Common.MappingProfiles
{
    public sealed class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            CreateMap<Word, TrainerWordDTO>();
            CreateMap<WordExample, ExampleDTO>();
        }
    }
}
