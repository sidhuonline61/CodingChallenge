using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamResultProcessingService.Entities;

namespace ExamResultProcessingService.ProcessingService
{
    public class ProcessingService : IProcessingService
    {
        public List<SortedResult> SortPassedResultByYear(List<ExamResult> examResultList)
        {
            List<SortedResult> finalResult = new List<SortedResult>();
            if (examResultList.IsNotNull())
            {
                finalResult = examResultList.SelectMany(s => s.results.Where(x => x.grade == "PASS")
                                                .Select(p => new
                                                {
                                                    p.year,
                                                    s.subject
                                                }))
                // Group results by year
               .GroupBy(cs => cs.year)
               // Sort subject inside each year.
               .Select(group => new SortedResult
               {
                   Year = group.Key,
                   Subjects = group.OrderBy(x => x.subject).Select(s => s.subject).ToList()
               })
               // Order grouped result by year
               .OrderBy(c => c.Year)
               .ToList();
            }
            else
            {
                Console.WriteLine("ExamResult is parameter is blank.");
            }
            return finalResult;
        }
    }
}
