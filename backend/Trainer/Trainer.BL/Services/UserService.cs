using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Trainer.Common.DTO.Auth;
using Trainer.DAL.Context;
using Trainer.Domain.Models;

namespace Trainer.BL.Services
{
    public sealed class UserService
    {
        private readonly TrainerContext _context;
        private readonly IMapper _mapper;
        public UserService(TrainerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async ValueTask<User> GetUserByFirebaseIdAsync(string firebaseId)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.FirebaseId == firebaseId);
        }

        public async Task<User> CreateUsersAsync(UserLoginDTO dto)
        {
            var userEntity = await _context.Users.AddAsync(_mapper.Map<User>(dto));
            await _context.SaveChangesAsync();

            return userEntity.Entity;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userEntity = _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return userEntity.Entity;
        }
    }
}
