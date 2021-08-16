using System;
using System.Collections.Generic;

namespace DentistDB.Repositories.Zahn
{
    public interface IZahnRepository
    {
        void AddZaehne(List<(Guid, string)> guids);
        void AddZahn(Guid id, string position);
    }
}