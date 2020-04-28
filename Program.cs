using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System.Threading.Tasks;

private static IAmazonS3 s3Client;

static void Main(string[] args)
{
s3Client = new AmazonS3Client(RegionEndpoint.USEast1);
var bucketName = args[0];
}
