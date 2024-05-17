using App75241305.Engine;
using Silk.NET.Maths;

//Import UI Elements
using App75241305.Accets.UI;
using Silk.NET.Vulkan;
using System.Security.Cryptography;

namespace App75241305.Engine

{
    internal unsafe class Engine 
    {
        private List<Vertex> vertices = new List<Vertex>();
        private List<ushort[]> indexListVertex = new List<ushort[]>();
        protected List<byte[]> Textures = new List<byte[]>();

        protected VkAPI vkAPI;
        public void Main()
        {
            
            vkAPI = new VkAPI(this);
            if (!vkAPI.GetStatusInit()) {
                Console.WriteLine("Error Init API Vulkan");
                return;
            }

            

        }

        protected void AddOBJ(Vertex[] vertex)
        {
            foreach(Vertex v in vertex) this.vertices.Add(v);
            ushort[] arrayDraw = new ushort[6];


            if (this.indexListVertex.Count != 0) {
                ushort startIndex = this.indexListVertex[this.indexListVertex.Count - 1][4];
                arrayDraw[0] = (ushort)(startIndex + 1);
                arrayDraw[1] = (ushort)(startIndex + 2);
                arrayDraw[2] = (ushort)(startIndex + 3);
                arrayDraw[3] = (ushort)(startIndex + 3);
                arrayDraw[4] = (ushort)(startIndex + 4);
                arrayDraw[5] = (ushort)(startIndex + 1);
                this.indexListVertex.Add(arrayDraw);
                return;
            }

            arrayDraw[0] = 0;
            arrayDraw[1] = 1;
            arrayDraw[2] = 2;
            arrayDraw[3] = 2;
            arrayDraw[4] = 3;
            arrayDraw[5] = 0;
            this.indexListVertex.Add(arrayDraw);

        }

        public Vertex[] GetVertex()
        {
            return this.vertices.ToArray();
        }

        public void AddTexture(byte[] Texture)
        {
            this.Textures.Add(Texture);
        }

        public List<byte[]> GetTexturesGen()
        { return this.Textures; }

        public ushort[] GetIndexArray ()
        {
            List<ushort> temp = new List<ushort>();
            foreach (ushort[] i in this.indexListVertex)
            {
                foreach (ushort j in i) temp.Add(j);
            }
            return temp.ToArray();
        }

          public void BuildUI()
        {


            AddOBJ(new Vertex[] {
                        new Vertex { pos = new Vector3D<float>(-125f,-75f, -2.0f), color = new Vector4D<float>(0.0f, 0.0f , 1.0f , 1.0f), TextureIndex = -1},
        new Vertex { pos = new Vector3D<float>(65f, -75f, -2.0f), color = new Vector4D<float>(0.0f, 0.0f , 1.0f , 1.0f), TextureIndex = -1},
        new Vertex { pos = new Vector3D<float>(65f,85f, -2.0f), color = new Vector4D<float>(0.0f, 0.0f , 1.0f , 1.0f), TextureIndex = -1},
        new Vertex { pos = new Vector3D<float>(-125f,85f, -2.0f), color = new Vector4D<float>(0.0f, 0.0f , 1.0f , 1.0f), TextureIndex = -1},
            });


            AddOBJ(new Vertex[] {
                        new Vertex { pos = new Vector3D<float>(-75f,-75f, -1.0f), color = new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.2f) , TextureIndex = -1},
        new Vertex { pos = new Vector3D<float>(75f,-75f, -1.0f), color = new Vector4D<float>(1.0f, 1.0f , 0.0f , 0.2f), TextureIndex = -1},
        new Vertex { pos = new Vector3D<float>(75f,75f, -1.0f), color =new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.7f), TextureIndex = -1},
        new Vertex { pos = new Vector3D<float>(-75f,75f, -1.0f), color = new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.7f), TextureIndex = -1},
            });

            new TextLable(this, new Vector4D<ushort>(255, 0, 0, 255), new Vector4D<ushort>(255, 255, 255, 0), "Hello world,\n Привіт світ, 子にちわ");
            AddOBJ(new Vertex[] {
                        new Vertex { pos = new Vector3D<float>(-200f,-120f, -1.0f), color = new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.2f),  textCoord = new Vector2D<float>(1.0f, 0.0f), TextureIndex = 1},
        new Vertex { pos = new Vector3D<float>(-200f,-200f, -1.0f), color = new Vector4D<float>(1.0f, 1.0f , 0.0f , 0.2f),  textCoord = new Vector2D<float>(0.0f, 0.0f), TextureIndex = 1},
        new Vertex { pos = new Vector3D<float>(-100f,-200f, -1.0f), color =new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.7f),  textCoord = new Vector2D<float>(0.0f, 1.0f), TextureIndex = 1},
        new Vertex { pos = new Vector3D<float>(-100f,-120f, -1.0f), color = new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.7f),  textCoord = new Vector2D<float>(1.0f, 1.0f), TextureIndex = 1},
            });

            new TextLable(this, new Vector4D<ushort>(255, 0, 0, 255), new Vector4D<ushort>(255, 255, 255, 0), "TEST");
            AddOBJ(new Vertex[] {
                        new Vertex { pos = new Vector3D<float>(-300f,-120f, -0.2f), color = new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.2f),  textCoord = new Vector2D<float>(1.0f, 0.0f), TextureIndex = 2},
        new Vertex { pos = new Vector3D<float>(-300f,-200f, -0.2f), color = new Vector4D<float>(1.0f, 1.0f , 0.0f , 0.2f),  textCoord = new Vector2D<float>(0.0f, 0.0f), TextureIndex = 2},
        new Vertex { pos = new Vector3D<float>(-210f,-200f, -0.2f), color =new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.7f),  textCoord = new Vector2D<float>(0.0f, 1.0f), TextureIndex = 2},
        new Vertex { pos = new Vector3D<float>(-210f,-120f, -0.2f), color = new Vector4D<float>(1.0f, 0.0f , 0.0f , 0.7f),  textCoord = new Vector2D<float>(1.0f, 1.0f), TextureIndex = 2},
            });

        }


        
    }

}
