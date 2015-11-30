using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GunsOfGreatness
{
    static class InputManager
    {
        public static bool Left
        {
            get { return _Left; }
        }
        static bool _Left;

        public static bool Right
        {
            get{ return _Right;}
        }
        static bool _Right;

        public static bool Up
        {
            get { return _Up; }
        }
        static bool _Up;

        public static bool Down
        {
            get{ return _Down; }
        }
        static bool _Down;

        public static bool Fire
        {
            get{ return _Fire; }
        }
        static bool _Fire;

        public static bool Jump
        {
            get { return _Jump; }
        }
        static bool _Jump;

        public static void UpdateInput()
        {
            KeyboardState keyState = Keyboard.GetState();
            GamePadState padState = GamePad.GetState(PlayerIndex.One);
             
            _Left = keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left) || padState.ThumbSticks.Left.X < -0.5f;
            _Down = keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down) || padState.ThumbSticks.Left.Y < -0.5f;
            _Up = keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up) || padState.ThumbSticks.Left.Y > 0.5f;
            _Right = keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right) || padState.ThumbSticks.Left.X > 0.5f;
            _Fire = keyState.IsKeyDown(Keys.X) || padState.Buttons.X == ButtonState.Pressed;
            _Jump = keyState.IsKeyDown(Keys.Z) || padState.Buttons.A == ButtonState.Pressed;

        }
    }
}
