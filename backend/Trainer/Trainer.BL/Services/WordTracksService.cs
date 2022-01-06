using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO;
using Trainer.Common.DTO.WordTrackDTO;
using Trainer.DAL.Context;
using Trainer.Domain.Models;

namespace Trainer.BL.Services
{
    public sealed class WordTracksService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public WordTracksService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WordTrackReadDTO> GetWordTrackAsync(int id)
        {
            var track = await _context.WordTracks
                .Include(wt => wt.Author)
                .FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<WordTrackReadDTO>(track);
        }

        public async Task<ICollection<WordDTO>> GetWordsByTrackIdAsync(int id)
        {
            var words = await _context.WordToTracks
                .Where(wt => wt.WordTrackId == id)
                .Include(wt => wt.Word)
                .Select(w => w.Word)
                .ToListAsync();

            return _mapper.Map<ICollection<WordDTO>>(words);
        }

        public async Task<ICollection<WordTrackReadDTO>> GetWordTracksAsync()
        {
            var tracks = await _context.WordTracks
                .Include(wt => wt.Author)
                .ToListAsync();
            return _mapper.Map<ICollection<WordTrackReadDTO>>(tracks);
        }

        public async Task<WordTrackReadDTO> CreateWordTrackAsync(WordTrackWriteDTO dto)
        {
            var track = _mapper.Map<WordTrack>(dto);

            var existedTrack = await _context.WordTracks.FirstOrDefaultAsync(t => t.Name == dto.Name);

            if (existedTrack != null)
                return _mapper.Map<WordTrackReadDTO>(existedTrack);

            track.Id = 0;

            await _context.WordTracks.AddAsync(track);
            await _context.SaveChangesAsync();

            return _mapper.Map<WordTrackReadDTO>(track);
        }
      
        public async Task<WordToTrackWriteDTO> AddWordToTrackAsync(WordToTrackWriteDTO dto)
        {
            var track = await _context.WordTracks.FirstOrDefaultAsync(wt => wt.Id == dto.TrackId);
            var word = await _context.Words.FirstOrDefaultAsync(w => w.Id == dto.WordId);

            var wordToTrack = new WordToTrack
            {
                WordTrack = track,
                Word = word
            };

            await _context.WordToTracks.AddAsync(wordToTrack);
            await _context.SaveChangesAsync();

            return dto;
        }


        public async Task<WordTrackReadDTO> UpdateWordTrackAsync(WordTrackReadDTO dto)
        {
            var updatedTrack = await _context.WordTracks.FirstOrDefaultAsync(tr => tr.Id == dto.Id);

            if (updatedTrack == null)
                return _mapper.Map<WordTrackReadDTO>(null);

            if (!string.IsNullOrEmpty(dto.Name.Trim()))
                updatedTrack.Name = dto.Name;

            if (!string.IsNullOrEmpty(dto.Description.Trim()))
                updatedTrack.Description = dto.Description;

            if (dto.Level != updatedTrack.Level)
                updatedTrack.Level = dto.Level;

            _context.WordTracks.Update(updatedTrack);
            await _context.SaveChangesAsync();

            return _mapper.Map<WordTrackReadDTO>(updatedTrack);
        }

        public async Task<int> DeleteWordTrackAsync(int id)
        {
            var deletedTrack = await _context.WordTracks
                .Include(wt => wt.Words)
                .FirstOrDefaultAsync(tr => tr.Id == id);

            if (deletedTrack == null)
                return -1;

            _context.WordTracks.Remove(deletedTrack);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<int> RemoveWordFromTrackAsync(WordToTrackWriteDTO dto)
        {
            var entity = await _context.WordToTracks
                .FirstOrDefaultAsync(wt => wt.WordTrackId == dto.TrackId
                    && wt.WordId == dto.WordId);

            _context.WordToTracks.Remove(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<ICollection<TrackNameDTO>> GetTracksByAuthorIdAsync(int id)
        {
            var tracks = await _context.WordTracks
                .Where(t => t.AuthorId == id)
                .ToListAsync();

            return _mapper.Map<ICollection<TrackNameDTO>>(tracks);
        }
    }
}
