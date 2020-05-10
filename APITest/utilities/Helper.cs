using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;

namespace APITest.utilities
{
    public static class Helper
    {
        
        //in built json serialzer
        /* var jsonDeseriler = new JsonDeserializer();
        var output= jsonDeseriler.Deserialize<Dictionary<string, string>>(restresponse);
        Console.WriteLine("deswrilazed output is"+output["total"]);*/ 

           
           public static  Dictionary<string, string> Desrialzer(this IRestResponse restResponse)
           {
               var jsonDeseriler = new JsonDeserializer();
               var output =jsonDeseriler.Deserialize<Dictionary<string, string>>(restResponse);
               return output;

           }
           // JObject jObject = new JObject();
           /* JObject jObject = JObject.Parse(restresponse.Content);
            var finaloutput = jObject["total"];
            Console.WriteLine("deswrilazed output is"+finaloutput);*/
         public static string DesearalizeJsonObject( this IRestResponse restResponse,string key)
         {
             var jObject = JObject.Parse(restResponse.Content);
            return jObject[key]?.ToString();
             //return jObject?.ToString();
         }
        

       
    }
}