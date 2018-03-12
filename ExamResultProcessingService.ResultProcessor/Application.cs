using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamResultProcessingService.Entities;
using ExamResultProcessingService.ExamService;
using ExamResultProcessingService.PrintService;
using ExamResultProcessingService.ProcessingService;

namespace ExamResultProcessingService.ResultProcessor
{
    public class Application : IApplication
    {
        private readonly IExamService _examService;
        private readonly IPrintService _printService;
        private readonly IProcessingService _processingService;
        public Application(IExamService examService, IPrintService printService, IProcessingService processingService)
        {
            _examService = examService;
            _printService = printService;
            _processingService = processingService;
        }

        public void ProcessResults()
        {
            try
            {
                var examResults = _examService.GetExamResults();
                var sortedResults = _processingService.SortPassedResultByYear(examResults);
                _printService.PrintResults(sortedResults);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                if(ex.InnerException.IsNotNull())
                    Console.WriteLine(ex.InnerException.Message);
            }
            
        }
    }
}
