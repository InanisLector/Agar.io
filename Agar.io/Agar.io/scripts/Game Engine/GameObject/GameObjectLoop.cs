using SFML.Graphics;

namespace AgarIO.scripts.GameEngine
{
    public class GameObjectLoop
    {
        private static GameObjectLoop? instance;

        private int numOfObjects;
        private Queue<GameObject> awakeQueue = new();
        private Dictionary<int, GameObject> objects = new();

        private GameObjectLoop()
        {
            numOfObjects = 0;
        }

        public static GameObjectLoop GetInstance()
        {
            if (instance == null)
                instance = new GameObjectLoop();

            return instance;
        }

        public void InvokeAwake()
        {
            while (awakeQueue.Count > 0)
            {
                awakeQueue.Dequeue().Awake();
            }
        }

        public void InvokeUpdate()
        {
            foreach (var obj in objects.Values)
            {
                obj.Update();
            }
        }

        public void InvokeRender(RenderWindow window)
        {
            window.Clear(Color.Black);

            foreach (GameObject obj in objects.Values)
            {
                if (!obj.IsRendered)
                    continue;

                window.Draw(obj.Sprite);
            }

            window.Display();
        }

        public void AddObject(GameObject obj, out int id)
        {
            awakeQueue.Enqueue(obj);
            id = numOfObjects;
            objects.Add(numOfObjects++, obj);
        }

        public void RemoveObject(int id)
        {
            objects.Remove(id);
        }

        public GameObject[] GetCollisions(GameObject obj)
        {
            List<GameObject> list = new();

            foreach (GameObject insideObj in objects.Values)
            {
                if (!insideObj.IsCollideable)
                    continue;

                if (obj.CheckCollision(insideObj))
                    if (obj != insideObj)
                        list.Add(insideObj);
            }

            return list.ToArray();
        }
    }
}
