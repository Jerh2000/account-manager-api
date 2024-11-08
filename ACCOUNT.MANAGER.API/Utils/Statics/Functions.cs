﻿using ACCOUNT.MANAGER.API.ViewModels;
using System.Data;
using System.Reflection;

namespace ACCOUNT.MANAGER.API.Utils.Statics
{
    public class Functions
    {
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var p in properties)
                {
                    if (columnNames.Contains(p.Name.ToLower()))
                    {
                        try
                        {
                            p.SetValue(objT, row[p.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }

        public static T ConvertToEntity<T>(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return Activator.CreateInstance<T>();
            }

            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var p in properties)
                {
                    if (columnNames.Contains(p.Name.ToLower()))
                    {
                        try
                        {
                            p.SetValue(objT, row[p.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).First();
        }

        public static DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static ApiResponse<T> ReturnResponseOK<T>(T modelo, string message)
        {
            return new ApiResponse<T>
            {
                Data = modelo,
                Response = true,
                Message = message,
                Codigo = "200"
            };
        }

        public ApiResponse<T> ReturnResponseBad<T>(T modelo, string message)
        {
            return new ApiResponse<T>
            {
                Data = modelo,
                Response = false,
                Message = message,
                Codigo = "400"
            };
        }

        public static object ReturnResponseError(string message)
        {
            return new 
            {               
                Data = new string[0],
                Response = false,
                Message = message,
                Codigo = "500"
            };
        }
    }
}
