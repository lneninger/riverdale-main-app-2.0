using Firebase.Database;
using Framework.Autofac;
using System;
using System.Threading.Tasks;

namespace FirebaseRepositories
{

    public class BaseRepository: BaseIoCDisposable
    {

        public BaseRepository()
        {
        }

        protected FirebaseClient CreateFirebaseClient()
        {
            var url = "https://focus-notifications.firebaseio.com/";
            var serverSidePrivateApiKey = "YNU93ZsqgkynJayacZestXBEzhkIzYJOnOM3DYzh";
            var options = new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(serverSidePrivateApiKey)
            };

            var result = new FirebaseClient(url, options);
            return result;
        }
    }
}
