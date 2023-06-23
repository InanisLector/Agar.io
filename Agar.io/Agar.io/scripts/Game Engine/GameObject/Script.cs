namespace AgarIO.scripts.GameEngine
{ 
    public abstract class Script
    {
        protected GameObject parent;

        public virtual void Awake() { }

        public virtual void Update() { }
    }
}