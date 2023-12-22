using AutoPost.AnimationCanvas.Factories;
using AutoPost.AnimationCanvas.Recorders;
using SFML.Graphics;
using SFML.System;

namespace AutoPost.AnimationCanva.Test
{
    public partial class Form1 : Form
    {
        private readonly AnimationCanvas.Classes.AnimationCanvas _animation;


        public Form1()
        {
            InitializeComponent();
            _animation = new(480,720,SFML.Graphics.Color.White,new VideoRecorder(),new AudioRecorder(),new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));

        }

        private  void btnStart_Click(object sender, EventArgs e)
        {
             _animation.StartAnimation();
        }
        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //     _animation.StartAnimationAsync();
        //}
    }
}