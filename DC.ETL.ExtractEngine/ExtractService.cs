using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Infrastructure.MQ.MSMQ;
namespace DC.ETL.ExtractEngine
{
    public partial class ExtractService : ServiceBase
    {
        public ExtractService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {

            }
            catch (Exception ex)
            {
                
            }
        }

        protected override void OnStop()
        {
        }

        private void InitializeComponent()
        {
            this.ServiceName = "DC-ETL-Engine";
        }
    }
}
