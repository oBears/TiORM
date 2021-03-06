using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using SimpleSql.Entity;

namespace SimpleSql.Abstract
{
    public class BaseBuilder<T>
    {
        public IDbConnection _conn;
        public Type type = typeof(T);
        public SqlTranslator<T> _sqlTranslator;
        public string TableName { set; get; }

        public BaseBuilder(IDbConnection conn)
        {
            _conn = conn;
            _sqlTranslator = new SqlTranslator<T>();
            TableName = DefaultResolver.ResolveTableName(type);
        }
        public void SetParamter(string key,object val)
        {
             _sqlTranslator.Params.Add(key, val);
        }
        public string GetNewParamter()
        {
            return _sqlTranslator.ParamIndex;
        }
        public DynamicParameters GetParamters()
        {
            return _sqlTranslator.Params;
        }
        public virtual int Execute()
        {
            throw new NotImplementedException();
        }

     

    }

}
