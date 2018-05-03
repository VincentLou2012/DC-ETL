using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DC.ETL.Infrastructure.DataHandler.MSSQL
{
    public class DataAccess
    {
        //TODO 表结构SQL语句优化，获取字段名，是否主键，数据类型，长度，小数长度
        private static readonly string sqlstructure = "SELECT col.colorder AS sno,col.name AS name,t.name AS datatype,col.length AS datalen,ISNULL(COLUMNPROPERTY(col.id,col.name,'Scale'),0) "
            +"AS decimals,CASE WHEN EXISTS(SELECT 1 FROM dbo.sysindexes si INNER JOIN dbo.sysindexkeys sik ON si.id = sik.id AND si.indid = sik.indid "
            +"INNER JOIN dbo.syscolumns sc ON sc.id = sik.id AND sc.colid = sik.colid INNER JOIN dbo.sysobjects so ON so.name = si.name AND "
            +"so.xtype = 'PK' WHERE sc.id = col.id AND sc.colid = col.colid ) THEN '1' ELSE ''END AS primarykey FROM dbo.syscolumns col LEFT JOIN dbo.systypes t"
            +"ON col.xtype = t.xusertype inner JOIN dbo.sysobjects obj ON col.id = obj.id AND obj.xtype = 'U' AND obj.status >= 0 WHERE   obj.name = '{0}'";

        public static DataTable GetSource(string constr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    if (conn.State == ConnectionState.Closed) { conn.Open(); }
                    string comstr = "SELECT a.name, b.rows FROM sysobjects AS a left JOIN sysindexes AS b ON a.id = b.id WHERE (a.type = 'u') AND (b.indid IN (0, 1)) ORDER BY b.rows DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter(comstr, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    adapter.Dispose();
                    return dt;
                }
            }
            catch
            {
                return null;
            }
        }

        public IDictionary<string, DataTable> GetStructure(IList<string> Schemas,string constr)
        {
            try
            {
                if (Schemas is null || Schemas.Count < 1) { return null; }
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    IDictionary<string, DataTable> result = new Dictionary<string, DataTable>();
                    foreach (var schema in Schemas)
                    {
                        string comstr = string.Format(sqlstructure, schema);
                        if (conn.State == ConnectionState.Closed) { conn.Open(); }
                        SqlDataAdapter adapter = new SqlDataAdapter(comstr, conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        adapter.Dispose();
                        result.Add(schema, dt);
                    }
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
