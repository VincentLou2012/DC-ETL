using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Collections;
using System.Data;

namespace DC.ETL.Infrastructure.Utils
{
    /// <summary>
    /// automapper 封装类 但是初始化目前还是需要单独调用
    /// </summary>
    public static class AutoMapperUtils
    {
        /// <summary>
        /// 注册映射关系 单独注册
        /// 必须使用Mapper.Initialize或new MapperConfiguration()来初始化AutoMapper。如果您希望保持静态使用，请使用Mapper.Initialize
        /// 如果你有很多的Mapper.CreateMap调用，把它们移动到一个Profile，或者Mapper.Initialize，在启动时调用一次
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
        public static TDto Map<T, TDto>(T t)
        {
            return Mapper.Map<TDto>(t);
        }
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            return Mapper.Map<T>(obj);
        }
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            //Mapper.CreateMap(type, typeof(TDestination));
            return Mapper.Map<List<TDestination>>(source);
        }
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            //IEnumerable<T> 类型需要创建元素的映射
            //Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map<List<TDestination>>(source);
        }
        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            if (source == null) return destination;
            //Mapper.CreateMap<TSource, TDestination>();
            return Mapper.Map(source, destination);
        }
        /// <summary>
        /// DataReader映射
        /// </summary>
        public static IEnumerable<T> DataReaderMapTo<T>(this IDataReader reader)
        {
            //Mapper.CreateMap<IDataReader, IEnumerable<T>>();
            return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
        }
    }
}
