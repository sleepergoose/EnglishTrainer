using FirebaseAdmin.Auth;
using System;
using Trainer.Common.Auth.Constants;

namespace Trainer.Common.Auth.Extensions
{
    public static class FirebaseTokenExtensions
    {
        public static bool ContainsId(this FirebaseToken token)
        {
            return token.Claims.ContainsKey(Claims.Id);
        }

        public static int GetId(this FirebaseToken token)
        {
            var id = (long)token.Claims[Claims.Id];
            return Convert.ToInt32(id);
        }
    }
}
