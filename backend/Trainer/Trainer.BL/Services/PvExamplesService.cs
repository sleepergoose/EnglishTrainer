using AutoMapper;
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
    public sealed class PvExamplesService
    {
        private readonly IMapper _mapper;
        private readonly TrainerContext _context;

        public PvExamplesService(IMapper mapper, TrainerContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PvExampleDTO> GetPvExampleAsync(int id)
        {
            var pve = await _context.PvExamples.FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PvExampleDTO>(pve);
        }

        public async Task<ICollection<PvExampleDTO>> GetPvExamplesAsync()
        {
            var pves = await _context.PvExamples.ToListAsync();
            return _mapper.Map<ICollection<PvExampleDTO>>(pves);
        }

        public async Task<PvExampleDTO> CreatePvExampleAsync(PvExampleDTO dto)
        {
            var pve = _mapper.Map<PvExample>(dto);

            var existedExample = await _context.PvExamples.FirstOrDefaultAsync(p => p.Phrase == dto.Phrase);

            if (existedExample != null)
                return _mapper.Map<PvExampleDTO>(existedExample);

            pve.Id = 0;

            await _context.PvExamples.AddAsync(pve);
            await _context.SaveChangesAsync();

            return _mapper.Map<PvExampleDTO>(pve);
        }

        public async Task<PvExampleDTO> UpdatePvExampleAsync(PvExampleDTO dto)
        {
            var updatedExample = await _context.PvExamples.FirstOrDefaultAsync(p => p.Phrase == dto.Phrase);

            if (updatedExample == null)
                return _mapper.Map<PvExampleDTO>(null);

            if (!string.IsNullOrEmpty(dto.Phrase.Trim()))
                updatedExample.Phrase = dto.Phrase;

            if (!string.IsNullOrEmpty(dto.Translation.Trim()))
                updatedExample.Translation = dto.Translation;

            _context.PvExamples.Update(updatedExample);
            await _context.SaveChangesAsync();

            return _mapper.Map<PvExampleDTO>(updatedExample);
        }

        public async Task<int> DeletePvExampleAsync(int id)
        {
            var deletedExample = await _context.PvExamples.FirstOrDefaultAsync(we => we.Id == id);

            if (deletedExample == null)
                return -1;

            _context.PvExamples.Remove(deletedExample);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
