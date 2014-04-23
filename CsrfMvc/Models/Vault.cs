using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;

namespace CsrfMvc.Models
{
    [DataContract]
    public class UserBalance{
        [DataMember]
        public double Secure {get; set;}
        [DataMember]
        public double Insecure {get; set;}
        [DataMember]
        public double Nonstandard {get; set;}
    }
    public class Vault
    {
        private static Lazy<Uri> redisCloudUrl = new Lazy<Uri>(() => new Uri(ConfigurationManager.AppSettings["REDISCLOUD_URL"].ToString()));

        public void AddToAccount(string accountName, double secure = 0, double insecure = 0, double nonstandard = 0)
        {
            using (RedisClient redis = new RedisClient(redisCloudUrl.Value))
            {
                var currentValue = redis.Get<UserBalance>(accountName) ?? new UserBalance();
                currentValue.Secure += secure;
                currentValue.Insecure += insecure;
                currentValue.Nonstandard += nonstandard;
                redis.Set<UserBalance>(accountName, currentValue);
            }
        }

        public UserBalance GetBalance(string accountName)
        {
            using (RedisClient redis = new RedisClient(redisCloudUrl.Value))
            {
                return redis.Get<UserBalance>(accountName) ?? new UserBalance();
            }
        }
    }
}