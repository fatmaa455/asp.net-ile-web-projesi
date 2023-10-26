using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using CamlicaProje1.Models;
using System.Linq;

namespace CamlicaProje1.Controllers
{
    public class DefaultController : Controller
    {
        CAMLICAEntities model = new CAMLICAEntities();

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetData()
        {
            string apiUrl = "#";
            
            // using bloğunun sonunda client nesnesi otomatik olarak kapatılır ve sızıntılar önlenir
            using (HttpClient client = new HttpClient())
            {
                var tokenUrl = "#";
                
                var dataList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "#"),
                    new KeyValuePair<string, string>("password", "#"),
                };

                // işlem asenkron bir işlemdir , cevap gelmesi beklendiği için await kullanılmıştır
                var response2 = await client.PostAsync(tokenUrl, new FormUrlEncodedContent(dataList));

                //if (response2.IsSuccessStatusCode)
                
                    var responseContent = await response2.Content.ReadAsStringAsync();

                    RootToken coz = JsonConvert.DeserializeObject<RootToken>(responseContent);

                    string accessToken = coz.access_token;
                
               
                client.DefaultRequestHeaders.Add("Authorization","Bearer " + accessToken);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var data = JsonConvert.DeserializeObject(jsonContent);

                        var data2 = JsonConvert.DeserializeObject<List<MyArray>>((string)data);

                        return Json(data2, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                       throw;
                    }
                }
                
                else
                {
                    ViewBag.ErrorMessage = "Error";
                    return View();
                }
                
            }
        }
    }
}



public class Barkodlar
{
#
}

public class MyArray
{
#
}

public class Root
{
#
}

public class RootToken
{
#
}
