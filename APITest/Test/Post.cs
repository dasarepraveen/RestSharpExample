using System;
using System.Collections.Generic;
using System.ComponentModel;
using APITest.Models;
using APITest.utilities;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace APITest
{
    [TestFixture]
    public class Post
    {
        private RestClient _restClient;

        private RestRequest _restRequest;
        
       

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient("http://dummy.restapiexample.com/");
        }

        [Test]
        public void PutCall()
        {
           // _restRequest = new RestRequest("api/v1/update/id",Method.PUT);
            _restRequest = new RestRequest("api/v1/update/21",Method.PUT);
            _restRequest.AddJsonBody
            (new{ name="test1",salary="1123",age="23"});
            var restResponse = _restClient.Execute(_restRequest);
           // restResponse.DesearalizeJsonObject("status");
            var updateresponse =Helper.DesearalizeJsonObject(restResponse, "status");
            //var updateresponse =Helper.DesearalizeJsonObject(restResponse, "status");
            var name =JObject.Parse(updateresponse);
            Assert.That(name["name"],Is.EqualTo("updating name"));
        }

        [Test]
        public void PostMethodWithGenericClass()
        {
            _restRequest = new RestRequest("/api/v1/create", Method.POST);
            var xyz=   _restRequest.AddJsonBody(new
            {
                name ="test",
                salary ="123",
                age="231"
            });
            var response = _restClient.Execute(_restRequest);
            
            
            var output =new JsonDeserializer().Deserialize<status>(response);

            Console.WriteLine("post response dat name is {0}",output.Data.Name);
            Assert.That(output.Data.Name,Is.EqualTo("test"));

            
        }
        
        [Test]
        public void PostMethodExample()
        {
            _restRequest = new RestRequest("/api/v1/create", Method.POST);
            var xyz=   _restRequest.AddJsonBody(new
            {
                name ="test",
                salary ="123",
                age="231"
            });
            var response = _restClient.Execute(_restRequest);
            
            Console.WriteLine("The response is {0}",response.Content);
            
            var desearilazedresponse = Helper.DesearalizeJsonObject(response, "status");
            Assert.That(desearilazedresponse.ToString(), Is.EqualTo("success"));
            
           var desearilazedresponsefromJsom = Helper.Desrialzer(response);
           Console.WriteLine("the data isd {0}",desearilazedresponsefromJsom["data"].ToString());
            
           // A
            
           desearilazedresponse = Helper.DesearalizeJsonObject(response, "data");
            var name =JObject.Parse(desearilazedresponse);
            Console.WriteLine("name is {0}",name["name"]);
            var id = name["id"].ToString();
           //int id = Int32.Parse(id1);
           Console.WriteLine("printing id from response{0}",id);
           Assert.That(name["name"]?.ToString(),Is.EqualTo("test"),"Not equal to test");
          







           /*var jsonDeseriler = new JsonDeserializer();
           var output= jsonDeseriler.Deserialize<Dictionary<string, string>>(response);
           Assert.That((int)response.StatusCode,Is.EqualTo(200));*/







           /*  var desearilazedresponse = Helper.Desrialzer(response);
             var finalop = desearilazedresponse["status"];
             //var desearilazedresponse = Helper.DesearalizeJsonObject(response, "status");
             Console.WriteLine("content is{0}",response.Content);
             Assert.That((int)response.StatusCode,Is.EqualTo(200));
             //Assert.That(desearilazedresponse,Is.EqualTo("success"));*/
           
           
        }

       
        
    }
}