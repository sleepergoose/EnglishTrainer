using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainer.DAL.Context;
using Trainer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Trainer.Common.DTO;

namespace Trainer.BL.Services
{
    public class WordsService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public WordsService(TrainerContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<WordDTO> GetWord(int id)
        {
            var word = await _context.Words.FirstOrDefaultAsync(w => w.Id == id);
            return _mapper.Map<WordDTO>(word);
        }

        public async Task<ICollection<Word>> GetWords()
        {
            var words = await _context.Words.ToListAsync();
            return _mapper.Map<ICollection<Word>>(words);
        }
    }
}
