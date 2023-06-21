using SFML.Graphics;

namespace AgarIO.scripts.GameEngine
{
    public class GameObjectLoop
    {
        private static GameObjectLoop? instance;

        private Queue<GameObject> awakeQueue = new();
        private Queue<GameObject> deleteQueue = new();
        private List<GameObject> objects = new();

        private GameObjectLoop() { }

        public static GameObjectLoop GetInstance()
        {
            if (instance == null)
                instance = new GameObjectLoop();

            return instance;
        }

        private void InvokeAwake()
        {
            while (awakeQueue.Count > 0)
            {
                var obj = awakeQueue.Dequeue();
                objects.Add(obj);
                obj.CallAwake();
            }
        }

        private void InvokeUpdate()
        {
            foreach (var obj in objects)
            {
                obj.CallUpdate();
            }
        }

        private void InvokeRender()
        {
            var window = Game.window;
            window.Clear(Color.Black);

            foreach (GameObject obj in objects)
            {
                if (!obj.IsRendered)
                    continue;

                window.Draw(obj.Sprite);
            }

            window.Display();
        }

        private void InvokeDeletion()
        {
            while (deleteQueue.Count > 0)
            {
                objects.Remove(deleteQueue.Dequeue());
            }
        }

        public void InvokeCycleTurn()
        {
            InvokeAwake();
            InvokeUpdate();
            InvokeRender();
            InvokeDeletion();
        }

        public void AddObject(GameObject obj)
        {
            awakeQueue.Enqueue(obj);
        }

        public void RemoveObject(GameObject obj)
        {
            deleteQueue.Enqueue(obj);
        }

        public GameObject[] GetCollisions(GameObject obj)
        {
            List<GameObject> list = new();

            foreach (GameObject insideObj in objects)
            {
                if (!insideObj.IsCollideable)
                    continue;

                if (obj.CheckCollision(insideObj))
                    if (obj != insideObj)
                        list.Add(insideObj);
            }

            return list.ToArray();
        }

        public GameObject? GetFirstWithTag(string tag)
        {
            foreach (var obj in objects)
            {
                if(obj.ContainsTag(tag))
                    return obj;
            }

            return null;
        }

        public GameObject[] GetAllWithTag(string tag)
        {
            List<GameObject> output = new();

            foreach (var obj in objects)
            {
                if (obj.ContainsTag(tag))
                    output.Add(obj);
            }

            return output.ToArray();
        }
    }
}
