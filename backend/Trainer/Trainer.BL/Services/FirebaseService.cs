using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.IO;

namespace Trainer.BL.Services
{
    public sealed class FirebaseService
    {
        public FirebaseAuth AuthApp { get; }

        public FirebaseService()
        {
            var file = new DirectoryInfo(Environment.CurrentDirectory).GetFiles("trainer-app.json")[0];

            if (file == null)
                throw new Exception("There is no Credential file!");

            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(file.FullName)
            });

            AuthApp = FirebaseAuth.GetAuth(app);
        }
    }
}
