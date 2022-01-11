using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.IO;
namespace Lab7WebAPI.Features
{
    static class Authorization
    {
        public static string Token = "Bearer ";
    }
    class Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Header(string k, string v)
        {
            Key = k;
            Value = v;
        }
    }
    abstract class RequestBuilder
    {
        public abstract void AddBody(string path);
        public abstract void SetAuth();
        public abstract void AddHeaders(List<Header> h);
        public abstract RestRequest Get();
    }
    class UploadFile : RequestBuilder
    {
        public RestRequest Req = new RestRequest();
        public override void SetAuth()
        {
            Req.AddHeader("Authorization", Authorization.Token);
        }
        public override void AddBody(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            long fileLength = fileInfo.Length;
            Req.AddHeader("Content-Length", fileLength.ToString());
            byte[] data = File.ReadAllBytes(path);
            var body = new Parameter("file", data, ParameterType.RequestBody);
            Req.Parameters.Add(body);
        }
        public override void AddHeaders(List<Header> h)
        {
            foreach (var header in h)
            {
                Req.AddHeader(header.Key, header.Value);
            }
        }
        public override RestRequest Get()
        {
            return Req;
        }
    }
    class GetMetadata : RequestBuilder
    {
        public RestRequest Req = new RestRequest();
        public override void SetAuth()
        {
            Req.AddHeader("Authorization", Authorization.Token);
        }
        public override void AddBody(string path)
        {
            Req.AddJsonBody(new{file = path});
        }
        public override void AddHeaders(List<Header> h)
        {
            foreach (var header in h)
            {
                Req.AddHeader(header.Key, header.Value);
            }
        }
        public override RestRequest Get()
        {
            return Req;
        }
    }
    class DeleteFile : RequestBuilder
    {
        public RestRequest Req = new RestRequest();
        public override void SetAuth()
        {
            Req.AddHeader("Authorization", Authorization.Token);
        }
        public override void AddBody(string path)
        {
            Req.AddJsonBody(new { path = path });
        }
        public override void AddHeaders(List<Header> h)
        {
            foreach (var header in h)
            {
                Req.AddHeader(header.Key, header.Value);
            }
        }
        public override RestRequest Get()
        {
            return Req;
        }
    }
    class Request
    {
        public RequestBuilder builder;
        public Request (RequestBuilder rb)
        {
            this.builder = rb;
        }
        public RestRequest Build(string body, List<Header> headers)
        {
            builder.SetAuth();
            builder.AddBody(body);
            builder.AddHeaders(headers);
            return builder.Get();
        }
    }


}
