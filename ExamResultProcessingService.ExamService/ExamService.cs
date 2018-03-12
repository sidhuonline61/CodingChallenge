using System;
using System.Collections.Generic;
using ExamResultProcessingService.Entities;
using RestSharp;

namespace ExamResultProcessingService.ExamService
{
    public class ExamService : IExamService
    {
        public IRestClient Client { get; }
        public IExamServiceConfiguration ExamServiceConfiguration { get; }

        public ExamService(IRestClient restClient, IExamServiceConfiguration configuration)
        {
            restClient.AssertArgumentIsNotNull("restClient");
            configuration.AssertArgumentIsNotNull("configuration");

            Client = restClient;
            ExamServiceConfiguration = configuration;
        }
        public List<ExamResult> GetExamResults()
        {
            Client.BaseUrl = new Uri(ExamServiceConfiguration.ExamServiceUrl);
            var request = new RestRequest(Method.GET);

            // execute the request
            IRestResponse<List<ExamResult>> examResult = Client.Execute<List<ExamResult>>(request);
            return examResult.Data;
        }
    }
}
