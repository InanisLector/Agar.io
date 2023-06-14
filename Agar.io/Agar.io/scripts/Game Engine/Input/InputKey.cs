using SFML.Window;

namespace AgarIO.scripts.GameEngine.Input
{
    internal class InputKey
    {
        public Keyboard.Key Key => key;

        private Keyboard.Key key;
        private bool wasPressed;

        private List<Action> keyDownActions;
        private List<Action> keyPressedActions;
        private List<Action> keyUpActions;

        public InputKey(Keyboard.Key _key)
        {
            key = _key;
            wasPressed = false;

            keyDownActions = new();
            keyPressedActions = new();
            keyUpActions = new();
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
        {
            foreach (var action in keyDownActions)
            {
                action.Invoke();
            }
        }

        private void InvokeKeyPressedActions()
        {
            foreach (var action in keyPressedActions)
            {
                action.Invoke();
            }
        }

        private void InvokeKeyUpActions()
        {
            foreach (var action in keyUpActions)
            {
                action.Invoke();
            }
        }

        public void AddKeyDownAction(Action action)
            => keyDownActions.Add(action);

        public void AddKeyPressedAction(Action action)
            => keyPressedActions.Add(action);

        public void AddKeyUpAction(Action action)
            => keyUpActions.Add(action);
    }
}
