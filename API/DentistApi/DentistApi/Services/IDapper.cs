
using Dapper;  

namespace Services
{  
    using System;    
    using System.Collections.Generic;    
    using System.Data;    
    using System.Data.Common;    
    using System.Linq;    
    using System.Threading.Tasks;   
    
    public interface IDapper
    {
        
        DbConnection GetDbconnection();    
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);    
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        void Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);    
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);    
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);    
    }
}