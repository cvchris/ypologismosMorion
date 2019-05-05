using System;
using System.Collections.Generic;
using System.Text;

namespace ypologismosMorion.Interfaces
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
