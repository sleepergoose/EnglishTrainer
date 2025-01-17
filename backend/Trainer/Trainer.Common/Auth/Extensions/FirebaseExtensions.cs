﻿using FirebaseAdmin.Auth;
using OneOf;
using OneOf.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trainer.Common.Auth.Extensions
{
    public static class FirebaseExtensions
    {
        public static Task<OneOf<UserRecord, FirebaseAuthException>> TryCreateUserAsync(this FirebaseAuth auth, UserRecordArgs args)
        {
            return HandleAuthValueTaskAsync(auth.CreateUserAsync(args));
        }

        public static Task<OneOf<FirebaseToken, FirebaseAuthException>> TryVerifyIdTokenAsync(this FirebaseAuth auth, string token)
        {
            return HandleAuthValueTaskAsync(auth.VerifyIdTokenAsync(token));
        }

        public static Task<OneOf<Success, FirebaseAuthException>> TryUpdateUserAsync(this FirebaseAuth auth, UserRecordArgs args)
        {
            return HandleAuthTaskAsync(auth.UpdateUserAsync(args));
        }

        public static Task<OneOf<Success, FirebaseAuthException>> TrySetCustomUserClaimsAsync(
            this FirebaseAuth auth, string uid, IReadOnlyDictionary<string, object> claims)
        {
            return HandleAuthTaskAsync(auth.SetCustomUserClaimsAsync(uid, claims));
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

        private static async Task<OneOf<Success, FirebaseAuthException>> HandleAuthTaskAsync(Task task)
        {
            try
            {
                await task;
                return new Success();
            }
            catch (FirebaseAuthException exception)
            {
                return exception;
            }
        }
    }
}
