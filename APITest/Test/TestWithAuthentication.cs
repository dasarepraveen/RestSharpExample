using NUnit.Framework;
using System;
using System.Collections.Generic;
using APITest.Models;
using APITest.utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;

namespace APITest
{
    
    [TestFixture]
    public class TestWithAuthentication
    {
        private RestClient _restClient;

        private RestRequest _restRequest;
       

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient("https://reqres.in");
        }
        [Test]
        public void GetWithAuthentication()
        {
            /*_restClient.Authenticator = new HttpBasicAuthenticator("eve.holt@reqres.in", "cityslicka");
            _restRequest = new RestRequest("https://reqres.in/api/login", Method.GET);

            var responses = _restClient.Execute(_restRequest);
            //  Console.WriteLine("Status Code: " + response.Content);
            //Console.WriteLine("Status Code: " + (int) response.StatusCode);
            Assert.That((int)responses.StatusCode, Is.EqualTo("200"));*/
            
            
            _restClient.Authenticator = new HttpBasicAuthenticator("eve.holt@reqres.in","cityslicka");
            _restRequest = new RestRequest("https://reqres.in/api/login",Method.GET);
            var response = _restClient.Execute(_restRequest);
            Assert.That((int)response.StatusCode,Is.EqualTo(200));

        }
        [Test]
        public void TypeClass()
        {
            _restRequest = new RestRequest("/api/register",Method.POST);
            _restRequest.AddJsonBody(new Users()
            { email = "eve.holt@reqres.in",password ="pistol"} ) ;
            var response =_restClient.Execute(_restRequest);
            var finalOutput = Helper.DesearalizeJsonObject(response, "token");
            Console.WriteLine("token is {0}",finalOutput);
            Assert.That(finalOutput,Is.EqualTo("QpwL5tke4Pnpja7X4"),"isn't equal");


        }
        [Test]
        public void UsingTypeClass()
        {
            _restRequest = new RestRequest("/api/register",Method.POST);
            _restRequest.AddJsonBody(new Users {email = "eve.holt@reqres.in",password ="pistol" });
            var restResponse = _restClient.Execute<Users>(_restRequest);
            Assert.That(restResponse.Data.token,Is.EqualTo("QpwL5tke4Pnpja7X4"));
          //  Console.WriteLine("id is",restResponse.Data.id.ToString());
            Assert.That(restResponse.Data.id,Is.EqualTo(4));
        }
        
    }
}