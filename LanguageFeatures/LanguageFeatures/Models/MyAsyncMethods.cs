using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();

            //Task objects are strongly typed based on the result
            //that the background work produces
            //the HttpClient.GetAsync method returns a 
            //Task<HttpResponseMessage>
            //the request will be performed in the backgrounf and the 
            //result of the request will be an HttpResponseMessage
            var httpTask = client.GetAsync("http://apress.com");

            //here we specify what we want to happen when the task is complete
            //we use the ContinueWith method and we process the
            //HttpResponseMessage object that we recieve from HttpClient.GetAsync
            //we do a lamda expression which returns the desired value
            return httpTask.ContinueWith(
                (Task<HttpResponseMessage> antecedent) =>
                {
                    return antecedent.Result.Content.Headers.ContentLength;
                });
        }
    }
}
