using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapSoft.Core.Infrastructure
{
    public static class DbContextExtensions
    {
        public static MultiResultSetReader MultiResultSetSqlQuery(this DbContext context, string query, params SqlParameter[] parameters)
        {
            return new MultiResultSetReader(context, query, parameters);
        }
    }

    public class MultiResultSetReader : IDisposable
    {
        private readonly DbContext _context;
        private readonly DbCommand _command;
        private bool _connectionNeedsToBeClosed;
        private DbDataReader _reader;

        public MultiResultSetReader(DbContext context, string query, SqlParameter[] parameters)
        {
            _context = context;
            _command = _context.Database.Connection.CreateCommand();
            _command.CommandText = query;

            if (parameters != null && parameters.Any()) _command.Parameters.AddRange(parameters);
        }


        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Dispose();
                _reader = null;
            }

            if (_connectionNeedsToBeClosed)
            {
                _context.Database.Connection.Close();
                _connectionNeedsToBeClosed = false;
            }
        }

        public ObjectResult<T> ResultSetFor<T>()
        {
            try
            {
                if (_reader == null)
                {
                    _reader = GetReader();
                }
                else
                {
                    _reader.NextResult();
                }

                var objContext = ((IObjectContextAdapter)_context).ObjectContext;

                return objContext.Translate<T>(_reader);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        private DbDataReader GetReader()
        {
            try
            {
                if (_context.Database.Connection.State != ConnectionState.Open)
                {
                    _context.Database.Connection.Open();
                    _connectionNeedsToBeClosed = true;
                }

                return _command.ExecuteReader();
            }
           catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
