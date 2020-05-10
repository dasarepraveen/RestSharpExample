using System;
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
    public class TestSrc
    {
        private RestClient _restClient;

        private RestRequest _restRequest;
       

        [SetUp]
        public void SetUp()
        {
            _restClient = new RestClient("https://api.zippopotam.us");
        }
        
        
        [Test,TestCaseSource("placesTestData")]
        public void Test_WithTestCaseSourceData(string countryCode,string pinCode,string placeName)
        {
            
            _restRequest = new RestRequest($"{countryCode}/{pinCode}",Method.GET);
            
            var response =_restClient.Execute(_restRequest);

            var output =new JsonDeserializer().Deserialize<Locationresponse>(response);

            Assert.That(output.Places[0].PlaceName,Is.EqualTo(placeName));
            
            Console.WriteLine("output would be {0}",output.Places[0].PlaceName);
           // Console.WriteLine("output would be {0}",output.Places[1].PlaceName);
            
            //Assert.That(output..PlaceName,Is.EqualTo(placeName));


        }

        private static IEnumerable<TestCaseData> placesTestData()    
        {
            yield return new TestCaseData("au","2140","Homebush").SetName("Check status code for AU with zip 2140");
        }
       
        
    }
}