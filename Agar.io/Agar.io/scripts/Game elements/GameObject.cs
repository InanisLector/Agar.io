using SFML.Graphics;
using SFML.System;

namespace AgarIO.scripts.GameElements.GameObject
{
    public abstract class GameObject
    {
        private int id;

        public Vector2f position { get; protected set; }
        private Vector2f pivot;
        private Shape _sprite;

        public Shape Sprite
        {
            get
            {
                _sprite.Position = position - pivot;
                return _sprite;
            }
            protected set
            {
                _sprite = value;
                pivot = value.Scale / 2;
            }
        }

        protected GameObject()
        {
            GameObjectLoop.GetInstance().AddObject(this, out id);
        }

        public virtual void Awake() { }
        public virtual void Update() { }
        protected void Destroy()
        {
            GameObjectLoop.GetInstance().RemoveObject(id);
        }

        public bool CheckCollision(GameObject obj)
        {
            FloatRect rect1 = this.Sprite.GetGlobalBounds();
            FloatRect rect2 = obj.Sprite.GetGlobalBounds();

            return rect1.Intersects(rect2);
        }
    }

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
            if(instance == null)
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
                if(obj.CheckCollision(insideObj))
                    if(obj != insideObj)
                        list.Add(insideObj);
            }

            return list.ToArray();
        }
    }
}