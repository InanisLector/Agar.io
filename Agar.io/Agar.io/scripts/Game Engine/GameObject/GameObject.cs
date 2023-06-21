using SFML.Graphics;
using SFML.System;

namespace AgarIO.scripts.GameEngine
{
    public abstract class GameObject
    {
        protected List<string> tags = new();

        public Vector2f position { get; protected set; }
        private Vector2f pivot;
        private Shape? _sprite;

        public bool IsRendered 
            { get; protected set; } = true;
        public bool IsCollideable 
            { get; protected set; } = true;

        protected bool IsDead = false;

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
            GameObjectLoop.GetInstance().AddObject(this);
        }

        public void CallAwake()
        {
            if (IsDead)
                return;

            Awake();
        }

        protected virtual void Awake() { }

        public void CallUpdate()
        {
            if (IsDead)
                return;

            Update();
        }

        protected virtual void Update() { }

        protected void Destroy()
        {
            IsDead = true;

            GameObjectLoop.GetInstance().RemoveObject(this);
        }

        public bool CheckCollision(GameObject obj)
        {
            FloatRect rect1 = this.Sprite.GetGlobalBounds();
            FloatRect rect2 = obj.Sprite.GetGlobalBounds();

            return rect1.Intersects(rect2);
        }

        public bool ContainsTag(string tag)
        {
            foreach (var _tag in tags)
            {
                if(_tag == tag)
                    return true;
            }

            return false;
        }
    }
}