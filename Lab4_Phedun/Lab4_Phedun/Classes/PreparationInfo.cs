using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_Phedun.Classes
{
    internal class PreparationInfo
    {
        public PreparationInfo(string startDate, string endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
