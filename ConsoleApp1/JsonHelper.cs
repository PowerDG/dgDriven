
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{


    //先定义一个类：

   public class ClientJsonConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //如果遇到了IClient，我们才进行转换
            if (objectType.FullName == typeof(T).FullName)
            {
                return true;
            }
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //再判断一次，如果是IClient接口，那么我们指定具体实现类型
            //if (objectType.FullName == typeof(T).FullName)
            //{
                return serializer.Deserialize<T>(reader);
            //}
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //按正常流程序列化
            serializer.Serialize(writer, value);
        }
    }



    public class JsonHelper
    {
        #region MyRegion
        public static void test()
        {

            var t2 = new SubKuaidiListItem { KuaidiName = "Hey", KuaidiNumber = "long" };
            var list = new List<SubKuaidiListItem>()  ;
            list.Add(t2);
            list.Add(t2);
            MapFormJsonProperty(t2);
            var co = new DeliveryinfoRequest (){ ShopId ="2321", SubKuaidiList = list };


            var c = CompoundObjectToMap(co);
            Console.WriteLine(JsonConvert.SerializeObject(c));
            #region MyRegion

            //var myType = t2.GetType();

            //object myObj = System.Activator.CreateInstance(myType);



            //var mapProperty = new Dictionary<string, string>();
            //Object obj;
            //(obj, mapProperty) = ObjectToMapWithDict(myObj);

            //Console.WriteLine("=myObj=");
            //Console.WriteLine(JsonConvert.SerializeObject(ObjectToMap(myObj)));

            //Console.WriteLine("=obj=");

            //Console.WriteLine(JsonConvert.SerializeObject(obj));

            //Console.WriteLine("=mapProperty=");
            //Console.WriteLine(JsonConvert.SerializeObject(mapProperty));

            #endregion
        }

        public static Dictionary<string, string> CompoundObjectToDict(object obj)
        {
            var sequencedString =  JsonConvert.SerializeObject(obj);
            var dictJsonProperty = JsonConvert.DeserializeObject<Dictionary<string, string>>( sequencedString);
            return dictJsonProperty;
        }




        public static Dictionary<string, object> CompoundObjectToMap(object obj)
        {
            Console.WriteLine(JsonConvert.SerializeObject(obj));
            Dictionary<string, object> map = new Dictionary<string, object>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性


            Type type = obj.GetType();
            if (true)
            {

                foreach (PropertyInfo p in pi)
                {
                    MethodInfo m = p.GetGetMethod();
                    object asObject = null;
                     
                    Console.WriteLine(JsonConvert.SerializeObject(p.Name));
                    //Console.WriteLine(JsonConvert.SerializeObject(p.CustomAttributes));

                    Console.WriteLine(JsonConvert.SerializeObject(p.Attributes));

                    Console.WriteLine(JsonConvert.SerializeObject(p.PropertyType.Name));
                    var val = type.GetProperty(p.Name)?.GetValue(obj);
                    if (m != null && m.IsPublic)
                    {
                        // 进行判NULL处理
                        //if (m.Invoke(asObject, new object[] { }) != null)
                        //{
                        //map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                        if (!p.PropertyType.IsGenericType)
                        {

                            asObject = Convert.ChangeType(val, p.PropertyType);
                            if (p.PropertyType.IsValueType || p.PropertyType.Name.StartsWith("String"))
                            {
                                Console.WriteLine("IsValueType");
                                map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString());// 向字典添加元素

                                Console.WriteLine(JsonConvert.SerializeObject(map));
                            }
                            else
                            {
                                Console.WriteLine("IsNotValueType");
                                var curTemp = GetDeafultObject(p, asObject);

                                //  var tt = m.Invoke(obj, new object[] { });
                                //var currentObj=  MapFormJsonProperty(m.Invoke(obj, new object[] { }?.FirstOrDefault()));
                                var jsTemp = JsonConvert.SerializeObject(curTemp);
                                //map.Add(p.Name, jsTemp.ToString()); 

                                Console.WriteLine("IsNotValueType??????????????????????");
                                map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString());// 向字典添加元素
                                Console.WriteLine(JsonConvert.SerializeObject(map));
                            }
                        }
                        else//泛型Nullable<>
                        {
                            Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                            if (genericTypeDefinition == typeof(Nullable<>))
                            {
                                Console.WriteLine("泛型Nullable");
                                //asObject = Convert.ChangeType(val, Nullable.GetUnderlyingType(p.PropertyType));
                                //var jsTemp = JsonConvert.SerializeObject(asObject);
                            }
                            else
                            {
                                #region MyRegion

                                Console.WriteLine("泛型NotNullable");
                                Console.WriteLine(p.PropertyType.Name);
                                Console.WriteLine(p.PropertyType.FullName);
                                var fullName = p.PropertyType.FullName;
                                //int strtaIndex = fullName.IndexOf("[[");

                                //int endIndex = fullName.IndexOf(",");
                                var subTypeNameList = fullName.Split(new char[]{ ',', '['});

                                //Console.WriteLine(JsonConvert.SerializeObject(subTypeNameList));
                                //---subTypeName
                                var subTypeName = subTypeNameList[2];
                                //object ect = Assembly.Load(assemblyName).CreateInstance(subTypeName);
                                object x =  Assembly.Load(typeof(JsonHelper)
                                    .Assembly.GetName().Name)
                                    .CreateInstance(subTypeName);
                                var cType = x.GetType();
                                Console.WriteLine(x.GetType().FullName);
                                Console.WriteLine(subTypeName);
                                asObject = Convert.ChangeType(val, p.PropertyType);

                                #endregion

                                #region MyRegion

                //                              { "shop_id":"2321","sub_kuaidi_list":                                                   [{"kuaidiname":"Hey","kuaidinumber":"long","kuaiditype":null,"order_id":null,"sub_order_id":null}]}
#endregion
var c = m.Invoke(obj, new object[] { });
                                Console.WriteLine("dynamic");
                                Console.WriteLine(JsonConvert.SerializeObject(c)); 
var list = JsonConvert.DeserializeObject<List<dynamic>>(JsonConvert.SerializeObject(c));
                                var conStr =new List<string> ();
                                var tempStr = string.Empty;
                                if (list .IsNotNullOrEmpty())
                                {
                                    foreach (var item in list)
                                    {
                                        //item.t
                                        //var ieeadw =( )     ;
                                     var dsd= (Dictionary<string, object>) DeserializeStringToDictionary<string ,object>(JsonConvert.SerializeObject(item));

                                        Console.WriteLine("dynamic  dsd ");
                                        Console.WriteLine(JsonConvert.SerializeObject(dsd));
                                        //

                                        tempStr = ToJson(dsd);
                                        conStr.Add(tempStr);

                                            #region MyRegion

                                        //Console.WriteLine("dynamic  dic ");
                                        //IDictionary<string, object> dic = item as IDictionary<string, object>;
                                        //Console.WriteLine(JsonConvert.SerializeObject(dic));

                                        //Console.WriteLine("dynamic  dic ");
                                        //var curDict = ObjectToMap(dic);
                                        ////var curStr = ToJson(curDict);

                                        //Console.WriteLine(JsonConvert.SerializeObject(curDict));
                                        //conStr.Add(curStr);
                                        #endregion
                                    }
                                }
                                var jointEntity = $"[{String.Join(',', conStr)}]";

                                Console.WriteLine(JsonConvert.SerializeObject(jointEntity));
                                var jointEntity2 = $"\"{ p.Name}\":[{String.Join(',', conStr)}]";

                                var jointList = $"[{String.Join(',', conStr)}]";
                                map.Add(p.Name,jointList);
                                Console.WriteLine(JsonConvert.SerializeObject(jointEntity2));
                                //var cat= JsonConvert.DeserializeObject<x.GetType()>("");

                                // var myType = objToMap.GetType();
                                // object myEmptyObj = System.Activator.CreateInstance(myType);
                                JsonSerializer serializer = new JsonSerializer();
                                ////把我们自定义的JsonConverter放进序列化器(相当于告诉序列化器该怎么序列化)
                                ////var aaaa = typeof(cType);
                                //serializer.Converters.Add(new ClientJsonConverter<aaaa> ());
                                //var =JsonConvert.DeserializeObject<List<dynamic>>("");
                                ////进行反序列化
                                //JsonTextReader reader = new JsonTextReader(new StringReader(json));
                                //Student<int> result = serializer.Deserialize<Student<int>>(reader); 

                                //map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString());// 向字典添加元素
                                //var jsTemp = JsonConvert.SerializeObject(asObject);
                            }


                        }

                        //}
                    }
                }
            }
            else
            {

                foreach (PropertyInfo p in pi)
                {
                    MethodInfo m = p.GetGetMethod();
                    object asObject = null;
                    //取得object对象中此属性的值
                    var val = type.GetProperty(p.Name)?.GetValue(obj);
                    if (val != null)
                    {
                        if (p.PropertyType.IsValueType)
                        {

                            map.Add(p.Name, "isvalue"); // 向字典添加元素
                        }
                        else
                        {
                            map.Add(p.Name, p.Name); // 向字典添加元素
                        }
                        ////非泛型
                        //if (!p.PropertyType.IsGenericType)
                        //{ 
                        //    asObject = Convert.ChangeType(val, p.PropertyType);
                        //}
                        //else//泛型Nullable<>
                        //{
                        //    Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                        //    if (genericTypeDefinition == typeof(Nullable<>))
                        //    {
                        //        asObject = Convert.ChangeType(val, Nullable.GetUnderlyingType(p.PropertyType));
                        //    }
                        //    else
                        //    {
                        //        asObject = Convert.ChangeType(val, p.PropertyType);
                        //    }
                        //}
                        //p.SetValue(t, asObject, null);
                    }
                }
            }
            Console.WriteLine("======");
            Console.WriteLine(JsonConvert.SerializeObject(map));

            Console.WriteLine("======");


            Console.WriteLine(ToJson(map));

            Console.WriteLine("======");
            return map;
        }
        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();

            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;

        }
        public static Object GetDeafultObject(PropertyInfo info, object asObject)
        {
            object obj = null;

            Type type = asObject.GetType();
            var val = type.GetProperty(info.Name)?.GetValue(asObject);
            //非泛型
            if (!info.PropertyType.IsGenericType)
            {

                obj = Convert.ChangeType(val, info.PropertyType);
            }
            else//泛型Nullable<>
            {
                Type genericTypeDefinition = info.PropertyType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    Console.WriteLine("泛型Nullable");
                    obj = Convert.ChangeType(val, Nullable.GetUnderlyingType(info.PropertyType));
                    var jsTemp = JsonConvert.SerializeObject(obj);
                }
                else
                {
                    Console.WriteLine("泛型NotNullable");
                    obj = Convert.ChangeType(val, info.PropertyType);

                    var jsTemp = JsonConvert.SerializeObject(obj);
                }
            }
            return obj;
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

            foreach (PropertyInfo p in pi)
            {
                MethodInfo m = p.GetGetMethod();

                if (m != null && m.IsPublic)
                {
                    // 进行判NULL处理
                    if (m.Invoke(obj, new object[] { }) != null)
                    {
                        map.Add(p.Name, m.Invoke(obj, new object[] { }).ToString()); // 向字典添加元素
                    }
                }
            }
            return map;
        }

        /// <summary>
        /// 对象转换为字典，且逆改原Object  赋值临时index 
        /// </summary>
        /// <param name="obj">待转化的对象</param>
        /// <returns></returns>
        public static (object outObj, Dictionary<string, string>) ObjectToDictionary(object obj)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型 
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            var index = 6000;
            foreach (PropertyInfo p in pi)
            {
                // 进行判NULL处理
                MethodInfo m = p.GetGetMethod();
                if (m.IsPublic)
                //if (m != null && m.IsPublic)
                {
                    index++;
                    var property = obj.GetType().GetProperty(p.Name);
                    property.SetValue(obj, index.ToString(), null);//修改模拟模型属性 赋值临时index 
                    dict.Add(index.ToString(), p.Name); // 向字典添加元素
                }
            }
            return (obj, dict);
        }

        /// <summary>
        /// 转化为以JsonProperty为key的字典
        /// </summary>
        /// <param name="objToMap"></param>
        /// <returns></returns>
        public static Dictionary<string, string> MapFormJsonProperty(Object objToMap)
        {
            var myType = objToMap.GetType();
            object myEmptyObj = System.Activator.CreateInstance(myType);
            //JsonConvert.DeserializeObject<List<myType>>(
            //    JsonConvert.SerializeObject(myEmptyObj));
            var sequencedMap = new Dictionary<string, string>();
            var mapProperty = new Dictionary<string, string>();
            Object sequencedObj;
            (sequencedObj, sequencedMap) = ObjectToDictionary(myEmptyObj);
            var map = ObjectToMap(objToMap);
            Dictionary<string, string> dictJsonProperty = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                JsonConvert.SerializeObject(myEmptyObj));
            foreach (var item in dictJsonProperty)
            {
                var realPropertyName = sequencedMap[item.Value];
                ////mapProperty.Add(item.Key, map.GetValueOrDefault(realPropertyName)??string.Empty);

                var currentValue = string.Empty;
                map.TryGetValue(realPropertyName, out currentValue);
                mapProperty.Add(item.Key, currentValue ?? string.Empty);
            }
            Console.WriteLine(JsonConvert.SerializeObject(mapProperty));

            return mapProperty;
        }

        public static string ToJson(   Dictionary<string, object> param)
        {
            var sortParam = param.OrderBy(_ => _.Key)
                .Aggregate(string.Empty, (current, p) => current + $"\"{p.Key}\":\"{p.Value}\",");//根据字母排序
            return "{" + sortParam.TrimEnd(',') + "}";
        }

        #endregion


        #region MyRegion Test

        public static Dictionary<string, string> test2()
        {
            var t = new Thang { };

            var t2 = new Thang { Thing = "Hey", Name = "long" };
            var dict = new Dictionary<string, string>();

            var mapProperty = new Dictionary<string, string>();
            Object obj;
            (obj, dict) = ObjectToMapWithDict(t);

            Console.WriteLine(JsonConvert.SerializeObject(dict));
            var serializedObj = JsonConvert.SerializeObject(obj);
            var map = ObjectToMap(t2);
            Dictionary<string, string> dictJsonProperty = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                JsonConvert.SerializeObject(t));
            var dictProperty = new Dictionary<string, string>();
            foreach (var item in dictJsonProperty)
            {
                var realPropertyName = dict[item.Value];
                dictProperty.Add(item.Key, dict[item.Value]);
                map.GetValueOrDefault(realPropertyName);
                mapProperty.Add(item.Key, map.GetValueOrDefault(realPropertyName));
            }
            Console.WriteLine(JsonConvert.SerializeObject(dictProperty));

            Console.WriteLine(JsonConvert.SerializeObject(mapProperty));

            return mapProperty;
        }

        public static void testMap()
        {

            var t2 = new SubKuaidiListItem { KuaidiName = "Hey", KuaidiNumber = "long" };
            var myType = t2.GetType();

            object myObj = System.Activator.CreateInstance(myType);



            var mapProperty = new Dictionary<string, string>();
            Object obj;
            (obj, mapProperty) = ObjectToMapWithDict(myObj);

            Console.WriteLine("=myObj=");
            Console.WriteLine(JsonConvert.SerializeObject(ObjectToMap(myObj)));

            Console.WriteLine("=obj=");

            Console.WriteLine(JsonConvert.SerializeObject(obj));

            Console.WriteLine("=mapProperty=");
            Console.WriteLine(JsonConvert.SerializeObject(mapProperty));
        }

 
        public static Dictionary<string, string> MapFormJsonPropertyFirst(Object objToMap)
        {

            var myType = objToMap.GetType();
            object myEmptyObj = System.Activator.CreateInstance(myType);

            Console.WriteLine(JsonConvert.SerializeObject(ObjectToMap(myEmptyObj)));
            //var myEmptyObj = new SubKuaidiListItem { };

            //var objToMap = new SubKuaidiListItem { KuaidiName = "Hey", KuaidiNumber = "long" };
            var dict = new Dictionary<string, string>(); 
            var mapProperty = new Dictionary<string, string>();
            Object mapToObj;
            (mapToObj, dict) = ObjectToMapWithDict(myEmptyObj);

            Console.WriteLine(JsonConvert.SerializeObject(dict));
            //var serializedObj = JsonConvert.SerializeObject(mapToObj);
            var map = ObjectToMap(objToMap);
            Dictionary<string, string> dictJsonProperty = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                JsonConvert.SerializeObject(myEmptyObj));
            //var dictProperty = new Dictionary<string, string>();
            foreach (var item in dictJsonProperty)
            {
                var realPropertyName = dict[item.Value];
                //dictProperty.Add(item.Key, dict[item.Value]);
                //map.GetValueOrDefault(realPropertyName);
                mapProperty.Add(item.Key, map.GetValueOrDefault(realPropertyName));
            }
            //Console.WriteLine(JsonConvert.SerializeObject(dictProperty));

            Console.WriteLine("=mapProperty=");
            Console.WriteLine(JsonConvert.SerializeObject(mapProperty));

            return mapProperty;
        }

        public static Dictionary<string, string> MapFormJsonProperty2()
        { 
            var t = new SubKuaidiListItem { };

            var t2 = new SubKuaidiListItem { KuaidiName = "Hey", KuaidiNumber = "long" };
            var dict = new Dictionary<string, string>();

            var mapProperty = new Dictionary<string, string>();
            Object obj;
            (obj, dict) = ObjectToMapWithDict(t);

            Console.WriteLine(JsonConvert.SerializeObject(dict));
            var serializedObj = JsonConvert.SerializeObject(obj);
            var map = ObjectToMap(t2);
            Dictionary<string, string> dictJsonProperty = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                JsonConvert.SerializeObject(t));
            var dictProperty = new Dictionary<string, string>();
            foreach (var item in dictJsonProperty)
            {
                var realPropertyName = dict[item.Value];
                dictProperty.Add(item.Key, dict[item.Value]);
                map.GetValueOrDefault(realPropertyName);
                mapProperty.Add(item.Key, map.GetValueOrDefault(realPropertyName));
            }
            Console.WriteLine(JsonConvert.SerializeObject(dictProperty));

            Console.WriteLine(JsonConvert.SerializeObject(mapProperty));

            return mapProperty;
        }


        /// <summary>
        /// 对象转换为字典
        /// </summary>
        /// <param name="obj">待转化的对象</param>
        /// <returns></returns>
        public static (object outObj, Dictionary<string, string> ) ObjectToMapWithDict(object obj)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            Type t = obj.GetType(); // 获取对象对应的类， 对应的类型

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance); // 获取当前type公共属性

            var index = 6000;
            foreach (PropertyInfo p in pi)
            {


                // 进行判NULL处理
                MethodInfo m = p.GetGetMethod();
                if (m.IsPublic)
                //if (m != null && m.IsPublic)
                {
                    index++;
                    var property = obj.GetType().GetProperty(p.Name);
                    property.SetValue(obj, index.ToString(), null);//类型转换。
                                                                   //map.Add(p.Name, $"{index}_{ m.Invoke(obj, new object[] { })}"); // 向字典添加元素

                    map.Add(index.ToString(), p.Name); // 向字典添加元素
                }
            }
            Console.WriteLine("------------");
            Console.WriteLine(JsonConvert.SerializeObject(obj));
            Console.WriteLine("------------");
            return (obj,map);
        }



        public int Age { get; set; }

        [JsonIgnore]
        public bool IsMarry { get; set; }

        public string Sex { get; set; }

        public static string ToJso()
        {
            //JsonSerializerSettings jsetting = new JsonSerializerSettings();
            //jsetting.ContractResolver = new LimitPropsContractResolver(new string[] { "Age", "IsMarry" });
            //Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));

            User u = new User();
            u.name = "ahbool";
            u.gender = "男";

            //输出此类的所有属性名和属性对应的值
            //Console.WriteLine();
            Console.WriteLine(getProperties(u));


            Console.WriteLine(JsonConvert.SerializeObject(ObjectToMap(u)));
            return "";
        }

        //输出结果为: name:ahbool,gender:男,age:,
        //遍历获取类的属性及属性的值：
        public static string getProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (properties.Length <= 0)
            {
                return tStr;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tStr += string.Format("{0}:{1},", name, value);
                }
                else
                {
                    getProperties(value);
                }
            }
            return tStr;
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


        #endregion
    }

    public class User
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
    }
    //实例化类，并给实列化对像的属性赋值：
}
