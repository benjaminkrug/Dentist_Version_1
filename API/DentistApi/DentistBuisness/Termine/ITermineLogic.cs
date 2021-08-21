using ClassLib.DTO;
using System;
using System.Collections.Generic;

namespace DentistBuisness.Termine
{
    public interface ITermineLogic
    {
        public List<TermineTableDto> GetAllTermineByTimeRange(DateTime startDate, DateTime endDate);
        void AddTermin(TermineTableDto status);
    }
}