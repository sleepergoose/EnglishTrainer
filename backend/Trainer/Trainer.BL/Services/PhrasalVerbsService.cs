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

        public async Task<PhrasalVerbReadDTO> GetPhrasalVerbAsync(int id)
        {
            var pv = await _context.PhrasalVerbs
                .Include(pv => pv.Examples)
                .FirstOrDefaultAsync(pv => pv.Id == id);
            return _mapper.Map<PhrasalVerbReadDTO>(pv);
        }

        public async Task<ICollection<PhrasalVerbReadDTO>> GetPhrasalVerbsAsync()
        {
            var pvs = await _context.PhrasalVerbs.ToListAsync();
            return _mapper.Map<ICollection<PhrasalVerbReadDTO>>(pvs);
        }
    }
}
