﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MaxMind.GeoIP2;

namespace Arma3BEClient.Common.Helpers
{
    public static class IPInfo
    {
        public async static Task<string> Get(string ip)
        {
            if (string.IsNullOrEmpty(ip)) return string.Empty;
            var c = new HttpClient();
            var pattern = ConfigurationManager.AppSettings["IPServicePattern"];
            var data = await c.GetStringAsync(string.Format(pattern, ip));
            return data;
        }

        public static string GetCountryLocal(string ip)
        {
            if (string.IsNullOrEmpty(ip)) return string.Empty;

            try
            {
                using (var reader = new DatabaseReader(@"IPDatabase\GeoLite2-City.mmdb"))
                {

                    var city = reader.City(ip);
                    return city.Country.Name;
                }
            }
            catch(Exception e)
            {
                return string.Empty;
            }
        }
    }
}