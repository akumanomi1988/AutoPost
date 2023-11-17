using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.TikTokUploader
{
    public class TikTokParams
    {
        public string SesionID { get; set; }
        public string FilePath { get; set; }
        public string VideoTitle { get; set; }
        public string[] Tags { get; set; }
        public DateTimeOffset ScheduleTime { get; set; }

        public TikTokParams(string sesionID, string filePath, string videoTitle, string[] tags, DateTimeOffset scheduleTime)
        {
            SesionID = sesionID ?? throw new ArgumentNullException(nameof(sesionID));
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            VideoTitle = videoTitle ?? throw new ArgumentNullException(nameof(videoTitle));
            Tags = tags ?? throw new ArgumentNullException(nameof(tags));
            ScheduleTime = scheduleTime ;
        }
    }
}
