using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace Trainer.BL.Services
{
    public sealed class FirebaseService
    {
        public FirebaseAuth AuthApp { get; }

        public FirebaseService()
        {
            var app = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(@"../trainer-app.json")
            });

            AuthApp = FirebaseAuth.GetAuth(app);
        }
    }
}
