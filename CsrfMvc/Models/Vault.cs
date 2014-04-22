using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CsrfMvc.Models
{
    public class Vault
    {
        private static Lazy<Uri> redisCloudUrl = new Lazy<Uri>(() => new Uri(ConfigurationManager.AppSettings["REDISCLOUD_URL"].ToString()));

        public void AddToAccount(string accountName, double amount)
        {
            using (RedisClient redis = new RedisClient(redisCloudUrl.Value))
            {
                var currentValue = redis.Get<double>(accountName);
                redis.Set<double>(accountName, currentValue+amount);
            }
        }

        public double GetBalance(string accountName)
        {
            using (RedisClient redis = new RedisClient(redisCloudUrl.Value))
            {
                return redis.Get<double>(accountName);
            }
        }
    }
}