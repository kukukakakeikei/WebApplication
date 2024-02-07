using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.ReponseType.DataShaping
{
    public static class DataShaperExentensions
    {
        //针对集合的扩展泛型方法
        public static IEnumerable<dynamic> ShapeData<T>(this IEnumerable<T> sources, string fileds)
        {
            var dataShaper = new DataShaper<T>(fileds); //根据字段创建数据构型器
            return dataShaper.FetchData(sources); //调用方法传入数据源
        }
        //针对单个实体的扩展泛型方法
        public static dynamic ShapeData<T>(this T source ,string fileds) 
        {
            var dataShaper = new DataShaper<T>(fileds);
            return dataShaper.FetchData(source);
        }
    }
}
