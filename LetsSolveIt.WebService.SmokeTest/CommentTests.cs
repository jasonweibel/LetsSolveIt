using System;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LetsSolveIt.WebService.SmokeTest
{
    [TestClass]
    public class CommentTests
    {

        public const string ApiUrlRoot = "http://localhost:33625/api/";
        public const string resource = "";


        private WebClient CreateWebClient()
        {
            var webClient = new WebClient();

            //const string creds = "jbob" + ":" + "jbob12345";
            //var bcreds = Encoding.ASCII.GetBytes(creds);
            //var base64Creds = Convert.ToBase64String(bcreds);
            //webClient.Headers.Add("Authorization", "Basic " + base64Creds); // amJvYjpqYm9iMTIzNDU=

            //webClient.Headers.Add();

            return webClient;
        }

        [TestMethod]
        public void GetComment()
        {
            var client = CreateWebClient();
            var response = client.DownloadString(ApiUrlRoot + "Comment");
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCommentById()
        {
            var client = CreateWebClient();
            var response = client.DownloadString(ApiUrlRoot + "Comment\\1");
            Assert.IsNotNull(response);
        }

        //[TestMethod]
        //public void GetCommentById()
        //{
        //    var client = CreateWebClient();
        //    var response = client.DownloadString(ApiUrlRoot + "Comment\\1");
        //    Assert.IsNotNull(response);
        //}

    }
}
