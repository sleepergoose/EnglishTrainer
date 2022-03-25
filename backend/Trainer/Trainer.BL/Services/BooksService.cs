using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.Common.DTO.Book;
using Trainer.DAL.Context;
using Trainer.Domain.Models;

namespace Trainer.BL.Services
{
    public class BooksService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;

        public BooksService(TrainerContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ICollection<BookReadDTO>> GetBooksAsync()
        {
            return _mapper.Map<ICollection<BookReadDTO>>(await _context.Books.ToListAsync());
        }
    }
}
