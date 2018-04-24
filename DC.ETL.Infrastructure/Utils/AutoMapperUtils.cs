using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace DC.ETL.Infrastructure.Utils
{
    public class AutoMapperUtils
    {
        /// <summary>
        /// 注册映射关系
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDto"></typeparam>
        public static void Register<T, TDto>()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<T, TDto>());
        }
        /// <summary>
        /// 一般转换对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public TDto Map<T, TDto>(T t)
        {
            return Mapper.Map<TDto>(t);
        }
    }
}
