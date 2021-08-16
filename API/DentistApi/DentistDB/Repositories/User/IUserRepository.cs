using ClassLib.DBModels;
using System;
using System.Collections.Generic;

namespace DentistDB.Repositories.User
{
    public interface IUserRepository
    {
        public List<UserDBModel> GetUsersByIds(List<Guid> ids);
    }
}