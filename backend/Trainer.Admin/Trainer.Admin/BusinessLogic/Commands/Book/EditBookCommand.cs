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
    public class EditBookCommand : IRequest<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public KnowledgeLevel Level { get; set; }
        public string BlobId { get; set; }
    }

    public class EditBookCommandHandler : IRequestHandler<EditBookCommand, Book>
    {
        private readonly IDbConnection _dbConnection;

        public EditBookCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Book> Handle(EditBookCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var book = new Book()
                {
                    Id = command.Id,
                    Name = command.Name,
                    Author = command.Author,
                    Description = command.Description
                };

                // Is there such a book?
                const string sql_0 =
                    @"SELECT * FROM Books WHERE Id=@Id";
                var existedBook = (await _dbConnection.QueryAsync<Book>(sql_0, book)).FirstOrDefault();

                if (existedBook == null)
                    throw new Exception("There is no such a book");

                // Update the book
                const string sql_1 =
                    @"UPDATE Books SET 
                    Name=@Name,
                    Author=@Author,
                    Description=@Description
                WHERE Id=@Id";

                await _dbConnection.ExecuteAsync(sql_1, book);

                return (await _dbConnection.QueryAsync<Book>(sql_0, book)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
