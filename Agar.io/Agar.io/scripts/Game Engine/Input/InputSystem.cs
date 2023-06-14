using SFML.System;
using SFML.Window;

namespace AgarIO.scripts.GameEngine.Input
{
    public static class InputSystem
    {
        private static List<InputKey> keys = new();
        public static Vector2i MousePosition 
            => Mouse.GetPosition(GameEngine.Game.window);

        public static void CheckInput()
        {
            foreach (var key in keys)
            {
                key.CheckInputs();
            }
        }

        # region Key input

        public static void AddKeyDownBind(Keyboard.Key key, Action action)
            => GetInputKey(key).AddKeyDownAction(action);

        public static void AddKeyPressedBind(Keyboard.Key key, Action action)
            => GetInputKey(key).AddKeyPressedAction(action);

        public static void AddKeyUpBind(Keyboard.Key key, Action action)
            => GetInputKey(key).AddKeyUpAction(action);

        private static InputKey GetInputKey(Keyboard.Key key)
        {
            foreach (var _inputKey in keys)
            {
                if (_inputKey.Key == key)
                    return _inputKey;
            }

            InputKey inputKey = new(key);
            keys.Add(inputKey);

            return inputKey;
        }

        #endregion
    }
}
