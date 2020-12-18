using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Component.Common
{
    public sealed class TypeConvertor
    {
        private struct DbTypeMapEntry
        {
            public Type Type;
            public DbType DbType;
            public MySqlDbType MySqlDbType;
            public DbTypeMapEntry(Type type, DbType dbType, MySqlDbType MySqlDbType)
            {
                this.Type = type;
                this.DbType = dbType;
                this.MySqlDbType = MySqlDbType;
            }
        }

        private static ArrayList _DbTypeList = new ArrayList();

        #region Constructors

        static TypeConvertor()
        {
            DbTypeMapEntry dbTypeMapEntry;

            dbTypeMapEntry = new DbTypeMapEntry(typeof(DBNull), DbType.String, MySqlDbType.VarChar);
            _DbTypeList.Add(dbTypeMapEntry);


            dbTypeMapEntry = new DbTypeMapEntry(typeof(bool), DbType.Boolean, MySqlDbType.Bit);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(byte), DbType.Double, MySqlDbType.Double);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(byte[]), DbType.Binary, MySqlDbType.Binary);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(DateTime), DbType.DateTime, MySqlDbType.DateTime);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Decimal), DbType.Decimal, MySqlDbType.Decimal);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(double), DbType.Double, MySqlDbType.Float);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Guid), DbType.Guid, MySqlDbType.Guid);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Int16), DbType.Int16, MySqlDbType.Int16);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Int32), DbType.Int32, MySqlDbType.Int32);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(Int64), DbType.Int64, MySqlDbType.Int64);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(object), DbType.Object, MySqlDbType.Bit);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(string), DbType.String, MySqlDbType.VarChar);
            _DbTypeList.Add(dbTypeMapEntry);

            dbTypeMapEntry = new DbTypeMapEntry(typeof(decimal), DbType.Decimal, MySqlDbType.Decimal);
            _DbTypeList.Add(dbTypeMapEntry);
        }

        private TypeConvertor()
        {
        }

        #endregion



        #region Methods

        /// <summary>
        /// Convert db type to .Net data type
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static Type ToNetType(DbType dbType)
        {
            DbTypeMapEntry entry = Find(dbType);
            return entry.Type;
        }


        /// <summary>
        /// Convert TSQL type to .Net data type
        /// </summary>
        /// <param name="MySqlDbType"></param>
        /// <returns></returns>
        public static Type ToNetType(MySqlDbType MySqlDbType)
        {
            DbTypeMapEntry entry = Find(MySqlDbType);
            return entry.Type;
        }

        /// <summary>
        /// Convert .Net type to Db type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DbType ToDbType(Type type)
        {
            DbTypeMapEntry entry = Find(type);
            return entry.DbType;
        }

        /// <summary>
        /// Convert TSQL data type to DbType
        /// </summary>
        /// <param name="MySqlDbType"></param>
        /// <returns></returns>
        public static DbType ToDbType(MySqlDbType MySqlDbType)
        {
            DbTypeMapEntry entry = Find(MySqlDbType);
            return entry.DbType;
        }


        /// <summary>
        /// Convert .Net type to TSQL data type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MySqlDbType ToMySqlDbType(Type type)
        {
            DbTypeMapEntry entry = Find(type);
            return entry.MySqlDbType;
        }

        /// <summary>
        /// Convert value of .Net type to TSQL data type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MySqlDbType ToMySqlDbType(object val)
        {
            if (val == null)
            {
                return MySqlDbType.VarChar;
            }

            DbTypeMapEntry entry = Find(val.GetType());
            return entry.MySqlDbType;
        }

        /// <summary>
        /// Convert DbType type to TSQL data type
        /// </summary>
        /// <param name="dbType"></param>
        /// <returns></returns>
        public static MySqlDbType ToMySqlDbType(DbType dbType)
        {
            DbTypeMapEntry entry = Find(dbType);
            return entry.MySqlDbType;
        }


        private static DbTypeMapEntry Find(Type type)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                DbTypeMapEntry entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.Type == type)
                {
                    retObj = entry;
                    break;
                }
            }

            if (retObj == null)
            {
                throw new ApplicationException("Referenced an unsupported Type");
            }

            return (DbTypeMapEntry)retObj;
        }

        private static DbTypeMapEntry Find(DbType dbType)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                DbTypeMapEntry entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.DbType == dbType)
                {
                    retObj = entry;
                    break;
                }
            }
            if (retObj == null)
            {
                throw new ApplicationException("Referenced an unsupported DbType");
            }

            return (DbTypeMapEntry)retObj;
        }

        private static DbTypeMapEntry Find(MySqlDbType MySqlDbType)
        {
            object retObj = null;
            for (int i = 0; i < _DbTypeList.Count; i++)
            {
                DbTypeMapEntry entry = (DbTypeMapEntry)_DbTypeList[i];
                if (entry.MySqlDbType == MySqlDbType)
                {
                    retObj = entry;
                    break;
                }
            }
            if (retObj == null)
            {
                throw new ApplicationException("Referenced an unsupported MySqlDbType");
            }

            return (DbTypeMapEntry)retObj;
        }

        #endregion

    }
}
