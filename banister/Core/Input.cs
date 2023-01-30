using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace banister.Core;

public class Input
{
    private static KeyboardState _prevKeyboardState = Keyboard.GetState();
    private static KeyboardState _currentKeyboardState = Keyboard.GetState();
    private static MouseState _prevMouseState = Mouse.GetState();
    private static MouseState _currentMouseState = Mouse.GetState();

    private static bool _isGameInFocus = true;

    private Input() { }

    public static Vector2 MousePosition => new Vector2(_currentMouseState.X, _currentMouseState.Y);

    public static void Update(bool isGameInFocus)
    {
        Input._isGameInFocus = isGameInFocus;

        _prevKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();

        _prevMouseState = _currentMouseState;
        _currentMouseState = Mouse.GetState();
    }

    public static bool IsKeyPressed(Keys key) => _currentKeyboardState.IsKeyDown(key) && _prevKeyboardState.IsKeyUp(key);

    public static bool IsKeyDown(Keys key) => _currentKeyboardState.IsKeyDown(key);

    public static bool LeftMousePressed() =>
        _isGameInFocus && _currentMouseState.LeftButton == ButtonState.Pressed 
        && _prevMouseState.LeftButton == ButtonState.Released;

    public static bool RightMousePressed() =>
        _isGameInFocus && _currentMouseState.RightButton == ButtonState.Pressed
        && _prevMouseState.RightButton == ButtonState.Released;
}
