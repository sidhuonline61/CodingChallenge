using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamResultProcessingService.Entities;

namespace ExamResultProcessingService.PrintService
{
    public class PrintService : IPrintService
    {
        public void PrintResults(List<SortedResult> sortedResults)
        {
            if(sortedResults.IsNotNull())
            {
                foreach (var examYearResult in sortedResults)
                {
                    Console.WriteLine($"{examYearResult.Year}");
                    foreach (var subject in examYearResult.Subjects)
                    {
                        Console.WriteLine($"\t {subject}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Results to display.");
            }
        }
    }
}
