using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainer.Common.DTO;
using Trainer.DAL.Context;
using Trainer.Domain.Models;

namespace Trainer.BL.Services
{
    public sealed class WordExamplesService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public WordExamplesService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WordExampleDTO> GetWordExampleAsync(int id)
        {
            var we = await _context.WordExamples.FirstOrDefaultAsync(we => we.Id == id);
            return _mapper.Map<WordExampleDTO>(we);
        }

        public async Task<ICollection<WordExampleDTO>> GetWordExamplesAsync()
        {
            var wes = await _context.WordExamples.ToListAsync();
            return _mapper.Map<ICollection<WordExampleDTO>>(wes);
        }

        public async Task<WordExampleDTO> CreateWordExampleAsync(WordExampleDTO dto)
        {
            var we = _mapper.Map<WordExample>(dto);

            var existedExample = await _context.WordExamples.FirstOrDefaultAsync(we => we.Phrase == dto.Phrase);

            if (existedExample != null)
                return _mapper.Map<WordExampleDTO>(existedExample);

            we.Id = 0;

            await _context.WordExamples.AddAsync(we);
            await _context.SaveChangesAsync();

            return _mapper.Map<WordExampleDTO>(we);
        }

        public async Task<WordExampleDTO> UpdateWordExampleAsync(WordExampleDTO dto)
        {
            var updatedExample = await _context.WordExamples.FirstOrDefaultAsync(we => we.Phrase == dto.Phrase);

            if (updatedExample == null)
                return _mapper.Map<WordExampleDTO>(null);

            if (!string.IsNullOrEmpty(dto.Phrase.Trim()))
                updatedExample.Phrase = dto.Phrase;

            if (!string.IsNullOrEmpty(dto.Translation.Trim()))
                updatedExample.Translation = dto.Translation;

            _context.WordExamples.Update(updatedExample);
            await _context.SaveChangesAsync();

            return _mapper.Map<WordExampleDTO>(updatedExample);
        }

        public async Task<int> DeleteWordExampleVerbAsync(int id)
        {
            var deletedExample = await _context.WordExamples.FirstOrDefaultAsync(we => we.Id == id);

            if (deletedExample == null)
                return -1;

            _context.WordExamples.Remove(deletedExample);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
