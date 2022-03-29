using Microsoft.AspNetCore.Http;
using OneOf;
using OneOf.Types;
using System.Threading.Tasks;
using Shared.RabbitMQ.Wrapper.Interfaces;
using Shared.RabbitMQ.Wrapper.Models;
using Microsoft.Extensions.Options;
using Shared.RabbitMQ.Wrapper.Options;
using Shared.AzureBlobStorage.Models;
using System.IO;
using System.Collections.Generic;
using System;
using MediatR;
using AutoMapper;
using Trainer.Admin.BusinessLogic.Commands;
using Trainer.Domain.Enums;
using Trainer.Domain.Models;
using Trainer.Admin.Domain.Entities;
using Shared.AzureBlobStorage;

namespace Trainer.Admin.BusinessLogic.Services
{
    public class BooksService
    {
        private readonly IMessageService _messageService;
        private readonly ScopeSettings _producerSettings;
        private readonly ScopeSettings _consumerSettings;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;

        public BooksService(IMessageService messageService,
            IOptions<BookProcessingRabbitMQOptions> rabbitMqOptions,
            IMediator mediator,
            IMapper mapper,
            IBlobService blobService)
        {
            _messageService = messageService;
            _mediator = mediator;
            _mapper = mapper;
            _blobService = blobService;

            var options = rabbitMqOptions.Value;
            _producerSettings = options.ProducerSettings;
            _consumerSettings = options.ConsumerSettings;
        }

        public async Task<OneOf<ICollection<Book>, Error>> UploadBooksAsync(IFormFile[] files)
        {
            try
            {
                var books = new List<Book>();

                _messageService.SetMessageService(_producerSettings, null);

                foreach (var file in files)
                {
                    var data = new BookDataTransferModel
                    {
                        BookBlobId = Guid.NewGuid().ToString(),
                        BookName = file.FileName,
                        ContentType = file.ContentType
                    };

                    MemoryStream memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    data.BookBody = memoryStream.ToArray();

                    var body = BinaryData.FromObjectAsJson(data).ToArray();

                    _messageService.SendDataToQueue(body);

                    var command = new CreateBookCommand
                    {
                        Name = data.BookName,
                        BlobId = data.BookBlobId,
                        Author = "",
                        Description = "",
                        Level = KnowledgeLevel.Beginer
                    };

                    books.Add(await _mediator.Send(command));
                }

                return books;
            }
            catch (Exception ex)
            {
                return new Error();
            }
        }
    
        public async Task<OneOf<BookRead, Error>> EditBookAsync(BookRead book)
        {
            try
            {
                var command = new EditBookCommand
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    BlobId = book.BlobId,
                    Description = book.Description,
                    Level = book.Level
                };

                return _mapper.Map<BookRead>(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return new Error();
            }
        }

        public async Task<OneOf<int, Error>> DeleteBookAsync(int bookId)
        {
            try
            {
                var command = new DeleteBookCommand
                {
                    Id = bookId
                };

                var fileName = _mapper.Map<string>(await _mediator.Send(command));

                await _blobService.DeleteFileAsync(fileName);

                return bookId;
            }
            catch (Exception ex)
            {
                return new Error();
            }
        }
    }
}
