using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamResultProcessingService.Entities;

namespace ExamResultProcessingService.ProcessingService
{
    public interface IProcessingService
    {
        List<SortedResult> SortPassedResultByYear(List<ExamResult> examResultList);
    }
}
