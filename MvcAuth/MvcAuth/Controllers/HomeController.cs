using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MvcAuth.Models;
using System.IO;

using System.Text;
using Newtonsoft.Json;
using MvcAuth.Services;

namespace MvcAuth.Controllers
{   
    [RequireHttps]
    public class HomeController : Controller
    {

        private readonly IEmailSender _sender;

        public HomeController(IEmailSender sender)        
        {
            _sender = sender;

        }


       public IActionResult Index()
        {
            Teste();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private void Teste()
        {

            var retorno =  _sender.SendEmailAsync("teste@teste.com.br", "teste", "teste");
            

            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic ZjQ4ZjdiZDMtNmY5ZC00N2YxLWE1MzYtYTY1ZTQxOGQ5YWNh");

            var serializer = new JsonSerializer();
            var obj = new
            {
                app_id = "78dd4fec-88fc-476d-8ee9-776c0a8c96ae",
                contents = new { en = "English Message" },
                included_segments = new string[] { "All" }
            };
            //var param = serializer.Serialize(obj);

            var json = JsonConvert.SerializeObject(obj);

            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
        }



    }

    

}
