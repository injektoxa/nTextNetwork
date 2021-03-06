using System;
using System.Configuration;
using System.IO;
using nTextNetwork.Core.Exceptions;
using nTextNetwork.Core.Impl;
using nTextNetwork.Core.Interfaces;
using NUnit.Framework;
using nTextNetwork.Core.Test.Utils;

namespace nTextNetwork.Core.Test.Impl
{
    [TestFixture]
    public class StreamConverterText
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToText_StreamIsNull_ArgumentNullException()
        {
            IStreamConverter c = new StreamConverter();
            c.ToText(null);
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ToText_StreamIsEmpty_ArgumentException()
        {
            IStreamConverter c = new StreamConverter();
            c.ToText(new MemoryStream());
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        [ExpectedException(typeof(ObjectIsTooLargeException))]
        public void ToText_StreamIsTooLarge_ObjectIsTooLargeException()
        {
            IStreamConverter c = new StreamConverter();
            string str = ConfigurationManager
                                    .AppSettings["maxAllowedInputBytes"];

            int max;
            TestPrecondition.EnsureCanParse(str, out max);
            string actual = c.ToText(new MemoryStream(new byte[max + 1]));
            Assert.Fail("Shouldn't reach this code");
        }

        [Test]
        public void ToText_Stream_StreamCanRead()
        {
            // Arrange
            IStreamConverter c = new StreamConverter();
            var random = new Random();
            var buffer = new byte[1024];
            random.NextBytes(buffer);
            var stream = new MemoryStream(buffer);
            
            // Act
            c.ToText(stream);

            Assert.IsTrue(stream.CanRead);
        }
    }
}