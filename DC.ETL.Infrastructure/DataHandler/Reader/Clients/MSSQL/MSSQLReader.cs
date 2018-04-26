using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DC.ETL.Infrastructure.DataHandler.Reader.Clients.MSSQL
{
    public class MSSQLReader : IReader<SqlDataReader> ,IDisposable
    {
        private string ComStr = "select {0} from {1} {2}";
        private string ConnectStr = "Data Source={0}\\{1};Initial Catalog={2};User ID={3};Password={4}";
        private SqlConnection Conn = null;
        public IDictionary<string, object> Params { get; set; }

        /// <summary>
        /// 构建Reader实例，建立连接
        /// </summary>
        /// <param name="ConParams">必需参数：Con_IPAddress，Con_InstanceName，Con_DSName，Con_UserName，Con_Password</param>
        public MSSQLReader(IDictionary<string, object> ConParams)
        {
            this.ResolveConn(ConParams);
            Conn = new SqlConnection(ConnectStr);
        }

        public void ResolveConn(IDictionary<string, object> ConParams)
        {
            IList<string> necessary = new List<string> { "Con_IPAddress","Con_InstanceName","Con_DSName","Con_UserName","Con_Password" };
            if (VerifyParams(ConParams, necessary))
            {
                object[] args = new object[] {
                    (string)ConParams["Con_IPAddress"],
                    (string)ConParams["Con_InstanceName"],
                    (string)ConParams["Con_DSName"],
                    (string)ConParams["Con_UserName"],
                    Commons.DESDecrypt((string)ConParams["Con_Password"])
                };
                ConnectStr = string.Format(ConnectStr, args);

            }
        }

        /// <summary>
        /// 解析查询
        /// </summary>
        public void ResolveQuery()
        {
            IList<string> necessary = new List<string> { "Field", "Schema", "Condition" };
            if (VerifyParams(Params, necessary))
            {
                ComStr = string.Format(ComStr,
                    (string)Params["Field"],
                    (string)Params["Schema"],
                    (string)Params["Condition"]
                    );

            }
        }

        public bool VerifyParams(IDictionary<string, object> Params, IList<string> Necessary)
        {
            IList<string> res = new List<string>();
            if (Params.Count < 1) { return false; }
            foreach (KeyValuePair<string, object> kv in Params)
            {
                if (Necessary.Contains(kv.Key))
                {
                    res.Add(kv.Key);
                }
            }
            bool result = Necessary.Except(res).Count() > 0 ? false : true;
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="QueryParams">查询参数</param>
        /// <returns></returns>
        public SqlDataReader GetData(IDictionary<string, object> QueryParams)
        {
            try
            {
                this.Params = QueryParams; ResolveQuery();
                if (Conn.State == ConnectionState.Closed){ Conn.Open(); }
                SqlCommand Comm = new SqlCommand(ComStr, Conn);
                SqlDataReader Dr = Comm.ExecuteReader();
                //Conn.Close();
                return Dr;
            }
            catch (Exception ex)
            {
                //TODO:获取目标数据错误处理
            }
            return null;
        }

        /// <summary>
        /// 验证数据库连接
        /// </summary>
        /// <returns></returns>
        public bool VerifyConn()
        {
            try
            {
                Conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 销毁获取器
        /// </summary>
        public void Dispose()
        {
            Conn.Close();
            Conn.Dispose();
        }
    }
}
