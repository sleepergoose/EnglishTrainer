using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;

namespace Trainer.BL.Services
{
    public sealed class FirebaseService
    {
        public FirebaseAuth AuthApp { get; }

        public FirebaseService()
        {
            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Environment.CurrentDirectory + @"\bin\Debug\net5.0\trainer-app.json")
            });

            AuthApp = FirebaseAuth.GetAuth(app);
        }
    }
}
