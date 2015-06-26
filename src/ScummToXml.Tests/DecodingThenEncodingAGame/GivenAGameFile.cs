using System.IO;
using NUnit.Framework;
using ScummToXml.Domain;
using ScummToXml.Readers;
using ScummToXml.Writers;

namespace ScummToXml.Tests.DecodingThenEncodingAGame
{    
    [TestFixture]
    public class GivenAGameFile
    {
        private const string TestFile = "../../../../mi2/MONKEY2.001";
        private const string OutFile = "../../../../mi2.MONKEY2.001.OUT";

        [Test]
        public void Test()
        {
            var file = new FileReader().Read(TestFile);
            if (File.Exists(OutFile)) File.Delete(OutFile);
            new FileWriter().Write(OutFile, file);

            FileAssert.AreSameContents(TestFile, OutFile);
        }
    }

    public static class FileAssert
    {
        public static void AreSameContents(string srcFileName, string dstFileName)
        {
            const int bufferSize = 1 << 16;

            var src = new FileInfo(srcFileName);
            var dst = new FileInfo(dstFileName);

            using (Stream srcStream = src.OpenRead(),
                dstStream = dst.OpenRead())
            {
                var srcBuf = new byte[bufferSize];
                var dstBuf = new byte[bufferSize];
                int len;
                while ((len = srcStream.Read(srcBuf, 0, srcBuf.Length)) > 0)
                {
                    dstStream.Read(dstBuf, 0, dstBuf.Length);
                    for (int i = 0; i < len; i++)
                        if (srcBuf[i] != dstBuf[i])
                            Assert.Fail("Files differ at index " + ((srcStream.Position - srcBuf.Length) + i));
                }
                Assert.Pass();
            }
        }
    }
}
