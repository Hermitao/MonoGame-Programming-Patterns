using Microsoft.Xna.Framework.Input;

public static class KeyboardHandler
{
    static KeyboardState currentKeyState;
    static KeyboardState previousKeyState;

    public static KeyboardState GetState()
    {
        previousKeyState = currentKeyState;
        currentKeyState = Keyboard.GetState();
        return currentKeyState;
    }

    public static bool Held(Keys key)
    {
        return currentKeyState.IsKeyDown(key);
    }

    public static bool Shot(Keys key)
    {
        return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
    }

    public static bool Released(Keys key)
    {
        return !currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyDown(key);
    }
}