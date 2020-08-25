using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{



    public class LimitPropsContractResolver : DefaultContractResolver
    {
        string[] props = null;

        bool retain;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="props">传入的属性数组</param>
        /// <param name="retain">true:表示props是需要保留的字段  false：表示props是要排除的字段</param>
        public LimitPropsContractResolver(string[] props, bool retain = true)
        {
            //指定要序列化属性的清单
            this.props = props;

            this.retain = retain;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list =
            base.CreateProperties(type, memberSerialization);
            //只保留清单有列出的属性
            return list.Where(p =>
            {
                if (retain)
                {
                    return props.Contains(p.PropertyName);
                }
                else
                {
                    return !props.Contains(p.PropertyName);
                }
            }).ToList();
        }

    }

    public class Peo
    {

        public int Age { get; set; }

        public string Sex { get; set; }
        [JsonIgnore]
        public bool IsMarry { get; set; }


    }


public class JsonSerializerCenter
    {
        static void FromatDitits<T>(T model)
        {
            var newType = model.GetType();
            foreach (var item in newType.GetRuntimeProperties())
            {
                var type = item.PropertyType.Name;
                var IsGenericType = item.PropertyType.IsGenericType;
                var list = item.PropertyType.GetInterface("IEnumerable", false);
                Console.WriteLine($"属性名称：{item.Name}，类型：{type}，值：{item.GetValue(model)}");
                if (IsGenericType && list != null)
                {
                    var listVal = item.GetValue(model) as IEnumerable<object>;
                    if (listVal == null) continue;
                    foreach (var aa in listVal)
                    {
                        var dtype = aa.GetType();
                        foreach (var bb in dtype.GetProperties())
                        {
                            var dtlName = bb.Name.ToLower();
                            var dtlType = bb.PropertyType.Name;
                            var oldValue = bb.GetValue(aa);
                            if (dtlType == typeof(decimal).Name)
                            {
                                int dit = 4;
                                if (dtlName.Contains("price") || dtlName.Contains("amount"))
                                    dit = 2;
                                bb.SetValue(aa, Math.Round(Convert.ToDecimal(oldValue), dit, MidpointRounding.AwayFromZero));
                            }
                            Console.WriteLine($"子级属性名称：{dtlName}，类型：{dtlType}，值：{oldValue}");
                        }
                    }
                }
            }
        }
        public class ToJsonHelper
        {
            public static string ToJson(Dictionary<string, object> param)
            {
                var sortParam = param.OrderBy(_ => _.Key).Aggregate(string.Empty, (current, p) => current + $"\"{p.Key}\":\"{p.Value}\",");//根据字母排序
                return "{" + sortParam.TrimEnd(',') + "}";
            }

            /// <summary>
            /// 对象转换为字典
            /// </summary>
            /// <param name="obj">待转化的对象</param>
            /// <returns></returns>
            public static Dictionary<string, string> ObjectToMap(object obj)
            {
                Dictionary<string, string> map = new Dictionary<string, string>();

                Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

                PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

                var index = 6000;
                foreach (PropertyInfo p in pi)
                {
                    MethodInfo m = p.GetGetMethod();

                    if (m != null && m.IsPublic)
                    {
                        // 进行判NULL处理
                        if (m.Invoke(obj, new object[] { }) != null)
                        {
                            //map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                            //index++;
                            //var property = obj.GetType().GetProperty(p.Name);
                            //property.SetValue(obj,index.ToString(), null);//类型转换。
                            //map.Add(p.Name, $"{index}_{ m.Invoke(obj, new object[] { })}"); // 向字典添加元素

                            map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                        }
                    }
                }
                //Console.WriteLine("------------");
                //Console.WriteLine(JsonConvert.SerializeObject(obj));
                //Console.WriteLine("------------");
                return map;
            }



            public static Dictionary<string, string> ObjectToCurrentMap(object obj)
            {
                var index =6000;
                Dictionary<string, string> map = new Dictionary<string, string>();

                Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

                PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

                foreach (PropertyInfo p in pi)
                {
                    MethodInfo m = p.GetGetMethod();

                    if (m != null && m.IsPublic)
                    {
                        // 进行判NULL处理
                        if (m.Invoke(obj, new object[] { }) != null)
                        {
                            map.Add(p.Name,$"{index}_{ m.Invoke(obj, new object[] { }).ToString()}"); // 向字典添加元素
                        }
                    }
                }
                return map;
            }

            public static void test()
            {
                var t = new Thang { };

                var t2 = new Thang { Thing = "Hey", Name = "long" };
                var dict = new Dictionary<string, string>();

                var mapProperty = new Dictionary<string, string>();
                Object obj;
                (obj, dict) = JsonHelper.ObjectToMapWithDict(t);

                Console.WriteLine(JsonConvert.SerializeObject(dict));
                var serializedObj = JsonConvert.SerializeObject(obj);
                var map = ObjectToMap(t2);
                Dictionary<string, string> dictJsonProperty = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                    JsonConvert.SerializeObject(t));
                var dictProperty= new Dictionary<string, string>();
                foreach (var item in dictJsonProperty)
                {
                    var realPropertyName = dict[item.Value];
                    dictProperty.Add(item.Key, dict[item.Value]);
                    map.GetValueOrDefault(realPropertyName);
                    mapProperty.Add(item.Key, map.GetValueOrDefault(realPropertyName)); 
                    //dictProperty.Add(item.Key, dict.GetValueOrDefault(item.Value));
                    //var c = dict.GetValueOrDefault(item.Value);
                    //item.Value = dict.GetValueOrDefault(item.Value);
                }
                Console.WriteLine(JsonConvert.SerializeObject(dictProperty));

                Console.WriteLine(JsonConvert.SerializeObject(mapProperty));
            }
            public static void test2()
            {
                var settings = new JsonSerializerSettings();
                settings.ContractResolver = new GenericPropertyContractResolver(typeof(Response<>));
                var aa = new Response<Thang>
                {
                    Data = new Thang { Thing = "Hey" }
                };
                var t = new Thang { Thing = "Hey",Name="long" };
                //JsonConvert.SerializeXNode(t)

                Console.WriteLine(JsonConvert.SerializeObject(aa));

                Console.WriteLine("aa");
                Console.WriteLine(PropertyToDict(t));

                Console.WriteLine("PropertyToDict");

                Console.WriteLine(JsonConvert.SerializeObject(ObjectToMap(t)));

                
                Console.WriteLine("ObjectToMap==");
                Dictionary<string, string> dic2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                    JsonConvert.SerializeObject(t));
                foreach (var item in dic2)
                {
                    Console.WriteLine($"{item.Key}---->{item.Value}");
                }


                string serialized = JsonConvert.SerializeObject(new Response<Thang>
                {
                    Data = new Thang { Thing = "Hey" }
                }, settings);
                //PropertyToDict()
                Console.WriteLine(serialized);
                Console.WriteLine("dsd()");
                dsd();

            }

            public static void dsd()
            {

                Peo p = new Peo() { Age=11,IsMarry=true,Sex= "Gril" };
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.ContractResolver = new LimitPropsContractResolver(new string[] { "Age", "IsMarry" });
                //var c= jsetting.ContractResolver. GetSerializableMembers()
                Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
            }

            public static bool ContainProperty(object instance, string propertyName)
            {
                if (instance != null && !string.IsNullOrEmpty(propertyName))
                {
                    PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
                    return (_findedPropertyInfo != null);
                }
                return false;
            }

            public static string PropertyToDict(object instance)
            {
                 string propertyName;
                var c=instance.GetType().GetTypeInfo();
                var    serialized = JsonConvert.SerializeObject(c);

                return serialized;
                //if (instance != null && !string.IsNullOrEmpty(propertyName))
                //{
                //    PropertyInfo _findedPropertyInfo = instance.GetType().GetProperty(propertyName);
                //    return (_findedPropertyInfo != null);
                //}
                //return false;
            }

        }
        public class Response<T>
        {
            public T Data { get; set; }
        }


        internal class Thang
        {
            [JsonProperty("ttt")]
            public string Thing { get; set; }


            [JsonProperty("ca")]
            public string LongTime { get; set; }
            [JsonProperty("nnn")]
            public string Name { get; set; }
        }

        public class GenericPropertyContractResolver :
         CamelCasePropertyNamesContractResolver
        {
            private readonly Type genericTypeDefinition;

            public GenericPropertyContractResolver(Type genericTypeDefinition)
            {
                this.genericTypeDefinition = genericTypeDefinition;
            }

            protected override JsonProperty CreateProperty(
                MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty baseProperty =
                    base.CreateProperty(member, memberSerialization);

                Type declaringType = member.DeclaringType;

                if (!declaringType.IsGenericType ||
                    declaringType.GetGenericTypeDefinition() != this.genericTypeDefinition)
                {
                    return baseProperty;
                }

                Type declaringGenericType = declaringType.GetGenericArguments()[0];

                if (IsGenericMember(member))
                {
                    baseProperty.PropertyName =
                        this.ResolvePropertyName(declaringGenericType.Name);
                }

                return baseProperty;
            }

            // Is there a better way to do this? Determines if the member passed in
            // is a generic member in the open generic type.
            public bool IsGenericMember(MemberInfo member)
            {
                MemberInfo genericMember =
                    this.genericTypeDefinition.GetMember(member.Name)[0];

                if (genericMember != null)
                {
                    if (genericMember.MemberType == MemberTypes.Field)
                    {
                        return ((FieldInfo)genericMember).FieldType.IsGenericParameter;
                    }
                    else if (genericMember.MemberType == MemberTypes.Property)
                    {
                        PropertyInfo property = (PropertyInfo)genericMember;

                        return property
                            .GetMethod
                            .ReturnParameter
                            .ParameterType
                            .IsGenericParameter;
                    }
                }

                return false;
            }
        }
    }
}
