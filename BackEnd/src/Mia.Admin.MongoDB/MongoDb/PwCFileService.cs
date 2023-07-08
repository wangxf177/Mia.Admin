using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.MongoDB;

namespace Mia.Admin.MongoDb
{
    internal class MiaFileService : IMiaFileService
    {
        private readonly IAbpMongoDbContext _dbContext;
        public MiaFileService(IAbpMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(byte[] fileContents, string contentType, string fileDownloadName)> DocnloadFilesAsync(string fileId)
        {
            var bucket = GetBucket();
            GridFSDownloadStream? mongoStream = null;
            try
            {
                var fileName = string.Empty;
                var contentType = "application/octet-stream";
                if (ObjectId.TryParse(fileId, out ObjectId objectFileId))
                {
                    mongoStream = await bucket.OpenDownloadStreamAsync(objectFileId);
                    var filter = Builders<GridFSFileInfo>.Filter;
                    using var cursor = bucket.Find(filter.Eq("_id", objectFileId));
                    var fileInfo = await cursor.FirstOrDefaultAsync();
                    if (fileInfo != null && fileInfo.Metadata != null && fileInfo.Metadata.TryGetValue("ContentType", out BsonValue contentTypeTemp))
                    {
                        fileName = fileInfo.Filename;
                        contentType = contentTypeTemp.ToString() ?? contentType;
                    }
                }
                else
                {
                    mongoStream = await bucket.OpenDownloadStreamAsync(fileId);
                }
                byte[] bytes = new byte[mongoStream.Length];
                mongoStream.Read(bytes, 0, bytes.Length);
                return (bytes, contentType, fileName);
            }
            catch (Exception ex)
            {
                return (Array.Empty<byte>(), "", "");
            }
            finally
            {
                mongoStream?.Dispose();
            }

        }

        public async Task<string> UploadFileAsync(string fileName, string contentType, Stream fileStream)
        {
            var bucket = GetBucket();
            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    { "filename",fileName},
                    { "ContentType",contentType}
                }
            };
            var fileId = await bucket.UploadFromStreamAsync(fileName, fileStream, options);
            return fileId.ToString();
        }

        public async Task<string> UploadFileAsync(string fileName, string contentType, byte[] fileBytes)
        {
            var bucket = GetBucket();
            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    { "filename",fileName},
                    { "ContentType",contentType}
                }
            };
            var fileId = await bucket.UploadFromBytesAsync(fileName, fileBytes, options);
            return fileId.ToString();
        }

        private GridFSBucket GetBucket()
        {
            var options = new GridFSBucketOptions()
            {
                BucketName = "fs",
                ChunkSizeBytes = 1024 * 1024,
                WriteConcern = WriteConcern.WMajority,
                ReadPreference = ReadPreference.Secondary
            };

            return new GridFSBucket(_dbContext.Database, options);
        }
    }
}
