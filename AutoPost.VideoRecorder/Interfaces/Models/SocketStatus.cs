using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.VideoRecorder.Interfaces.Models
{
    public static class SocketStatus
    {
        public enum Status
        {
            ProcessNotFound,
            Disconnected,
            Connected
        }
    }
}
