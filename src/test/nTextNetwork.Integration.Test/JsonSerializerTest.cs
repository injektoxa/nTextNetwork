using System.Collections.Generic;
using System.IO;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;
using nTextNetwork.Core.Test.Utils;
using NUnit.Framework;
using System.Linq;

namespace nTextNetwork.Integration.Test
{
    [TestFixture]
    public class JsonSerializerTest
    {
        [TestCase(@"Data\En\1661-8.txt")]
        public void Serialize_Dictionary_Take_nRecord(string fName)
        {
            TestPrecondition.EnsureFileExist(fName);
            const int expectedCount = 100;

            Stream stream = File.OpenRead(fName);

            ITextStatisticBuilder builder = new TextStatisticsBuilder();
            var stats = builder.Build(stream);

            var iterator = stats.WordFrequencyDictionary.Take(expectedCount);
            var dictionary = iterator.ToDictionary(pair => pair.Key, pair => pair.Value);

            var serrializer = new JsonSerializer<IDictionary<string, int>>();
            string json = serrializer.Serialize(dictionary);

            int actual = json.Split(':').Count() - 1;

            Assert.AreEqual(expectedCount, actual);
        }

        [Test]
        public void Serialize_Json_For_Jit()
        {
            IDictionary<string,int> dictionary = new Dictionary<string, int>();
            dictionary.Add(new KeyValuePair<string, int> ("Cat",1));
            dictionary.Add(new KeyValuePair<string, int>("Dog", 2));
            dictionary.Add(new KeyValuePair<string, int>("Rabbit", 3));
           
            var serrializer = new JsonSerializerForJit();
            string json = serrializer.Serialize(dictionary);
        }
    }
}