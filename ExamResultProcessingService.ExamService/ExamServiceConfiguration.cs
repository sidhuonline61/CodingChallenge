using System;
using System.Configuration;

namespace ExamResultProcessingService.ExamService
{
    public class ExamServiceConfiguration: IExamServiceConfiguration
    {
        public string ExamServiceUrl
        {
            get
            {
                var setting = ConfigurationManager.AppSettings["ExamServiceUrl"];
                setting.AssertArgumentIsNotNullOrWhiteSpace("ExamServiceUrl", "Setting ExamServiceUrl not found in the configuration");
                return setting;
            }
        }
    }
}
