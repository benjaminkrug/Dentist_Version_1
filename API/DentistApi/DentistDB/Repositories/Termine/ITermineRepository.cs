using ClassLib.DBModels;
using System;
using System.Collections.Generic;

namespace DentistDB.Repositories.Termine
{
    public interface ITermineRepository
    {
        public List<TerminTypDBModel> GetAllTerminTyps();
        List<TerminDbModel> GetAllTermineByTimeRange(DateTime startDate, DateTime endDate);
    }
}