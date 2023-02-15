using Firebase.Auth;
using Refit;
using System;
using System.Threading.Tasks;

namespace FirebaseAuthenticationDemo
{
    class Program
    {
        private const string API_KEY = "AIzaSyB9CTWLPo-SbLiumophIuoHvidy5kRMO4c";
        static async Task Main(string[] args)
        {
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("singleton@gmail.com", "test123");
            Console.WriteLine(firebaseAuthLink.FirebaseToken);

            IDataService dataService=RestService.For<IDataService>("Http://local:5000");
            await dataService.GetData(firebaseAuthLink.FirebaseToken);
        }
    }

    public interface IDataService
    {
        [Get("/")]
        Task GetData([Authorize("Bearer ")] string token);
    }
}
