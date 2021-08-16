namespace DentistDB.Repositories.User
{
    using ClassLib.DBModels;
    using Dapper;
    using DentistDB.Services;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class UserRepository : IUserRepository
    {
        private readonly IDapper _dp;

        public UserRepository(IDapper dp)
        {
            _dp = dp;
        }

        public List<UserDBModel> GetUsersByIds(List<Guid> ids)
        {
            return _dp.GetAll<UserDBModel>("GetUsersByIds.sql", new DynamicParameters(new { ids = ids.ToArray() }), CommandType.Text);
        }
    }
}
