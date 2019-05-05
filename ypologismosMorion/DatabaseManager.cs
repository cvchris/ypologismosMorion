using System;
using ypologismosMorion.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using ypologismosMorion.Interfaces;

namespace ypologismosMorion
{
    public class DatabaseManager
    {
        SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<VaseisDBnew> GetAllVaseis()
        {
            return dbConnection.Query<VaseisDBnew>("Select * From [VaseisDB]");
        }
    }
}

    