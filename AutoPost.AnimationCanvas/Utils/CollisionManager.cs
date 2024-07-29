using AutoPost.AnimationCanvas.Classes;
using AutoPost.AnimationCanvas.Elements;
using AutoPost.AnimationCanvas.Interfaces;
using SFML.System;

namespace AutoPost.AnimationCanvas.Utils
{
    public static class CollisionManager
    {
        public static void HandleCollisions(ICanvasElement element, List<ICanvasElement> canvasElements, Canvas canvas)
        {
            if (element is BallElement ball)
            {
                HandleWallCollisions(ball, canvas);
                HandleBallCollisions(ball, canvasElements);
            }
        }

        private static void HandleWallCollisions(BallElement ball, Canvas canvas)
        {
            if (ball.Shape.Position.X < 0)
            {
                ball.Velocity = new Vector2f(-ball.Velocity.X, ball.Velocity.Y);
                ball.Shape.Position = new Vector2f(0, ball.Shape.Position.Y);
            }
            else if (ball.Shape.Position.X + (ball.Shape.Radius * 2) > canvas.Width)
            {
                ball.Velocity = new Vector2f(-ball.Velocity.X, ball.Velocity.Y);
                ball.Shape.Position = new Vector2f(canvas.Width - (ball.Shape.Radius * 2), ball.Shape.Position.Y);
            }

            if (ball.Shape.Position.Y < 0)
            {
                ball.Velocity = new Vector2f(ball.Velocity.X, -ball.Velocity.Y);
                ball.Shape.Position = new Vector2f(ball.Shape.Position.X, 0);
            }
            else if (ball.Shape.Position.Y + (ball.Shape.Radius * 2) > canvas.Height)
            {
                ball.Velocity = new Vector2f(ball.Velocity.X, -ball.Velocity.Y);
                ball.Shape.Position = new Vector2f(ball.Shape.Position.X, canvas.Height - (ball.Shape.Radius * 2));
            }
        }
        public static bool CheckCollision(BallElement ball1, BallElement ball2)
        {
            if (ball1 == null || ball2 == null)
            {
                return false;
            }

            Vector2f delta = ball1.Shape.Position - ball2.Shape.Position;
            float distance = (float)Math.Sqrt((delta.X * delta.X) + (delta.Y * delta.Y));
            return distance < (ball1.Shape.Radius + ball2.Shape.Radius);
        }
        private static void HandleBallCollisions(BallElement ball, List<ICanvasElement> canvasElements)
        {
            foreach (ICanvasElement otherElement in canvasElements)
            {
                if (otherElement is BallElement otherBall && otherBall != ball && CheckCollision(ball, otherBall))
                {
                    ResolveCollision(ball, otherBall);
                }
            }
        }

        private static void ResolveCollision(BallElement ball1, BallElement ball2)
        {
            Vector2f delta = ball1.Shape.Position - ball2.Shape.Position;
            Vector2f collisionNormal = Normalize(delta);

            ball1.Sound.Play();
            ball1.Velocity = Reflect(ball1.Velocity, collisionNormal);
            ball2.Velocity = Reflect(ball2.Velocity, -collisionNormal);

            float overlap = ball1.Shape.Radius + ball2.Shape.Radius - Distance(ball1.Shape.Position, ball2.Shape.Position) + 1.0f;
            collisionNormal = Normalize(collisionNormal);
            ball1.Shape.Position += collisionNormal * overlap / 2f;
            ball2.Shape.Position -= collisionNormal * overlap / 2f;
        }

        private static Vector2f Normalize(Vector2f vector)
        {
            float length = (float)Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
            return length > 0 ? new Vector2f(vector.X / length, vector.Y / length) : vector;
        }

        private static Vector2f Reflect(Vector2f velocity, Vector2f normal)
        {
            return velocity - (2f * DotProduct(velocity, normal) * normal);
        }

        private static float DotProduct(Vector2f a, Vector2f b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        private static float Distance(Vector2f a, Vector2f b)
        {
            Vector2f delta = a - b;
            return (float)Math.Sqrt((delta.X * delta.X) + (delta.Y * delta.Y));
        }
    }
}
