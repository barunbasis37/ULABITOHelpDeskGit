﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ULABITOHelpDesk.DataAccess.Repository.IRepository
{
    public interface ISP_Call:IDisposable
    {
        //Return Single value 
        T Single<T>(string procedureName, DynamicParameters param = null);
        //Only Add/Delete operation. No return type
        void Execute(string procedureName, DynamicParameters param = null);
        //Return Complete Row value
        T OneRecord<T>(string procedureName, DynamicParameters param = null);
        //Return One Table Value value
        IEnumerable<T>List<T>(string procedureName, DynamicParameters param = null);
        //Return Two Table Value value
        Tuple<IEnumerable<T1>, IEnumerable<T2>>List<T1,T2>(string procedureName, DynamicParameters param = null);
    }
}
