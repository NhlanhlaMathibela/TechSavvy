using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Newtonsoft.Json;
namespace TechSavvy.Models
{
    public static class SessionExtentions
    {
       //public static void SetJson<T>(this ISession session, string key, object value)
            //{
            //    session.SetString(key, JsonSerializer.Serialize(value));
            //}
            public static void SetJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
            public static T GetJson<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
            
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
            //public static T GetJson<T>(this ISession session, string key)
            //{
            //    var value = session.GetString(key);
            //    return value == null ? default : JsonSerializer.Deserialize<T>(value);
            //}
        
    }
}
