using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamResultProcessingService.Entities;

namespace ExamResultProcessingService.PrintService
{
    public interface IPrintService
    {
        void PrintResults(List<SortedResult> sortedResults);
    }
}
