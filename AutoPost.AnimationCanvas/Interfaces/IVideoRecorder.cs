﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.AnimationCanvas.Interfaces
{
    public interface IVideoRecorder
    {
        void StartRecording();
        void StopRecording();
        void SaveToFile(string filePath);
    }

}