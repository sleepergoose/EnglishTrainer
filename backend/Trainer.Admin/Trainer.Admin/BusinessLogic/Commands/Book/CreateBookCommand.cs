using Dapper;
using MediatR;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Trainer.Domain.Models;
using System.Linq;
using Trainer.Domain.Enums;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public string BlobId { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IDbConnection _dbConnection;

        public CreateBookCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                Name = command.Name,
                Author = command.Author,    
                CreatedAt = DateTimeOffset.Now,
                Description = command.Description,
                BlobId = command.BlobId,
                Level = command.Level
            };

            // Is there the added word?
            const string sql_0 =
                @"SELECT * FROM Books WHERE Name=@Name";
            var existedWord = (await _dbConnection.QueryAsync<Word>(sql_0, book)).FirstOrDefault();

            if (existedWord != null)
                return book;

            const string sql_1 =
                @"INSERT INTO Books (
                    Name, Author, Description, Level, BlobId, CreatedAt)
                VALUES (
                    @Name, @Author, @Description, @Level, @BlobId, @CreatedAt)
                SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = await _dbConnection.QueryFirstAsync<int>(sql_1, book);
            book.Id = id;

            return book;
        }
    }
}
