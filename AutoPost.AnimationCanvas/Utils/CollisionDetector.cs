﻿using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPost.AnimationCanvas.Utils
{
    public class CollisionDetector
    {
        public static bool CheckCollision(BallElement ball1, BallElement ball2)
        {
            if (ball1 == null || ball2 == null) return false;

            Vector2f delta = ball1.Shape.Position - ball2.Shape.Position;
            float distance = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);
            return distance < (ball1.Shape.Radius + ball2.Shape.Radius);
        }
    }


}