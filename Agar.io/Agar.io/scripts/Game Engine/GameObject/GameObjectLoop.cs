using SFML.Graphics;

namespace AgarIO.scripts.GameEngine
{
    public class GameObjectLoop
    {
        private static GameObjectLoop? _instance;
        public static GameObjectLoop Instance
        {
            get {
                if (_instance == null)
                    _instance = new GameObjectLoop();

                return _instance;
            }

            set { }
        }

        private Queue<GameObject> awakeQueue = new();
        private Queue<GameObject> deleteQueue = new();
        private List<GameObject> objects = new();
        private List<MeshRenderer> meshesToRender = new();

        private GameObjectLoop() { }

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

        #region GameObject add|remove

        public static GameObjectLoop operator +(GameObjectLoop loop, GameObject obj)
        {
            loop.AddObject(obj);

            return loop;
        }

        public void AddObject(GameObject obj)
        {
            awakeQueue.Enqueue(obj);
        }

        public static GameObjectLoop operator -(GameObjectLoop loop, GameObject obj)
        {
            loop.RemoveObject(obj);

            return loop;
        }

        public void RemoveObject(GameObject obj)
        {
            deleteQueue.Enqueue(obj);
        }

        #endregion

        #region Mesh add|remove

        public static GameObjectLoop operator +(GameObjectLoop loop, MeshRenderer mesh)
        {
            loop.AddMesh(mesh);

            return loop;
        }

        public void AddMesh(MeshRenderer mesh)
        {
            meshesToRender.Add(mesh);
        }

        public static GameObjectLoop operator -(GameObjectLoop loop, MeshRenderer mesh)
        {
            loop.RemoveMesh(mesh);

            return loop;
        }

        public void RemoveMesh(MeshRenderer mesh)
        {
            meshesToRender.Remove(mesh);
        }

        #endregion

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
