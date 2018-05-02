using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Domain.Model;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain.Service
{
    /// <summary>
    /// 任务领域服务
    /// </summary>
    public class TaskDomainService : ITaskDomainService
    {
        #region 任务
        
        private ITaskRepository iTaskRepository
        {
            get { return Container.Resolve<ITaskRepository>("TaskRepository"); }
        }
        #endregion 任务

        #region 操作记录
        
        private IOPRecordRepository iOPRecordRepository
        {
            get { return Container.Resolve<IOPRecordRepository>("OPRecordRepository"); }
        }
        #endregion 操作记录

        /// <summary>
        /// 创建任务基本信息
        /// </summary>
        /// <param name="task"></param>
        public int SaveBaseInfo(TaskDTO taskDTO)
        {
            if (taskDTO == null) return -1;// TODO: 替换标准错误代码
            Task task = AutoMapperUtils.MapTo<Task>(taskDTO);
            Task taskInDB = iTaskRepository.GetByKey(task.SN);

            EOptype eop = EOptype.Update;
            if (taskInDB == null)
            {
                eop = EOptype.Add;
                iTaskRepository.Add(task);
            }
            else
            {
                taskInDB.SetBaseInfo(task);
                iTaskRepository.Update(taskInDB);
            }
            int nRet = iTaskRepository.SaveChanges();

            // 新增操作记录
            TaskRcd taskRcd = new TaskRcd(nRet, taskInDB, eop);
            iOPRecordRepository.Add(taskRcd);
            int nOpRet = iOPRecordRepository.SaveChanges();
            return nRet;
        }
    }
}
