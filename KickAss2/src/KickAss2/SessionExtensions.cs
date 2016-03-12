using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Features;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}

//Now you can store your complex objects like so:

//var myComplexObject = new MyClass();
//HttpContext.Session.SetObjectAsJson("Test", myComplexObject);
//and retrieve them just as easily:

//var myComplexObject = HttpContext.Session.GetObjectFromJson<MyClass>("Test");
