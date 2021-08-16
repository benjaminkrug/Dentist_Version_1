namespace DentistDB.Repositories.Zahn
{
    using Dapper;
    using DentistDB.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class ZahnRepository: IZahnRepository
    {
        private readonly IDapper _dp;

        public ZahnRepository(IDapper dp)
        {
            _dp = dp;
        }

        public void AddZaehne(List<(Guid, string)> ids)
        {
            ids.ForEach(id => AddZahn(id.Item1, id.Item2));
        }
        public void AddZahn(Guid id, string position)
        {

            _dp.Execute("AddZahn.sql", new DynamicParameters(new { id , position }), CommandType.Text);
        }
    }
}
