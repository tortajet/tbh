using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechxmas.Extensions
{
    internal static class MovementExtensions
    {
        public static float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
        public static Vector2 HandleInput(this Vector2 velocity, CharacterBody2D body, float speed)
        {        
            // Get the input direction and handle the movement/deceleration.
            // As good practice, you should replace UI actions with custom gameplay actions.
            Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            Debug.WriteLine(direction);
            if (direction != Vector2.Zero)
            {
                velocity.X = direction.X * speed;
                velocity.Y = direction.Y * speed;
            }
            else
            {
                velocity.X = Mathf.MoveToward(body.Velocity.X, 0, speed);
                velocity.Y = Mathf.MoveToward(body.Velocity.Y, 0, speed);
            }
            
            return velocity;
        }

        public static Vector2 HandleGravity(this Vector2 velocity, CharacterBody2D body, float delta)
        {            
            // Add the gravity.
            if (!body.IsOnFloor())
                velocity.Y += gravity * delta;
                        
            return velocity;
        }
    }
}
