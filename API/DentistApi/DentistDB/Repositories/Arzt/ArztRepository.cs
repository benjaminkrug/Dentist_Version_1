namespace DentistDB.Repositories.Arzt
{
    using ClassLib.DBModels;
    using Dapper;
    using DentistDB.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class ArztRepository : IArztRepository
    {
        private readonly IDapper _dp;

        public ArztRepository(IDapper dp)
        {
            _dp = dp;
        }

        public List<ArztDbModel> GetAerzteByIds(List<Guid> ids)
        {
            return _dp.GetAll<ArztDbModel>("GetAerzteByIds.sql", new DynamicParameters(new { ids = ids.ToArray() }), CommandType.Text);
        }
    }
}
