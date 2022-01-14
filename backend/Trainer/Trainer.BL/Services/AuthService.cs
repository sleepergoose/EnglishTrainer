using FirebaseAdmin.Auth;
using OneOf;
using OneOf.Types;
using System;
using System.Threading.Tasks;
using Trainer.Common.DTO.Auth;
using Trainer.DAL.Context;
using Trainer.Common.Auth.Extensions;
using Trainer.Domain.Models;
using Trainer.Common.DTO.UserDTO;
using Trainer.Domain.Enums;
using Trainer.Common.Auth.Constants;
using System.Collections.Generic;

namespace Trainer.BL.Services
{
    public sealed class AuthService
    {
        private readonly TrainerContext _context;
        private readonly FirebaseService _firebase;
        private readonly UsersService _usersService;

        public AuthService(TrainerContext context, FirebaseService firebase, UsersService usersService)
        {
            _context = context;
            _firebase = firebase;
            _usersService = usersService;
        }

        public async Task<OneOf<Success, Error>> RegisterAsync(RegisterDataDTO dto)
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

        public async Task<OneOf<Success, Error>> LoginAsync(UserLoginDTO dto)
        {
            // Token verification
            var verificationResult = await VerifyTokenAsync(dto.AccessToken);

            // If error - return the error
            if (verificationResult.IsT1)
            {
                return verificationResult.AsT1;
            }

            // Get firebase token
            FirebaseToken token = verificationResult.AsT0;

            // Get user from the token
            var user = await GetUserFromToken(token);

            // Add a user to database
            if (user == null)
            {
                var userData = new UserWriteDTO
                {
                    FirebaseId = token.Uid,
                    Name = dto.Name,
                    Email = dto.Email,
                    Role = Role.User
                };

                user = await _usersService.CreateUserAsync(userData);
            }

            // Update user data on Firebase Server
            var updateResult = await _firebase.AuthApp.TryUpdateUserAsync(new UserRecordArgs
            {
                DisplayName = user.Name,
                Uid = token.Uid
            });

            if (updateResult.IsT1)
            {
                return new Error();
            }

            // Update user's claims
            return await UpdateUserClaimsAsync(user);
        }

        private async Task<OneOf<FirebaseToken, Error>> VerifyTokenAsync(string token)
        {
            var verificationResult = await _firebase.AuthApp.TryVerifyIdTokenAsync(token);

            return verificationResult.Match<OneOf<FirebaseToken, Error>>(
                verifiedToken => verifiedToken,
                authException => new Error()
            );
        }

        private async Task<User> GetUserFromToken(FirebaseToken token)
        {
            if (!token.ContainsId())
            {
                return null;
            }

            User user = await _usersService.GetUserAsync(token.GetId());

            if (user == null || user.FirebaseId != token.Uid)
            {
                user = await _usersService.GetUserByFirebaseIdAsync(token.Uid);
            }

            return user;
        }

        private async Task<OneOf<Success, Error>> UpdateUserClaimsAsync(User user)
        {
            var claims = new Dictionary<string, object>
            {
                { Claims.Id, user.Id },
                { Claims.Role, user.Role }
            };

            var claimsResult = await _firebase.AuthApp.TrySetCustomUserClaimsAsync(user.FirebaseId, claims);

            return claimsResult.Match<OneOf<Success, Error>>(
                success => success,
                authException => new Error()
            );
        }
    }
}
