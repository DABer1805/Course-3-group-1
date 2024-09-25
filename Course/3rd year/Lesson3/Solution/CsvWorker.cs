using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
namespace CsvWork

{
    public class CsvWorker
    {
        public IEnumerable<Data> Read(string path)
        {
            using (var reader = new CsvReader(new StreamReader(path), new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return reader.GetRecords<Data>().ToList();
            }
        }

        public void Write(string path, IEnumerable<Data> data)
        {
            using (var writer = new CsvWriter(new StreamWriter(path), new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                writer.WriteRecords(data);
            }
        }
    }
}