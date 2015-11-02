﻿using Managed.Adb.IO;
using Managed.Adb.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managed.Adb.Extensions.Tests
{
    [TestClass]
    public class AdbHelperIntegrationTests : BaseDeviceTests
    {
        [TestMethod]
        [TestCategory("IntegrationTest")]
        public void FileListingServiceTest()
        {
            Device device = GetFirstDevice();
            FileListingService fileListingService = new FileListingService(device);

            FileEntry[] entries = fileListingService.GetChildren(fileListingService.Root, false, null);
            foreach (var item in entries)
            {
                Console.WriteLine(item.FullPath);
            }
        }

        private String CreateTestFile()
        {
            String tfile = Path.GetTempFileName();
            Random r = new Random((int)DateTime.Now.Ticks);

            using (var fs = new FileStream(tfile, System.IO.FileMode.Create, FileAccess.Write))
            {
                for (int i = 0; i < 1024; i++)
                {
                    byte[] buffer = new byte[1024];
                    r.NextBytes(buffer);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            return tfile;
        }
    }
}
