using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System.Threading.Tasks;


namespace MyS3
{
    class Program
    {
        private static IAmazonS3 s3Client;
        private const string filePath = "/home/ubuntu/environment/README.md";

        static void Main(string[] args)
        {
           s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
            var bucketName = args[0];
            
            //Create Bucket
            s3Client.PutBucketAsync(bucketName).Wait();
            Console.WriteLine("Created the bucket named '{0}'.", bucketName);
            
             // List available buckets
              var response = s3Client.ListBucketsAsync().Result;
        
              foreach (var bucket in response.Buckets)
              {
                Console.WriteLine(bucket.BucketName);
              }
           //   Delete bucket
              s3Client.DeleteBucketAsync(bucketName).Wait();
              Console.WriteLine("Deleted the bucket named '{0}'.", bucketName);
              
           // Upload a file
	       UploadFileAsync().Wait();


        }
        
         private static async Task UploadFileAsync()
        {
            var fileTransferUtility = new TransferUtility(s3Client);    
            await fileTransferUtility.UploadAsync(filePath, "nam-test-bucket1001");
            Console.WriteLine("File upload completed");
        }

    }
}
