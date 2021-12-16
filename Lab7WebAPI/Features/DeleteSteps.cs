using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;

namespace Lab7WebAPI.Features
{
    [Binding]
    public class DeleteSteps
    {
        [Given(@"(.*) is uploaded to Dropbox"), Scope(Feature = "Delete")]
        public void GivenIsUploadedToDropbox(string p0)
        {
            RequestBuilder b = new DeleteFile();
            Request req = new Request(b);
            var headers = new List<Header> {
                new Header("Content-Type", "application/json"),
                };
            req.Build(p0, headers);
            BaseSteps.request = b.Get();
        }
    }
}
