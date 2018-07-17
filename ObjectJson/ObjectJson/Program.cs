using System;
using Newtonsoft.Json.Linq;

namespace ObjectJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{
              CPU: 'Intel',
              Drives: [
                'DVD read/writer',
                '500 gigabyte hard drive'
              ]
            }";

            JObject o = JObject.Parse(json);

           

            Console.WriteLine( o["CPU"].ToString());
            Console.ReadKey();

        }
    }
}
