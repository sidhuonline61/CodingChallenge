using System.Collections.Generic;
using ExamResultProcessingService.Entities;

namespace ExamResultProcessingService.ExamService
{
    public interface IExamService
    {
        List<ExamResult> GetExamResults();
    }
}
