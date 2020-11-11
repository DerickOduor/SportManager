using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SportManager.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportManager.Models
{
    public static class SessionHelper
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            try
            {
                session.SetString(key, AppUtility.Encrypt(JsonConvert.SerializeObject(value)));
            }
            catch (Exception ex) { }
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(AppUtility.Decrypt(value));
            //JsonConvert.DeserializeObject<T>(value)
            //JsonConvert.DeserializeObject<T>(AppUtility.Decrypt(value))
        }

        public static bool validateOtp(this ISession session)
        {
            try
            {
                return (session.GetInt32("OTP_CONFIRMED") == 1) ? true : false;
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
