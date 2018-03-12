using System;
using Autofac;
using RestSharp;
using ExamResultProcessingService.ExamService;
using ExamResultProcessingService.PrintService;
using ExamResultProcessingService.ProcessingService;

namespace ExamResultProcessingService.ResultProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.ProcessResults();
            }
            Console.ReadKey();
        }

        public static class ContainerConfig
        {
            public static IContainer Configure()
            {
                var builder = new ContainerBuilder();

                builder.RegisterType<Application>().As<IApplication>();
                builder.RegisterType<ExamServiceConfiguration>().As<IExamServiceConfiguration>().SingleInstance();
                builder.RegisterType<ExamService.ExamService>().As<IExamService>().SingleInstance();
                builder.RegisterType<PrintService.PrintService>().As<IPrintService>().SingleInstance();
                builder.RegisterType<ProcessingService.ProcessingService>().As<IProcessingService>().SingleInstance();
                builder.RegisterType<RestClient>().As<IRestClient>().InstancePerDependency(); ;

                return builder.Build();
            }
        }
    }
}
