using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace DataStore.DbHelpers.templates
{
    public class DbTemplateHelper<T>
    {
        private static DbCommand CreateCommand(DbConnection conn, String commandText, CommandType cmdType, int? timeout)
        {
            DbCommand command = conn.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = cmdType;
            command.Connection = conn;

            if (timeout.HasValue) command.CommandTimeout = timeout.Value;

            return command;
        }

        private static void AddDbParameters2Command(IEnumerable<DbParameterHelper> parameters, DbCommand command)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    param.ToDbParameter(command);
                }
            }
        }


        private static class DbExecutor<V>
        {
            private delegate void StatementPrepared(DbCommand command);
            private static void PrepareStatement(StatementPrepared prepared, string cmdText, CommandType commandType, IEnumerable<DbParameterHelper> parameters, int? timeout)
            {
                using (DbConnection connection = ConnectionHelper.CreateDBConnection())
                {
                    using (DbCommand command = CreateCommand(connection, cmdText, commandType, timeout))
                    {
                        AddDbParameters2Command(parameters, command);
                        connection.Open();

                        prepared(command);
                    }
                }

            }

            public delegate V ConstructFromReader(IDataReader reader);
            public static V GetSQLObject(ConstructFromReader builder, string cmdText, CommandType commandType, IEnumerable<DbParameterHelper> parameters, int? timeout) 
            {
                V v = default(V);
                PrepareStatement(
                    (command) => {
                        using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            v = builder(reader);
                            reader.Close();
                        }
                    }, 
                    cmdText, 
                    commandType,
                    parameters,
                    timeout);

                //using (DbConnection connection = ConnectionHelper.CreateDBConnection())
                //{
                //    using (DbCommand command = CreateCommand(connection, cmdText, commandType, timeout))
                //    {
                //        AddDbParameters2Command(parameters, command);

                //        connection.Open();

                //        using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                //        {
                //            v = builder(reader);
                //            reader.Close();
                //        }
                //    }
                //}

                return v;
            }

            public static bool ExecuteSql(string cmdText, CommandType commandType, IEnumerable<DbParameterHelper> parameters, int? timeout) 
            {
                bool executed = false;
                PrepareStatement(
                    (command) =>
                    {
                        command.ExecuteNonQuery();
                        executed = true;
                    },
                    cmdText,
                    commandType,
                    parameters,
                    timeout);

                return executed;
            }
        }

        private static T GetObject(ConstructObject constructor, string cmdText, CommandType commandType, IEnumerable<DbParameterHelper> parameters, int? timeout)
        {
            return DbExecutor<T>.GetSQLObject(
                        (reader) =>
                        {
                            T t = default(T);
                            if (reader.Read())
                            {
                                t = constructor(reader);
                            }

                            return t;
                        }, 
                        cmdText, 
                        commandType, 
                        parameters, 
                        timeout);
        }

        private static IEnumerable<T> GetObjectList(ConstructObject constructor, string cmdText, CommandType commandType, IEnumerable<DbParameterHelper> parameters, int? timeout)
        {

            return DbExecutor<List<T>>.GetSQLObject(
                        (reader) =>
                        {
                            List<T> t_list = new List<T>();

                            while (reader.Read())
                            {
                                T t = constructor(reader);
                                t_list.Add(t);
                            }

                            return t_list;
                        },
                        cmdText,
                        commandType,
                        parameters,
                        timeout);
        }

        public delegate T ConstructObject(IDataReader reader);

        public static T GetObjectBySQLQuery(ConstructObject constructor, string query, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObject(constructor, query, CommandType.Text, parameters, timeout);
        }

        public static T GetObjectByProcedure(ConstructObject constructor, string procedure, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObject(constructor, procedure, CommandType.StoredProcedure, parameters, timeout);
        }

        public static IEnumerable<T> GetListByProcedure(ConstructObject constructor, string procedure, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObjectList(constructor, procedure, CommandType.StoredProcedure, parameters, timeout);
        }

        public static IEnumerable<T> GetListBySQLQuery(ConstructObject constructor, string query, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObjectList(constructor, query, CommandType.Text, parameters, timeout);
        }

        public static IEnumerable<T> GetValuesBySQLQuery(string query, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObjectList(
                (reader) => 
                { 
                    return (T)reader[0]; 
                }, 
                query,
                CommandType.Text, 
                parameters, 
                timeout);
        }

        public static IEnumerable<T> GetValuesByProcedure(string procedure, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObjectList(
                (reader) =>
                {
                    return (T)reader[0];
                },
                procedure,
                CommandType.StoredProcedure,
                parameters,
                timeout);
        }

        // Get value
        public static T GetValueBySQLQuery(string query, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObject(
                (reader) =>
                {
                    return (T)reader[0];
                },
                query,
                CommandType.Text,
                parameters,
                timeout);
        }

        public static T GetValueByProcedure(string procedure, IEnumerable<DbParameterHelper> parameters, int? timeout = null)
        {
            return GetObject(
                (reader) =>
                {
                    return (T)reader[0];
                },
                procedure,
                CommandType.StoredProcedure,
                parameters,
                timeout);
        }

        public static bool ExecuteSQL(string query, IEnumerable<DbParameterHelper> parameters, int? timeout)
        {
            return DbExecutor<bool>.ExecuteSql(query, CommandType.Text, parameters, timeout);
        }

        public static bool ExecuteProcedure(string procedure, IEnumerable<DbParameterHelper> parameters, int? timeout)
        {
            return DbExecutor<bool>.ExecuteSql(procedure, CommandType.StoredProcedure, parameters, timeout);
        }
    }
}
