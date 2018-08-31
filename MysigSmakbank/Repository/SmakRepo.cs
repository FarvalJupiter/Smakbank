using System;
using System.Collections.Generic;
using System.Linq;
using MysigSmakbank.Models.Entities;
using Newtonsoft.Json;
using MysigSmakbank.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Text;

namespace MysigSmakbank.Repository
{
    public class SmakRepo : ISmakRepo
    {
        private readonly BlobConfiguration _blobConfiguration;
        private readonly CloudBlobContainer _container;

        public SmakRepo(IOptions<BlobConfiguration> blobconfig)
        {
            _blobConfiguration = blobconfig.Value;

            CloudStorageAccount storageAccount = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                _blobConfiguration.name,
                _blobConfiguration.key), true);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            _container = blobClient.GetContainerReference("fil");
        }

        public void CreateSmak(BeverageBase collection)
        {
            collection.Id = Guid.NewGuid();
            try
            {

                var newBlob = _container.GetBlockBlobReference("smak.txt");

                SharedAccessBlobPolicy adHocSAS = new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddSeconds(30),
                    Permissions = SharedAccessBlobPermissions.Read
                };

                string sasBlobToken = newBlob.GetSharedAccessSignature(adHocSAS);
                string stringtext;
                using (var streamtest = newBlob.OpenReadAsync())
                {
                    var stream = streamtest.Result;
                    byte[] bytes = new byte[stream.Length + 10];
                    int numBytesToRead = (int)stream.Length;
                    int numBytesRead = 0;
                    do
                    {
                        // Read may return anything from 0 to 10.
                        int n = stream.Read(bytes, numBytesRead, 10);
                        numBytesRead += n;
                        numBytesToRead -= n;
                    } while (numBytesToRead > 0);
                    stringtext = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                }
                var smaker = JsonConvert.DeserializeObject<List<BeverageBase>>(stringtext);
                if (smaker == null)
                {
                    smaker = new List<BeverageBase>();
                }
                smaker.Add(collection);
                var smakerstring = JsonConvert.SerializeObject(smaker);
                var bytesToWrite = Encoding.ASCII.GetBytes(smakerstring);
                using (var streamwriter = newBlob.OpenWriteAsync())
                {
                    var writer = streamwriter.Result;
                    int numBytesToWrite = (int)bytesToWrite.Length;
                    writer.Write(bytesToWrite, 0, numBytesToWrite);
                    writer.CommitAsync();

                }
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void EditSmak(BeverageBase collection)
        {
            try
            {
                var newBlob = _container.GetBlockBlobReference("smak.txt");

                SharedAccessBlobPolicy adHocSAS = new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = DateTime.UtcNow.AddSeconds(30),
                    Permissions = SharedAccessBlobPermissions.Read
                };

                string sasBlobToken = newBlob.GetSharedAccessSignature(adHocSAS);
                string stringtext;
                using (var streamtest = newBlob.OpenReadAsync())
                {
                    var stream = streamtest.Result;
                    byte[] bytes = new byte[stream.Length + 10];
                    int numBytesToRead = (int)stream.Length;
                    int numBytesRead = 0;
                    do
                    {
                        // Read may return anything from 0 to 10.
                        int n = stream.Read(bytes, numBytesRead, 10);
                        numBytesRead += n;
                        numBytesToRead -= n;
                    } while (numBytesToRead > 0);
                    stringtext = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                }
                var smaker = JsonConvert.DeserializeObject<List<BeverageBase>>(stringtext);
                if (smaker == null)
                {
                    smaker = new List<BeverageBase>();
                }
                smaker.First(s => s.Id == collection.Id).Grapes = collection.Grapes;
                smaker.First(s => s.Id == collection.Id).Name = collection.Name;
                smaker.First(s => s.Id == collection.Id).OtherNotes = collection.OtherNotes;
                smaker.First(s => s.Id == collection.Id).Producer = collection.Producer;
                smaker.First(s => s.Id == collection.Id).SelectedProductionYear = collection.SelectedProductionYear;
                smaker.First(s => s.Id == collection.Id).SelectedPurchaseYear = collection.SelectedPurchaseYear;
                smaker.First(s => s.Id == collection.Id).Taste = collection.Taste;
                smaker.First(s => s.Id == collection.Id).CountAtHome = collection.CountAtHome;
                smaker.First(s => s.Id == collection.Id).Country = collection.Country;
                smaker.First(s => s.Id == collection.Id).Fragrance = collection.Fragrance;
                var smakerstring = JsonConvert.SerializeObject(smaker);
                var bytesToWrite = Encoding.ASCII.GetBytes(smakerstring);
                using (var streamwriter = newBlob.OpenWriteAsync())
                {
                    var writer = streamwriter.Result;
                    int numBytesToWrite = (int)bytesToWrite.Length;
                    // int numBytesWrite = 0;
                    writer.Write(bytesToWrite, 0, numBytesToWrite);
                    writer.CommitAsync();
                    //do
                    //{
                    //    // Read may return anything from 0 to 10.
                    //    writer.Write(bytesToWrite, numBytesWrite, 10);
                    //    numBytesWrite += n;
                    //    numBytesToWrite -= n;
                    //} while (numBytesToWrite > 0);
                }
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeverageBase> GetAllSmak()
        {
            var newBlob = _container.GetBlockBlobReference("smak.txt");

            SharedAccessBlobPolicy adHocSAS = new SharedAccessBlobPolicy()
            {
                SharedAccessExpiryTime = DateTime.UtcNow.AddSeconds(30),
                Permissions = SharedAccessBlobPermissions.Read
            };

            string sasBlobToken = newBlob.GetSharedAccessSignature(adHocSAS);
            string stringtext;
            using (var streamtest= newBlob.OpenReadAsync())
            {
                var stream = streamtest.Result;
                byte[] bytes = new byte[stream.Length + 10];
                int numBytesToRead = (int)stream.Length;
                int numBytesRead = 0;
                do
                {
                    // Read may return anything from 0 to 10.
                    int n = stream.Read(bytes, numBytesRead, 10);
                    numBytesRead += n;
                    numBytesToRead -= n;
                } while (numBytesToRead > 0);
                stringtext=Encoding.UTF8.GetString(bytes, 0, bytes.Length);

            }
           
            var smaker = JsonConvert.DeserializeObject<List<BeverageBase>>(stringtext);
            return smaker;
        }
    }
}
