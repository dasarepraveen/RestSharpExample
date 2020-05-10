using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using APITest.Models;
using APITest.utilities;

using RestSharp;
using RestSharp.Serialization.Json;


namespace APITest
{
    
    [TestFixture]
    public class TestWithdata
    {
        private RestClient _restClient;

        private RestRequest _restRequest;
       

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient("https://api.zippopotam.us");
        }
        
        [TestCase("IN","110001",HttpStatusCode.OK, TestName = "Check status codr for In with zip id")]
        [TestCase("AU","2140",HttpStatusCode.OK, TestName = "Check status code for AU with zip 2140")]
        public void TypeClass(string countryCode,string pinCode,HttpStatusCode expectedStatusCode)
        {
            //_restRequest = new RestRequest("/us/90210",Method.GET);
            _restRequest = new RestRequest($"{countryCode}/{pinCode}",Method.GET);
            
            var response =_restClient.Execute(_restRequest);
           
          Assert.That(response.StatusCode,Is.EqualTo(expectedStatusCode));


        }
        
        
        [Test]
        
        [TestCaseSource("placesTestData")]
        public void Test_WithTestCaseSourceData(string countryCode,string pinCode,string placeName)
        {
            //_restRequest = new RestRequest("/us/90210",Method.GET);
            _restRequest = new RestRequest($"{countryCode}/{pinCode}",Method.GET);
            
            var response =_restClient.Execute(_restRequest);

            new JsonDeserializer().Deserialize<Locationresponse>(response);
            
            var output = response.Desrialzer();

            // Assert.That(response.StatusCode,Is.EqualTo(expectedStatusCode));


        }

        private static IEnumerable<TestCaseData> placesTestData()    
        {
            yield return new TestCaseData("au","2140","Hombush").SetName("Check status code for AU with zip 2140");
        }
       
        
    }
}