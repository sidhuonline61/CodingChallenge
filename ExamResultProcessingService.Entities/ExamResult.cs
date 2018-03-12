using System.Collections.Generic;

namespace ExamResultProcessingService.Entities
{
    public class Result
    {
        public int year { get; set; }
        public string grade { get; set; }
    }

    public class ExamResult
    {
        public string subject { get; set; }
        public List<Result> results { get; set; }
    }
}
