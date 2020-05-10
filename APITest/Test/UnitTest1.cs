using System;
using System.Collections.Generic;
using APITest.utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace APITest
{
    [TestFixture]
    public class Tests
    {
        private RestClient _restClient;

        private RestRequest _restRequest;
       

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient("https://reqres.in");
        }
        [Test]

        public void Practise()
        {
            // restClient = new RestClient("https://reqres.in");
            _restRequest = new RestRequest("/api/users/2",Method.GET);
            var code = _restClient.Execute(_restRequest).Content;
            Console.WriteLine("The response content is "+code);
        }
        
        

        [Test]
        public void Test1()
        {
             //_restClient = new RestClient("https://reqres.in");
             _restRequest = new RestRequest("api/users?page=2",Method.GET);
            var result = _restClient.Execute(_restRequest).Content;
           // Assert.Pass();
           Console.WriteLine("*** response"+result);
        }
        [Test]

        public void verifyTotalnoOfrecords()
        {
           
            _restRequest = new RestRequest("api/users?page=2",Method.GET);
            var restresponse = _restClient.Execute(_restRequest);
            
          
           var finalOutput =Helper.Desrialzer(restresponse);
          Console.WriteLine("response deseralized ffrom inbuilt seraizer is {0}",finalOutput["total"]);
           
           //jobject newtonsoft

           var outfromNewtonsoftJson =Helper.DesearalizeJsonObject(restresponse,"total");
          Console.WriteLine("from newtonsoft json helper{0}",outfromNewtonsoftJson);
          Assert.That(outfromNewtonsoftJson,Is.EqualTo("12"),"the total record didn't match");

        }

        [Test]
        public void AssertPage()
        {
           // _restClient = new RestClient("https://reqres.in");
             _restRequest = new RestRequest("api/users?page=2",Method.GET);
            var result = _restClient.Execute(_restRequest);
            
            JObject jsonparser = JObject.Parse(result.Content);
            var pagenumber = jsonparser["page"];
            Assert.That(pagenumber?.ToString(),Is.EqualTo("2"),"Page number didn't match");
        }

        [Test]
        public void testPostMethod()
        {
            _restRequest=new RestRequest("api/users",Method.POST);
            _restRequest.AddJsonBody(new
            {
                name = "morpheus",
                job = "leader"
            });
            var result =_restClient.Execute(_restRequest);
            var resultt =result.DesearalizeJsonObject("name");
           // var resultt = Helper.DesearalizeJsonObject(result, "name");
            
            Console.WriteLine("output is {0}",resultt.ToString());
            Assert.That(resultt.ToString(),Is.EqualTo("morpheus"));
            Assert.That(result.StatusCode.ToString(),Is.EqualTo("Created"));

        }

       
        
        
        

        [TearDown]
        public void Quit()
        {
            Console.WriteLine("Executed all the Tets");
        }
    }
}