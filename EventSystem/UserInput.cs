using Microsoft.Xna.Framework.Input;

namespace HelloMonoGame.EventSystem
{
    public class UserInput
    {
        // Get current key pressed.
        public KeyboardState CurrentKeyPressed()
        {
            KeyboardState currentKeyPressed = Keyboard.GetState();
            return currentKeyPressed;
        }
    }
}
