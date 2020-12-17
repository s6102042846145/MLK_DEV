using AHCBL.Component.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dao
{
    public class BaseDao<T> where T : new()
    {
        //private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static T singleton = new T();
        protected int CommandTimeoutSecond = 3600;

        public static T Instance
        {
            get
            {
                return singleton;
            }
        }

        protected virtual System.Xml.XmlDocument SqlDocument
        {
            get
            {
                return null;
            }
        }

        #region Connection
        protected SqlConnection CreateConnection()
        {
            string constr = ConfigurationManager.AppSettings["Constr"];
            string dbpass = ConfigurationManager.AppSettings["DBPASS"];
            string dbpassPain = DataCryptography.Decrypt(dbpass);
            constr = constr + dbpassPain;
            SqlConnection con = new SqlConnection(constr);
            return con;
        }
        #endregion

        protected void AddSQLParam(SqlParameterCollection @params, string name, object val)
        {
            AddSQLParam(@params, name, val, TypeConvertor.ToSqlDbType(val));
        }

        protected void AddSQLParam(SqlParameterCollection @params, string name, object val, System.Data.SqlDbType type)
        {
            object paramValue = getParamValue(val);

            @params.Add(name, type).Value = paramValue;
        }
        private static object getParamValue(object val)
        {
            object paramValue = null;

            if (val is int || val is long || val is decimal || val is double || val is bool ||
                val is string || val is DateTime)
            {
                paramValue = val;
            }
            else if (val is DateTime?)
            {
                DateTime? dt;
                dt = (DateTime?)val;
                if (dt.HasValue)
                {
                    paramValue = dt.Value;
                }
                else
                {
                    paramValue = DBNull.Value;
                }
            }
            else if (val is decimal?)
            {
                decimal? dc;
                dc = (decimal?)val;
                if (dc.HasValue)
                {
                    paramValue = dc.Value;
                }
                else
                {
                    paramValue = DBNull.Value;
                }
            }
            else
            {
                paramValue = DBNull.Value;
            }
            return paramValue;
        }

        protected static List<Instance> ConvertDataTable<Instance>(DataTable dt)
        {
            List<Instance> data = new List<Instance>();
            foreach (DataRow row in dt.Rows)
            {
                Instance item = GetItem<Instance>(row);
                data.Add(item);
            }
            return data;
        }
        private static Instance GetItem<Instance>(DataRow dr)
        {
            Type temp = typeof(T);
            Instance obj = Activator.CreateInstance<Instance>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName].ToString(), null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}