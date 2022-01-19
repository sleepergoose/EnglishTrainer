using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO;
using Trainer.DAL.Context;

namespace Trainer.BL.Services
{
    public sealed class SearchService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public SearchService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<WordDTO>> GetWordsByNameAsync(string term)
        {
            var words = await _context.Words.Where(w => w.Text.Contains(term.Trim()))
                .ToListAsync();

            return _mapper.Map<ICollection<WordDTO>>(words);
        }

        public async Task<ICollection<PhrasalVerbReadDTO>> GetPhrasalVerbByNameAsync(string term)
        {
            var words = await _context.PhrasalVerbs
                .Where(w => w.Text.Contains(term.Trim()))
                .Include(pv => pv.Examples)
                .ToListAsync();

            return _mapper.Map<ICollection<PhrasalVerbReadDTO>>(words);
        }
    }
}
