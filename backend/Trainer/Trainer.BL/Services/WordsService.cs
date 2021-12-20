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

        public async Task<WordDTO> GetWordAsync(int id)
        {
            var word = await _context.Words.FirstOrDefaultAsync(w => w.Id == id);
            return _mapper.Map<WordDTO>(word);
        }

        public async Task<ICollection<WordDTO>> GetWordsAsync()
        {
            var words = await _context.Words.ToListAsync();
            return _mapper.Map<ICollection<WordDTO>>(words);
        }

        public async Task<WordDTO> CreateWordAsync(WordDTO dto)
        {
            var word = _mapper.Map<Word>(dto);

            var existedWord = await _context.Words.FirstOrDefaultAsync(w => w.Text == dto.Text);

            if (existedWord != null)
                return _mapper.Map<WordDTO>(existedWord);

            word.Id = 0;

            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();

            return _mapper.Map<WordDTO>(word);
        }

        public async Task<WordDTO> UpdateWordAsync(WordDTO dto)
        {
            var updatedWord = await _context.Words.FirstOrDefaultAsync(w => w.Text == dto.Text);

            if (updatedWord == null)
                return _mapper.Map<WordDTO>(null);

            if (!string.IsNullOrEmpty(dto.Text.Trim()))
                updatedWord.Text =  dto.Text;

            if (!string.IsNullOrEmpty(dto.Transcription.Trim()))
                updatedWord.Transcription = dto.Transcription;

            if (!string.IsNullOrEmpty(dto.Translation.Trim()))
                updatedWord.Translation = dto.Translation;

            _context.Words.Update(updatedWord);
            await _context.SaveChangesAsync();

            return _mapper.Map<WordDTO>(updatedWord);
        }

        public async Task<int> DeleteWordAsync(int id)
        {
            var word = await _context.Words.FirstOrDefaultAsync(p => p.Id == id);

            if (word != null)
            {
                _context.Remove(word);
                await _context.SaveChangesAsync();
                return id;
            }

            return -1;
        }
    }
}
