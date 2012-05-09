﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DapperExtensions.Sql
{
    public interface ISqlDialect
    {
        char OpenQuote { get; }
        char CloseQuote { get; }
        string GetTableName(string schemaName, string tableName, string alias);
        string GetColumnName(string prefix, string columnName, string alias);
        string GetIdentitySql(string tableName);
        string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters);
        bool IsQuoted(string value);
        string QuoteString(string value);
    }

    public abstract class SqlDialectBase : ISqlDialect
    {
        public virtual char OpenQuote
        {
            get { return '"'; }
        }

        public virtual char CloseQuote
        {
            get { return '"'; }
        }

        public virtual string GetTableName(string schemaName, string tableName, string alias)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException(tableName, "tableName cannot be null or empty.");
            }

            StringBuilder result = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(schemaName))
            {
                result.AppendFormat(QuoteString(schemaName) + ".");
            }

            result.AppendFormat(QuoteString(tableName));

            if (!string.IsNullOrWhiteSpace(alias))
            {
                result.AppendFormat(" AS {0}", QuoteString(alias));
            }
            return result.ToString();
        }

        public virtual string GetColumnName(string prefix, string columnName, string alias)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException(columnName, "columnName cannot be null or empty.");
            }

            StringBuilder result = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(prefix))
            {
                result.AppendFormat(QuoteString(prefix) + ".");
            }

            result.AppendFormat(QuoteString(columnName));

            if (!string.IsNullOrWhiteSpace(alias))
            {
                result.AppendFormat(" AS {0}", QuoteString(alias));
            }

            return result.ToString();
        }

        public abstract string GetIdentitySql(string tableName);
        public abstract string GetPagingSql(string sql, int page, int resultsPerPage, IDictionary<string, object> parameters);

        public virtual bool IsQuoted(string value)
        {
            if (value.Trim()[0] == OpenQuote)
            {
                return value.Trim().Last() == CloseQuote;
            }

            return false;
        }

        public virtual string QuoteString(string value)
        {
            return IsQuoted(value) ? value : string.Format("{0}{1}{2}", OpenQuote, value.Trim(), CloseQuote);
        }
    }
}