using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace MTREG.medinsur.sjzsyb.bll
{
    static class ConvertDatatable
    {
        /// <summary>
        /// 扩展方法：将List<T>转化为DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable datatable = new DataTable();
            PropertyInfo[] propInfo = typeof(T).GetProperties(BindingFlags.Public|BindingFlags.Instance);
            foreach (var item in propInfo)
            {
                datatable.Columns.Add(item.Name);
            }
            foreach (T item in list)
            {
                var values=new object[propInfo.Length];
                for (int i = 0; i < propInfo.Length; i++)
                {
                    values[i] = propInfo[i].GetValue(item, null);
                }
                datatable.Rows.Add(values);
            }
            return datatable;
        }
    }

    
}
