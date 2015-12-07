using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GunsOfGreatness
{
    struct Input
    {
        public bool pressed;
        public bool active;
        public bool released;
    }
    static class InputManager
    {
        public static Input Left
        {
            get { return _Left; }
        }
        static Input _Left;

        public static Input Right
        {
            get{ return _Right;}
        }
        static Input _Right;

        public static Input Up
        {
            get { return _Up; }
        }
        static Input _Up;

        public static Input Down
        {
            get{ return _Down; }
        }
        static Input _Down;

        public static Input Fire
        {
            get{ return _Fire; }
        }
        static Input _Fire;

        public static Input Jump
        {
            get { return _Jump; }
        }
        static Input _Jump;

        public static void UpdateManager()
        {
            KeyboardState keyState = Keyboard.GetState();
            GamePadState padState = GamePad.GetState(PlayerIndex.One);

            _Left = UpdateInput(keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left) || padState.ThumbSticks.Left.X < -0.5f, _Left);
            _Down = UpdateInput(keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down) || padState.ThumbSticks.Left.Y < -0.5f,_Down);
            _Up = UpdateInput(keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up) || padState.ThumbSticks.Left.Y > 0.5f,_Up);
            _Right = UpdateInput(keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right) || padState.ThumbSticks.Left.X > 0.5f,_Right);
            _Fire = UpdateInput(keyState.IsKeyDown(Keys.X) || padState.Buttons.X == ButtonState.Pressed,_Fire);
            _Jump = UpdateInput(keyState.IsKeyDown(Keys.Z) || padState.Buttons.A == ButtonState.Pressed, _Jump);

        }

        static Input UpdateInput(bool currInput,Input inputWrapper)
        {
            if(inputWrapper.active)
            {
                if (currInput)
                {
                    inputWrapper.active = true;
                    inputWrapper.pressed = false;
                    inputWrapper.released = false;
                }
                else
                {
                    inputWrapper.active = false;
                    inputWrapper.pressed = false;
                    inputWrapper.released = true;
                }
            }
            else
            {
                if(currInput)
                {
                    inputWrapper.active = true;
                    inputWrapper.pressed = true;
                    inputWrapper.released = false;
                }
                else
                {
                    inputWrapper.active = false;
                    inputWrapper.pressed = false;
                    inputWrapper.released = false;
                }
   //             inputWrapper.
            }

            return inputWrapper;
//           inputWrapper.
        }
    }
}
