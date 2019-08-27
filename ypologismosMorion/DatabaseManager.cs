using System;
using ypologismosMorion.Models;
using SQLite;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
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

        public List<VaseisDBnew> GetAllVaseis2019()
        {
            var protopedio = dbConnection.Query<VaseisDBnew>("Select * From [1opedio2019]");
            var deuteropedio = dbConnection.Query<VaseisDBnew>("Select * From [2opedio2019]");
            var tritopedio = dbConnection.Query<VaseisDBnew>("Select * From [3opedio2019]");
            var tetartopedio = dbConnection.Query<VaseisDBnew>("Select * From [4opedio2019]");

            var vaseis2019 = new List<VaseisDBnew>();
            vaseis2019.AddRange(protopedio);
            vaseis2019.AddRange(deuteropedio);
            vaseis2019.AddRange(tritopedio);
            vaseis2019.AddRange(tetartopedio);

            var yy = vaseis2019.GroupBy(elem => elem.Mixanografiko).Select(group => group.First()).ToList();

            var z = yy.OrderByDescending(x=> x.vasi).ToList();

            return z;
        }

        public List<VaseisDBnew> GetVaseis(int pedio, int etos = 2019)
        {
            return dbConnection.Query<VaseisDBnew>("Select * From [" + pedio + "opedio2019]");

        }

        public List<int> SePoiaPediaAnikei(int kodikosMixanografikou, int etos =2019)
        {
            List<int> exists = new List<int>();
            for(int i=1;i<5;i++)
            {
                var query = "SELECT * FROM [" + i.ToString() + "oPedio2019] WHERE Mixanografiko =" + kodikosMixanografikou.ToString();
                var e = dbConnection.Query<VaseisDBnew>(query);
                if (e.Count > 0)
                {
                    exists.Add(i);
                }
            }
            return exists;
        }


    }
}

    