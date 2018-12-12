using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreMvc.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session,string key)
        {
            session.SetString("1","2");
        }
        public static string GetObject(this ISession session)
            {
            return "deneme";
        }
        
    }
}
