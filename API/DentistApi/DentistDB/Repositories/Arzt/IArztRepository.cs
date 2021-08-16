using ClassLib.DBModels;
using System;
using System.Collections.Generic;

namespace DentistDB.Repositories.Arzt
{
    public interface IArztRepository
    {
        public List<ArztDbModel> GetAerzteByIds(List<Guid> ids);
    }
}