using System;
using StackExchange.Redis;

namespace Task04
{
    class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString = "redis-19933.c1.us-west-2-2.ec2.cloud.redislabs.com:19933,password=OFvYs20jHXNJu5xRgHh979jywCRwoXe2,allowAdmin=true")
        {
            redis = ConnectionMultiplexer.Connect(connectionString);
            database = redis.GetDatabase();
        }

        public static string Get(string key)
        {
            return database.KeyExists(key) ? database.StringGet(key) : "Склада нет";
        }

        public static bool Exist(string key, string value)
        {
            if (database.KeyExists(key))
            {
                return database.StringGet(key).ToString().Contains(value);
            }
            else
            {
                return false;
            }
        }

        public static void Add(string key, string value)
        {
            if (database.KeyExists(key))
            {
                database.StringAppend(key, $" {value}");
            }
            else
            {
                database.StringAppend(key, $"{value}");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            RedisClient.Connect();
            string request = Console.ReadLine();
            string[] nameAndSettings = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (nameAndSettings[0] != "exit")
            {
                try
                {
                    if (nameAndSettings[0] == "add")
                    {
                        RedisClient.Add(nameAndSettings[1], nameAndSettings[2]);
                    }
                    if (nameAndSettings[0] == "get")
                    {
                        Console.WriteLine(RedisClient.Get(nameAndSettings[1]));
                    }
                    if (nameAndSettings[0] == "exist")
                    {
                        Console.WriteLine(RedisClient.Exist(nameAndSettings[1], nameAndSettings[2]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    request = Console.ReadLine();
                    nameAndSettings = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }
    }
}
