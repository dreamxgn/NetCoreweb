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
            Retry();
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
            Policy.Handle<Exception>().Retry(3,(ex,count)=> {
                Console.WriteLine("Retry: {0}", count);
            }).Execute(() => {
                Console.WriteLine("aaaaaaaaaaaaaaaaa");
                HttpClient client = new HttpClient();
                string s1 = client.GetStringAsync("http://localhost:9090").Result;
            });
        }
    }
}
