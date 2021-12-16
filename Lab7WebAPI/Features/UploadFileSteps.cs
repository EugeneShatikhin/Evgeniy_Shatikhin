using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;
namespace Lab7WebAPI.Features
{
    [Binding]
    public class UploadFileSteps
    {
        [Given(@"I have some (.*) i want to upload to (.*)"), Scope(Feature = "UploadFile")]
        public void GivenIHaveSomeIWantToUploadTo(string p0, string p1)
        {
            RequestBuilder b = new UploadFile();
            Request req = new Request(b);
            var headers = new List<Header> {
                new Header("Dropbox-API-Arg", "{\"path\":\"" + p1 + "\",\"mode\":\"add\"}"),
                new Header("Content-Type", "application/octet-stream"),
                };
            req.Build(p0, headers);
            BaseSteps.request = b.Get();
        }
    }
}
