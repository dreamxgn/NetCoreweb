using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoPolly
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WaitRetry();
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错了");
            }
            Console.ReadKey();
        }

        public static int random = 10;
        public static int DivideByZero(int random)
        {
            //int a = 0;
            if (random != 25) random = 0;
            return 100 / random;
        }


        public static void Retry()
        {
            Policy.Handle<Exception>().Retry(1,(ex,count)=> {
                Console.WriteLine("Retry: {0}", count);
            }).Execute(() => {
                Console.WriteLine("获取网络数据");
                HttpClient client = new HttpClient();
                string s1 = client.GetStringAsync("http://localhost:9090").Result;
            });
        }

        /// <summary>
        /// 等待多少秒重试
        /// </summary>
        public static void WaitRetry()
        {
            Policy.Handle<Exception>().WaitAndRetry(new[] {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(3)
            },(ex,tp)=> {
                Console.WriteLine("等待: {0} 秒重试", tp.Seconds);
            }).Execute(() =>
            {
                Console.WriteLine("获取网络数据");
                HttpClient client = new HttpClient();
                string s1 = client.GetStringAsync("http://localhost:9090").Result;
            });
        }
    }
}
