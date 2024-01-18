using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.ViewModel
{
    public class PostUploaderSettings
    {
        public PostUploaderSettings() { }
        public string SessionID { get; set; } = "";
        public string DefaultVideoFolder { get; set; } = "";
    }
}
