using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO.Trainer;
using Trainer.Common.DTO.UserDTO;
using Trainer.Common.DTO.WordTrackDTO;
using Trainer.DAL.Context;

namespace Trainer.BL.Services
{
    public sealed class TrainerService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public TrainerService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<TrainerWordDTO>> GetWordsByTrackIdAsync(int trackId)
        {
            var words = await _context.WordToTracks
                .Where(wt => wt.WordTrackId == trackId)
                .Include(wt => wt.Word)
                    .ThenInclude(w => w.Examples)
                .Select(wt => wt.Word)
                .ToListAsync();

            return _mapper.Map<ICollection<TrainerWordDTO>>(words);
        }

        public async Task<WordTrackCardReadDTO> GetTrackByIdAsync(int trackId)
        {
            var track = await _context.WordTracks
                .Where(t => t.Id == trackId)
                .Include(wt => wt.Author)
                .Select(w => new WordTrackCardReadDTO
                {
                    Id = w.Id,
                    Name = w.Name,
                    Description = w.Description,
                    Level = w.Level,
                    CreatedAt = w.CreatedAt,
                    Author = _mapper.Map<UserReadShortDTO>(w.Author),
                    Amount = w.Words.Count,
                    Rate = 0
                })
                .FirstOrDefaultAsync();

            return track;
        }
    }
}
