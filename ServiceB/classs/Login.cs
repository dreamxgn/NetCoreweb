using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ServiceA.Classs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceB.classs
{
    public class Login : Attribute, IFilterFactory
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new LoginCheck();

        }


        private class LoginCheck : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext context)
            {
                //context.Result = new ContentResult() { StatusCode = 200, Content = "" };
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                string token = context.HttpContext.Request.Headers["token"];
                if (token == null || token == "")
                {
                    context.Result = new ContentResult()
                    {
                        Content="Token Is Valid",
                        StatusCode=200
                    };
                    return;
                }

                HttpClient client = new HttpClient();
                string url = "http://localhost:5001/api/user/verify";


                List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
                KeyValuePair<string, string> param = new KeyValuePair<string, string>("token",token);
                data.Add(param);

                FormUrlEncodedContent post = new FormUrlEncodedContent(data);


                string rettoken = client.PostAsync(url, post).Result.Content.ReadAsStringAsync().Result;

                User user= JsonConvert.DeserializeObject<User>(rettoken);
                if (user.Token == null)
                {
                    context.Result = new ContentResult()
                    {
                        Content = "Token Is Valid",
                        StatusCode = 200
                    };
                    return;
                }
                

                

            }
        }

    }
}
