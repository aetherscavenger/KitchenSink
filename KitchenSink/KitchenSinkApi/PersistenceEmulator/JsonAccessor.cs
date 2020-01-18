using KitchenSink.Core.DataAccessor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenSinkApi.PersistenceEmulator
{
    /* 
     * Using JSON to emulate persisted storage
     * Put in transformers and emulate myriad of integrations once UI scaffolded
     */
    public class JsonAccessor : IDataAccessor
    {
        private IConfiguration _configuration;
        public JsonAccessor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Delete<T>(int id) where T : IEntity
        {
            //Performs a DELETE operation, if the record exists (based on ID) it deletes it.
            //This is normally not an expensive operation since MOST data persistence layers
            //use unique identifiers to query a specific object by ID using B-trees or other
            //indexing strategies. We are stuck with an O(N) operation here so this will NOT
            //scale well.
            var writeToMe = Read<T>();
            var exists = writeToMe.FirstOrDefault(w => w._id == id);
            if (exists == null)
                return;

            writeToMe.Remove(exists);
            var path = GetPath<T>();
            var json = JsonConvert.SerializeObject(writeToMe);
            File.WriteAllText(path, json);
        }

        public IList<T> Read<T>() where T : IEntity
        {
            var path = GetPath<T>();
            if (!File.Exists(path))
                throw new Exception("File does not exist.");
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public IList<T> Read<T>(IDictionary<string, object> parameters) where T : IEntity
        {
            /* 
             * KISS for now, filtering emulation not possible yet due to generic usage
             */
            return Read<T>();
        }

        public IResult<T> Write<T>(T writeMe, IDictionary<string, object> parameters) where T : IEntity
        {
            //Performs a MERGE operation, if the record exists (based on ID) it updates
            //the rest of the data, otherwise it inserts a new record.
            //This is normally not an expensive operation since MOST data persistence layers
            //use unique identifiers to query a specific object by ID using B-trees or other
            //indexing strategies. We are stuck with an O(N) operation here so this will NOT
            //scale well.
            var writeToMe = Read<T>();
            var exists = writeToMe.FirstOrDefault(w => w._id == writeMe._id);
            if (exists == null)
            {
                if(writeMe._id == default(int))
                    writeMe._id = writeToMe.Max(w => w._id) + 1;
                writeToMe.Add(writeMe);
            }
            else            
                exists.Replace(writeMe);
            
            var path = GetPath<T>();
            var json = JsonConvert.SerializeObject(writeToMe);
            File.WriteAllText(path, json);
            return new Result<T>(AccessorStatus.Succeeded, writeMe);
        }

        private string GetPath<T>()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(basePath, _configuration.GetSection("PersistenceEmulator")["JsonRoot"]);
            var filePath = Path.Combine(jsonPath, $"{typeof(T).Name}.json");
            return filePath;
        }
    }
}
