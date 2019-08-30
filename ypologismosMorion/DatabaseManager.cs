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

        public List<VaseisDBnewWithPedio> GetAllVaseis(int etos)
        {
            var protopedio = dbConnection.Query<VaseisDBnewWithPedio>("Select * From [1opedio" + etos.ToString() + "]");
            var deuteropedio = dbConnection.Query<VaseisDBnewWithPedio>("Select * From [2opedio" + etos.ToString() + "]");
            var tritopedio = dbConnection.Query<VaseisDBnewWithPedio>("Select * From [3opedio" + etos.ToString() + "]");
            var tetartopedio = dbConnection.Query<VaseisDBnewWithPedio>("Select * From [4opedio" + etos.ToString() + "]");

            foreach(var item in protopedio)
            {
                item.Pedio = 1;
            }
            foreach (var item in deuteropedio)
            {
                item.Pedio = 2;
            }
            foreach (var item in tritopedio)
            {
                item.Pedio = 3;
            }
            foreach (var item in tetartopedio)
            {
                item.Pedio = 4;
            }

            var vaseis = new List<VaseisDBnewWithPedio>();
            vaseis.AddRange(protopedio);
            vaseis.AddRange(deuteropedio);
            vaseis.AddRange(tritopedio);
            vaseis.AddRange(tetartopedio);

            var yy = vaseis.GroupBy(elem => elem.Mixanografiko).Select(group => group.First()).ToList();

            var z = yy.OrderByDescending(x=> x.vasi).ToList();

            return z;
        }

        public List<VaseisDBnewWithPedio> GetVaseis(int pedio, int etos = 2019)
        {
            var data =  dbConnection.Query<VaseisDBnewWithPedio>("Select * From [" + pedio + "opedio" + etos.ToString() + "]");
            foreach(var item in data)
            {
                item.Pedio = pedio;
            }
            return data;

        }

        public VaseisDBnew GetVasi(int kodikosMixanografikou, int pedio, int etos)
        {
            
            var query = "SELECT * FROM [" + pedio + "oPedio" + etos.ToString() + "] WHERE Mixanografiko =" + kodikosMixanografikou.ToString();
            var aa = dbConnection.Query<VaseisDBnew>(query);
            if(aa.Count > 0)
            {
                return aa[0];
            }
            else
            {
                return null;
            }
        }

        public List<int> SePoiaPediaAnikei(int kodikosMixanografikou, int etos)
        {
            List<int> exists = new List<int>();
            for(int i=1;i<5;i++)
            {
                var query = "SELECT * FROM [" + i.ToString() + "oPedio" + etos.ToString() + "] WHERE Mixanografiko =" + kodikosMixanografikou.ToString();
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

    