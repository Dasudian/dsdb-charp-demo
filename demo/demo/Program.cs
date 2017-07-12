using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dasudian.dsdb.sdk;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DsdbClient client = new DsdbClient();
            ErrorCode ret;

            client.setDebug();

            ret = client.connect();
            if (ErrorCode.Success == ret)
            {
                Console.WriteLine("successfully connect to dsdb server");
            }
            else
            {
                Console.WriteLine("failed to connect to dsdb server, ret " + ret);
                goto exit;
            }

            String bucketType = "people";
            String bucket = "bird";
            String key = "canFly";
            String value = "true";

            ret = client.put(bucketType, bucket, key, value);
            if (ErrorCode.Success == ret)
            {
                Console.WriteLine("successfully put data, bucketType {0} bucket {1} key {2} value {3}",
                    bucketType, bucket, key, value);
            }
            else
            {
                Console.WriteLine("failed to put data to dsdb server, ret " + ret);
            }

            String valueGet;
            ret = client.get(bucketType, bucket, key, out valueGet);
            if (ErrorCode.Success == ret)
            {
                Console.WriteLine("successfully get data, bucketType {0} bucket {1} key {2} value {3}",
                    bucketType, bucket, key, valueGet);
            }
            else
            {
                Console.WriteLine("failed to get data from dsdb server, ret " + ret);
            }

            ret = client.delete(bucketType, bucket, key);
            if (ErrorCode.Success == ret)
            {
                Console.WriteLine("successfully delete data, bucketType {0} bucket {1} key {2}",
                    bucketType, bucket, key);
            }
            else
            {
                Console.WriteLine("failed to delete data of dsdb server, ret " + ret);
            }

            client.disconnect();
exit:
            Console.ReadKey();
        }
    }
}