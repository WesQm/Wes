using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WESHybridFramework.Core.Utils
{
    class ScreenRecorder
    {
       // private ScreenCaptureJob screenCaptureJob = new ScreenCaptureJob();
        private readonly string OutputDirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public void SetVideoOutputLocation(string testName = "")
        {
            if (string.IsNullOrEmpty(testName))
                testName = "AutomationTest";
           // screenCaptureJob.OutputScreenCaptureFileName = Path.Combine(OutputDirectoryName, string.Format("{0}{1}.avi", testName, DateTime.UtcNow.ToString("MMddyyyy_Hmm")));
        }
        private void DeleteOldRecordings()
        {
            int daysCount = Convert.ToInt16(ConfigurationManager.AppSettings["recordingHistory"]);
            Directory.GetFiles(OutputDirectoryName)
                            .Select(f => new FileInfo(f))
                            .Where(f => (f.LastAccessTime < DateTime.Now.AddDays(-daysCount)) && (f.FullName.Contains(".avi")))
                            .ToList()
                            .ForEach(f => f.Delete());
        }
        public void StartRecording()
        {
            DeleteOldRecordings();
            //screenCaptureJob.Start();
        }
        public void StopRecording()
        {
            //screenCaptureJob.Stop();
        }
    }
}
