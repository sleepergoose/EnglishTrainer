using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared.AzureBlobStorage;
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
        private readonly IBlobService _blobService;

        public BooksService(TrainerContext context, IMapper mapper, IBlobService blobService)
        {
            _mapper = mapper;
            _context = context;
            _blobService = blobService;
        }

        public async Task<ICollection<BookReadDTO>> GetBooksAsync()
        {
            return _mapper.Map<ICollection<BookReadDTO>>(await _context.Books.ToListAsync());
        }

        public async Task<BookDTO> GetBookAsync(string blobId)
        {
            string bookBody = await _blobService.GetBookAsync(blobId);

            return new BookDTO
            {
                Body = bookBody,
                BookRequisites = _mapper.Map<BookReadDTO>(await _context.Books.FirstOrDefaultAsync(b => b.BlobId == blobId))
            };
        }
    }
}
