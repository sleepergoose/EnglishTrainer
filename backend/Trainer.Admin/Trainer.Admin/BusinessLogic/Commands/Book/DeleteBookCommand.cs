using Dapper;
using MediatR;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Trainer.Domain.Models;
using System.Linq;

namespace Trainer.Admin.BusinessLogic.Commands
{
    public class DeleteBookCommand : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IDbConnection _dbConnection;

        public DeleteBookCommandHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<string> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            int bookId = command.Id;

            // Is there the added book?
            string sql_0 = $"SELECT * FROM Books WHERE Id={bookId}";
            var existedBook = (await _dbConnection.QueryAsync<Book>(sql_0)).FirstOrDefault();

            if (existedBook == null)
                return null;

            string fileName = existedBook.Name;

            string sql_1 = @$"DELETE FROM Books WHERE Id = {bookId}";

            await _dbConnection.ExecuteAsync(sql_1);

            return fileName;
        }
    }
}
