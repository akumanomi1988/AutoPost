using AutoPost.AnimationCanvas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.AnimationCanvas.Recorders
{ 
    public class AudioRecorder : IAudioRecorder 
    {
        public void StartRecording()
        {
            // Iniciar la grabación del audio
        }

        public void StopRecording()
        {
            // Detener la grabación
        }

        public void SaveToFile(string filePath)
        {
            // Guardar el audio en el archivo
        }
    }

}
