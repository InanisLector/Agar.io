using SFML.Window;

namespace AgarIO.scripts.GameEngine.Input
{
    internal class InputKey
    {
        public Keyboard.Key Key => key;

        private Keyboard.Key key;
        private bool wasPressed;

        private Action keyDownActions;
        private Action keyPressedActions;
        private Action keyUpActions;

        public InputKey(Keyboard.Key _key)
        {
            key = _key;
            wasPressed = false;
        }

        public void CheckInputs()
        {
            if (Keyboard.IsKeyPressed(key))
            {
                InvokeKeyPressedActions();

                if(!wasPressed)
                    InvokeKeyDownActions();
            }
            else
            {
                if (wasPressed)
                    InvokeKeyUpActions();
            }

            wasPressed = Keyboard.IsKeyPressed(key);

        }

        private void InvokeKeyDownActions()
            => keyDownActions?.Invoke();

        private void InvokeKeyPressedActions()
            => keyPressedActions?.Invoke();

        private void InvokeKeyUpActions()
            => keyUpActions?.Invoke();

        public void AddKeyDownAction(Action action)
            => keyDownActions += action;

        public void AddKeyPressedAction(Action action)
            => keyPressedActions += action;

        public void AddKeyUpAction(Action action)
            => keyUpActions += action;
    }
}
