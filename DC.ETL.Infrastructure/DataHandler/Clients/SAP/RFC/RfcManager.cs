using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAP.Middleware.Connector;
using System.Data;

namespace DC.ETL.Infrastructure.DataHandler.SAP.RFC
{
    public class RfcManager
    {
        #region 属性字段
        /// <summary>
        /// 接收器
        /// </summary>
        public RfcDestination Prd { get; set; }
        /// <summary>
        /// 数据仓库
        /// </summary>
        public RfcRepository Repo { get; set; }

        public IDestinationConfiguration IDC { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化
        /// </summary>
        public RfcManager()
        {

        }

        public void Initialize(IDictionary<string, object> ConnParams)
        {
            IDC = new RfcDestinationConfig(ConnParams);
            //注册
            RfcDestinationManager.RegisterDestinationConfiguration(IDC);
            //获取RFC接收器
            this.Prd = RfcDestinationManager.GetDestination((string)ConnParams["Con_InstanceName"]);
            this.Repo = this.Prd.Repository;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 执行RFC获取数据表
        /// </summary>
        /// <param name="rfcname">rfc方法名称</param>
        /// <param name="tablename">rfc表名</param>
        /// <param name="columnnames">数据表列名列表</param>
        /// <param name="param">rfc执行参数</param>
        /// <returns>数据表</returns>
        public DataTable ExecRfc(string rfcname, string tablename, List<string> columnnames, Dictionary<string, object> param)
        {
            try
            {
                DataTable dt = new DataTable();
                if (columnnames != null && columnnames.Count > 0)
                {
                    //配置datatable
                    dt.Columns.Clear();
                    foreach (string cname in columnnames)
                    {
                        dt.Columns.Add(cname, typeof(string));
                    }
                    dt.AcceptChanges();

                    //从SAP那获取数据表
                    if (!string.IsNullOrEmpty(rfcname) && param != null && param.Count > 0)
                    {
                        IRfcFunction rfc = this.Repo.CreateFunction(rfcname);
                        foreach (KeyValuePair<string, object> kv in param)
                        {
                            rfc.SetValue(kv.Key, kv.Value);
                        }
                        rfc.Invoke(this.Prd);
                        IRfcTable iTable = rfc.GetTable(tablename);
                        if (iTable.Count > 0)
                        {
                            for (int i = 0; i < iTable.RowCount; i++)
                            {
                                iTable.CurrentIndex = i;
                                DataRow oNewRow = dt.NewRow();
                                foreach (string cname in columnnames)
                                {
                                    oNewRow[cname] = iTable.GetString(cname).ToString();
                                }
                                dt.Rows.Add(oNewRow);
                            }
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex) { return null; }
            finally
            {
                DisposeIDC();
            }
        }

        public void DisposeIDC()
        {
            RfcDestinationManager.UnregisterDestinationConfiguration(IDC);
        }
        #endregion
    }
}
