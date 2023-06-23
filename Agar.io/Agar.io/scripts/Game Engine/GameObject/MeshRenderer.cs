using SFML.Graphics;

namespace AgarIO.scripts.GameEngine
{
    public class MeshRenderer
    {
        private GameObject parent;

        public Shape Sprite { 
            get {
                mesh.Position = parent.transform.position;
                mesh.Rotation = parent.transform.rotation;
                mesh.Scale = parent.transform.scale;

                return mesh;
            }

            set {
                mesh = value;
            }
        }

        public Texture Texture
        {
            get 
                => mesh.Texture;
            set 
                => mesh.Texture = value;
        }

        private Shape mesh;

        private MeshRenderer() { }

        public MeshRenderer(GameObject parent, Shape shape)
        {
            this.parent = parent;
            mesh = shape;

            GameObjectLoop.Instance += this;
        }

        public void OnDestroy()
        {
            GameObjectLoop.Instance -= this;
        }
    }
}
