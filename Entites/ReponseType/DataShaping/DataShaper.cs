using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Entites.ReponseType.DataShaping
{
    public class DataShaper<T>
    {
        private readonly List<PropertyInfo> _requiredProperties = new List<PropertyInfo>();
        public DataShaper(string fieldsString)
        {
            //获取构型目标类型（Player）的所有公共属性
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (string.IsNullOrWhiteSpace(fieldsString))
            {
                _requiredProperties = properties.ToList();
            }
            else
            {
                var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var field in fields)
                {
                    var property = properties.FirstOrDefault(pi => pi.Name.Equals(field.Trim(),
                        StringComparison.InvariantCultureIgnoreCase));
                    if (property == null)
                        continue;
                    _requiredProperties.Add(property);
                }
            }
        }
        //单个数据提取方法
        public ExpandoObject FetchData(T sourceData) 
        {
            var shapedObject = new ExpandoObject();

            foreach (var property in _requiredProperties) 
            {
                var objectPropertyValue = property.GetValue(sourceData);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }

            return shapedObject;
        }
        //集合数据提取方法
        public IEnumerable<ExpandoObject> FetchData(IEnumerable<T> sourceData) 
        {
            var shapedData = new List<ExpandoObject>();

            foreach (var item in sourceData)
            {
                var shapedObject = FetchData(item);
                shapedData.Add(shapedObject);
            }

            return shapedData;
        }
    }
}
