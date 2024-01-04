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
            _animation = new(720, 1280, SFML.Graphics.Color.White, new VideoRecorder(), new AudioRecorder(), new CanvasElementFactory(AnimationCanvas.Classes.AnimationCanvas.SoundsPath));
            timer1.Interval = 10000;
            //_animation.ConnectRecorder();
            
        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            _animation.StopAnimation();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _animation.StartAnimation();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}