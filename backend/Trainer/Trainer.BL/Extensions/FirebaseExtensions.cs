using FirebaseAdmin.Auth;
using OneOf;
using System.Threading.Tasks;

namespace Trainer.BL.Extensions
{
    public static class FirebaseExtensions
    {
        public static Task<OneOf<UserRecord, FirebaseAuthException>> TryCreateUserAsync(this FirebaseAuth auth, UserRecordArgs args)
        {
            return HandleAuthValueTaskAsync(auth.CreateUserAsync(args));
        }

        private static async Task<OneOf<T, FirebaseAuthException>> HandleAuthValueTaskAsync<T>(Task<T> task)
        {
            try
            {
                var result = await task;
                return result;
            }
            catch (FirebaseAuthException exception)
            {
                return exception;
            }
        }
    }
}
