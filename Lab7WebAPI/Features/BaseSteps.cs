﻿using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;

namespace Lab7WebAPI.Features
{
    [Binding]
    public class BaseSteps
    {
        public static RestRequest request;
        public static RestClient client;
        public static RestResponse response;
        [When(@"I send POST request to Dropbox (.*)")]
        public void WhenISendPOSTRequestToDropbox(string p0)
        {
            client = new RestClient(p0);
            response = (RestResponse)client.Post(request);
        }

        [Then(@"I should get response ""(.*)""")]
        public void ThenIShouldGetResponse(string p0)
        {
            var res = response.StatusCode;
            Assert.True(res == System.Net.HttpStatusCode.OK, response.StatusCode.ToString());
        }
    }
}
