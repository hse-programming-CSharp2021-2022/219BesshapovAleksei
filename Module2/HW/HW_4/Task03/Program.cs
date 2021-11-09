using System;
using StackExchange.Redis;

namespace Task03
{
    class RedisClient
    {
        public const uint MaxCount = 5;
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString = "redis-19933.c1.us-west-2-2.ec2.cloud.redislabs.com:19933,password=OFvYs20jHXNJu5xRgHh979jywCRwoXe2,allowAdmin=true")
        {
            redis = ConnectionMultiplexer.Connect(connectionString);
            database = redis.GetDatabase();
        }

        public static string Get(string key)
        {
            return Exist(key) ? database.ListGetByIndex(key, database.ListLength(key) - 1) : "Данных не существует"; 
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static void Add(string key, string value)
        {
            if (Exist(key))
            {
                if ((uint)database.ListLength(key) < MaxCount)
                {
                    database.ListRightPush(key, value);
                }
                else
                {
                    Console.WriteLine("Предельное количество записей");
                }
            }
            else
            {
                database.ListRightPush(key, value);
            }
        }

        public static string Back(string key)
        {
            database.ListRightPop(key);
            if (database.ListLength(key) != 0)
            {
                return database.ListGetByIndex(key, database.ListLength(key) - 1);
            }
            else
            {
                database.KeyDelete(key);
                return "Данные удалены";
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
                    if (nameAndSettings[0] == "back")
                    {
                        Console.WriteLine(RedisClient.Back(nameAndSettings[1]));
                    }
                    if (nameAndSettings[0] == "get")
                    {
                        Console.WriteLine(RedisClient.Back(nameAndSettings[1]));
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
