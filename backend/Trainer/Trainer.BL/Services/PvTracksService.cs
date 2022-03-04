using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.Common.DTO;
using Trainer.Common.DTO.WordTrackDTO;
using Trainer.DAL.Context;
using Trainer.Domain.Models;

namespace Trainer.BL.Services
{
    public sealed class PvTracksService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public PvTracksService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PvTrackReadDTO> GetPvTrackAsync(int id)
        {
            var track = await _context.PvTracks
                .Include(wt => wt.Author)
                .FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<PvTrackReadDTO>(track);
        }

        public async Task<ICollection<PhrasalVerbReadDTO>> GetPvByTrackIdAsync(int id)
        {
            var verbs = await _context.PvToTracks
                .Where(wt => wt.PvTrackId == id)
                .Include(wt => wt.PhrasalVerb)
                .Select(w => w.PhrasalVerb)
                .ToListAsync();

            return _mapper.Map<ICollection<PhrasalVerbReadDTO>>(verbs);
        }

        public async Task<ICollection<PvTrackReadDTO>> GetPvTracksAsync()
        {
            var tracks = await _context.PvTracks
                .Include(wt => wt.Author)
                .ToListAsync();

            return _mapper.Map<ICollection<PvTrackReadDTO>>(tracks);
        }

        public async Task<PvTrackReadDTO> CreatePvTrackAsync(PvTrackWriteDTO dto)
        {
            var track = _mapper.Map<PvTrack>(dto);

            var existedTrack = await _context.PvTracks.FirstOrDefaultAsync(t => t.Name == dto.Name);

            if (existedTrack != null)
                return _mapper.Map<PvTrackReadDTO>(existedTrack);

            track.Id = 0;

            await _context.PvTracks.AddAsync(track);
            await _context.SaveChangesAsync();

            return _mapper.Map<PvTrackReadDTO>(track);
        }

        public async Task<PvTrackReadDTO> UpdatePvTrackAsync(PvTrackWriteDTO dto)
        {
            var updatedTrack = await _context.PvTracks.FirstOrDefaultAsync(tr => tr.Name == dto.Name);

            if (updatedTrack == null)
                return _mapper.Map<PvTrackReadDTO>(null);

            if (!string.IsNullOrEmpty(dto.Name.Trim()))
                updatedTrack.Name = dto.Name;

            if (!string.IsNullOrEmpty(dto.Description.Trim()))
                updatedTrack.Description = dto.Description;

            if (dto.Level != updatedTrack.Level)
                updatedTrack.Level = dto.Level;

            _context.PvTracks.Update(updatedTrack);
            await _context.SaveChangesAsync();

            return _mapper.Map<PvTrackReadDTO>(updatedTrack);
        }

        public async Task<int> DeletePvTrackAsync(int id)
        {
            var deletedTrack = await _context.PvTracks.FirstOrDefaultAsync(tr => tr.Id == id);

            if (deletedTrack == null)
                return -1;

            _context.PvTracks.Remove(deletedTrack);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<ICollection<TrackNameDTO>> GetTracksByAuthorIdAsync(int id)
        {
            var tracks = await _context.PvTracks
                .Where(t => t.AuthorId == id)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return _mapper.Map<ICollection<TrackNameDTO>>(tracks);
        }
    }
}
