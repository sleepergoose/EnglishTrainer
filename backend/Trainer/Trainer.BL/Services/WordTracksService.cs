﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO;
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
            var track = await _context.WordTracks.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<WordTrackReadDTO>(track);
        }

        public async Task<ICollection<WordTrackReadDTO>> GetWordTracksAsync()
        {
            var tracks = await _context.WordTracks.ToListAsync();
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

        public async Task<WordTrackReadDTO> UpdateWordTrackAsync(WordTrackWriteDTO dto)
        {
            var updatedTrack = await _context.WordTracks.FirstOrDefaultAsync(tr => tr.Name == dto.Name);

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
            var deletedTrack = await _context.WordTracks.FirstOrDefaultAsync(tr => tr.Id == id);

            if (deletedTrack == null)
                return -1;

            _context.WordTracks.Remove(deletedTrack);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
