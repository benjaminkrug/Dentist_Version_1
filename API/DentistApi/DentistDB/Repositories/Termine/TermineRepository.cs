namespace DentistDB.Repositories.Termine
{
    using ClassLib.DBModels;
    using Dapper;
    using DentistDB.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class TermineRepository : ITermineRepository
    {
        private readonly IDapper _dp;

        public TermineRepository(IDapper dp)
        {
            _dp = dp;
        }

        public void AddTermin(TerminDbModel terminDbModel)
        {
            terminDbModel.Id = Guid.NewGuid();
            _dp.Execute("AddTermin.sql", new DynamicParameters(terminDbModel), CommandType.Text);
        }

        public List<TerminDbModel> GetAllTermineByTimeRange(DateTime startDate, DateTime endDate)
        {
            return _dp.GetAll<TerminDbModel>("GetAllTermineByTimeRange.sql", new DynamicParameters(new { 
                startDate = startDate.Date,
                endDate = endDate.Date,
                startTime = startDate.TimeOfDay,
                endTime = endDate.TimeOfDay
            }), CommandType.Text);
        }

        public List<TerminTypDBModel> GetAllTerminTyps()
        {
            return _dp.GetAll<TerminTypDBModel>("GetAllTerminTyps.sql", null, CommandType.Text);
        }
    }
}
