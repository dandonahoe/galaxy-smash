using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;



namespace GalaxySmash
{
    public class Input
    {
        private Device _keyboard;
        private Device _mouse;

        private MouseState _mouseState;
        private KeyboardState _keyboardState;

        public void Init(Control parent)
        {
            _keyboard = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
            _keyboard.SetCooperativeLevel(parent, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
            _keyboard.Acquire();

            _mouse = new Device(SystemGuid.Mouse);
            _mouse.SetCooperativeLevel(parent,
                CooperativeLevelFlags.NonExclusive |
                CooperativeLevelFlags.Background);

            _mouse.Acquire();
        }

        public void FrameMove()
        {
            FrameMoveMouse();
            FrameMoveKeyboard();
        }

        public MouseState Mouse
        {
            get { return _mouseState; }
        }

        public KeyboardState Keyboard
        {
            get { return _keyboardState; }
        }

        private void FrameMoveMouse()
        {
            _mouseState = _mouse.CurrentMouseState;

            byte[] buttons = _mouseState.GetMouseButtons();

            
        }

        private void FrameMoveKeyboard()
        {
            _keyboardState = _keyboard.GetCurrentKeyboardState();
        }
    }
}
