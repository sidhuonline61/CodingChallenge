using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamResultProcessingService.Entities
{
    public class SortedResult
    {
        public int Year { get; set; }
        public List<string> Subjects { get; set; }
    }
}
