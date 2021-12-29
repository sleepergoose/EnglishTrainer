using FirebaseAdmin.Auth;
using OneOf;
using OneOf.Types;
using System;
using System.Threading.Tasks;
using Trainer.Common.DTO.Auth;
using Trainer.DAL.Context;
using Trainer.BL.Extensions;

namespace Trainer.BL.Services
{
    public sealed class AuthService
    {
        private readonly TrainerContext _context;
        private readonly FirebaseService _firebase;

        public AuthService(TrainerContext context, FirebaseService firebase)
        {
            _context = context;
            _firebase = firebase;
        }

        public async Task<OneOf<Success, Error>> Register(RegisterDataDTO dto)
        {
            var user = new UserRecordArgs
            {
                DisplayName = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            var result = await _firebase.AuthApp.TryCreateUserAsync(user);

            return result.Match<OneOf<Success, Error>>(
                userRecord => new Success(),
                authException => new Error()
            );
        }   
    }
}
