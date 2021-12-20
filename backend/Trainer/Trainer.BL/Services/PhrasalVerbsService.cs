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
    public sealed class PhrasalVerbsService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public PhrasalVerbsService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PhrasalVerbDTO> GetPhrasalVerbAsync(int id)
        {
            var pv = await _context.PhrasalVerbs.FirstOrDefaultAsync(pv => pv.Id == id);
            return _mapper.Map<PhrasalVerbDTO>(pv);
        }

        public async Task<ICollection<PhrasalVerbDTO>> GetPhrasalVerbsAsync()
        {
            var pvs = await _context.PhrasalVerbs.ToListAsync();
            return _mapper.Map<ICollection<PhrasalVerbDTO>>(pvs);
        }

        public async Task<PhrasalVerbDTO> CreatePhrasalVerbAsync(PhrasalVerbDTO dto)
        {
            var pv = _mapper.Map<PhrasalVerb>(dto);

            var createdPV = await _context.PhrasalVerbs.FirstOrDefaultAsync(pv => pv.Text == dto.Text);

            if (createdPV != null)
                return _mapper.Map<PhrasalVerbDTO>(createdPV);

            pv.Id = 0;

            await _context.PhrasalVerbs.AddAsync(pv);
            await _context.SaveChangesAsync();

            return _mapper.Map<PhrasalVerbDTO>(pv);
        }

        public async Task<PhrasalVerbDTO> UpdatePhrasalVerbAsync(PhrasalVerbDTO dto)
        {
            var updatedPV = await _context.PhrasalVerbs.FirstOrDefaultAsync(pv => pv.Text == dto.Text);

            if (updatedPV == null)
                return _mapper.Map<PhrasalVerbDTO>(updatedPV);

            if (!string.IsNullOrEmpty(dto.Text.Trim()))
                updatedPV.Text = dto.Text;

            if (!string.IsNullOrEmpty(dto.Translation.Trim()))
                updatedPV.Translation = dto.Translation;

            _context.PhrasalVerbs.Update(updatedPV);
            await _context.SaveChangesAsync();

            return _mapper.Map<PhrasalVerbDTO>(updatedPV);
        }

        public async Task<int> DeletePhrasalVerbAsync(int id)
        {
            var deletedPV = await _context.PhrasalVerbs.FirstOrDefaultAsync(pv => pv.Id == id);

            if (deletedPV == null)
                return -1;

            _context.PhrasalVerbs.Remove(deletedPV);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
