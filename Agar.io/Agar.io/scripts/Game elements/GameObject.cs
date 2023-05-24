﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;

using Agar.io.scripts.Game_elements.Time;

namespace Gameobject
{
    public abstract class GameObject
    {
        private int id;

        protected Vector2f position;
        private Vector2f pivot;
        private Shape _sprite;

        private bool isPhysicsOn;

        public Shape Sprite
        {
            get
            {
                _sprite.Position = position + pivot;
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

        public virtual void Awake() { }
        public virtual void Update() { }
        protected void Destroy()
        {
            GameObjectLoop.GetInstance().RemoveObject(id);
        }
    }

    public class GameObjectLoop
    {
        private static GameObjectLoop? instance;

        private int numOfObjects;
        private Queue<GameObject> awakeQueue = new();
        private Dictionary<int, GameObject> objects = new();

        private RenderWindow window;

        private GameObjectLoop()
        {
            numOfObjects = 0;

            window = new(new VideoMode(1600, 900), "Ping pong");
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
            STime.ElapseTime();

            foreach (var obj in objects.Values)
            {
                obj.Update();
            }

            InvokeRender();
        }

        private void InvokeRender()
        {
            window.Clear(Color.Black);

            foreach (GameObject obj in objects.Values)
            {
                window.Draw(obj.Sprite);
            }

            window.Display();
        }

        public void AddObject(GameObject obj)
        {
            objects.Add(numOfObjects++, obj);
        }

        public void RemoveObject(int id)
        {
            objects.Remove(id);
        }
    }
}