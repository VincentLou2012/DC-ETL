using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using DC.ETL.Infrastructure.Container;
using DC.ETL.Domain.Specifications;
using System.Linq.Expressions;
using DC.ETL.Infrastructure.Utils;
using DC.ETL.Models.DTO;

namespace DC.ETL.Domain
{
    /// <summary>
    /// 抽取策略
    /// </summary>
    public partial class Strategy : AggregateRoot
    {

        #region 抽取策略
        [Dependency]
        private IStrategyRepository iStrategyRepository
        {
            get { return Container.Resolve<IStrategyRepository>("StrategyRepository"); }
        }
        #endregion 抽取策略
        /// <summary>
        /// 获取单个抽取策略
        /// </summary>
        /// <returns></returns>
        public StrategyDTO Get(Guid SN)
        {
            return AutoMapperUtils.MapTo<StrategyDTO>(iStrategyRepository.GetByKey(SN));
        }

        /// <summary>
        /// 创建抽取策略基本信息
        /// </summary>
        /// <param name="strategy"></param>
        public int SaveBaseInfo(StrategyDTO stgDTO)
        {
            if (stgDTO == null) return -1;// TODO: 替换标准错误代码
            Strategy stg = AutoMapperUtils.MapTo<Strategy>(stgDTO);
            Strategy stgInDB = iStrategyRepository.GetByKey(stg.SN);

            if (stgInDB == null)
            {
                iStrategyRepository.Add(stg);
            }
            else
            {
                stgInDB.SetBaseInfo(stg);
                iStrategyRepository.Update(stgInDB);
            }
            return iStrategyRepository.SaveChanges();
        }

        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="o"></param>
        private void SetBaseInfo(Strategy o)
        {
            //this.StrategyID = o.StrategyID;// 	策略ID
            this.SN = o.SN;// 	策略序列
            this.StrategyType = o.StrategyType;// 	策略类型,逻辑中枚举
            this.IsRepeet = o.IsRepeet;// 	是否重复
            this.RepeatCount = o.RepeatCount;// 	重复次数,0为无限,-1为不重复
            this.Interval = o.Interval;// 	重复间隔
            this.Days = o.Days;// 	周天
            this.TimeHour = o.TimeHour;// 	定时小时
            this.TimeMinute = o.TimeMinute;// 	定时分钟
            this.StartDate = o.StartDate;// 	开始时间
            this.Comment = o.Comment;// 	备注
            this.ReservedInt = o.ReservedInt;// 	预留一个整型
            this.ReservedStr = o.ReservedStr;// 	预留一个字符型
        }
    }
}
