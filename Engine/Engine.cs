using App75241305.Engine;
using Silk.NET.Maths;

//Import UI Elements
using App75241305.Accets.UI;

namespace App75241305.Engine

{
    internal unsafe class Engine 
    {
        private List<Vertex> vertices = new List<Vertex>();
        private List<ushort[]> indexListVertex = new List<ushort[]>();
        protected List<byte[]> Textures = new List<byte[]>();
        private List<BoxDraw> OBJs = new List<BoxDraw>();
        private List<string> IndexsUpdate = new List<string>();

        private float FPS = 0.0f;
        private int coutFrames = 0;

        protected VkAPI vkAPI;
        public void Main()
        {
            vkAPI = new VkAPI(this);
            if (!vkAPI.GetStatusInit()) {
                Console.WriteLine("Error Init API Vulkan");
                return;
            }
        }


        public void AddOBJ(BoxDraw OBJ)
        {
            OBJ.setID(OBJ.GetHashCode().ToString());
            OBJs.Add(OBJ);
            foreach (Vertex vertexArr in OBJ.GetGroupeVertex())  this.vertices.Add(vertexArr);
            ushort[] arrayDraw = new ushort[6];


            if (this.indexListVertex.Count != 0) {
                OBJ.FirstIndexVertex = this.indexListVertex[this.indexListVertex.Count - 1][4];
                arrayDraw[0] = (ushort)(OBJ.FirstIndexVertex + 1);
                arrayDraw[1] = (ushort)(OBJ.FirstIndexVertex + 2);
                arrayDraw[2] = (ushort)(OBJ.FirstIndexVertex + 3);
                arrayDraw[3] = (ushort)(OBJ.FirstIndexVertex + 3);
                arrayDraw[4] = (ushort)(OBJ.FirstIndexVertex + 4);
                arrayDraw[5] = (ushort)(OBJ.FirstIndexVertex + 1);
                this.indexListVertex.Add(arrayDraw);
                return;
            }
            OBJ.FirstIndexVertex = 0;
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

        public void UpdateTextureByIndex(int Index, byte[] Texture)
        {
            this.Textures[Index] = Texture;
        }


        public void UpdateListIndexOBJ (string Index)
        {
            IndexsUpdate.Add(Index);
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
            AddOBJ(new BoxDraw(
                this, 
                "TextLable", 
                SizeBoxL: [120, 120],
                PositionL: [80, 0], 
                BackgroundColor: new Vector4D<float>(1.0f, 0.0f, 1.0f, 1.0f), 
                ZIndex: 0.1f, 
                TextureIndex: 1, 
                Text: "Hello World"));
            
        }

        int x = 0;
        /*public void UpdateSate(double delta)
        {
            coutFrames++;
            FPS = (1 / (float)delta);
            if (coutFrames % 30 == 0)
            {
                this.OBJs[0] = this.OBJs[0].UpdateBox(Text: "Hello World: FPS: " + FPS + " /Count Frames: " + coutFrames, PositionL: [x, 0], TextureIndex: 1);
                int V = 0;
                foreach (var vertex in OBJs[0].GetGroupeVertex())
                {
                    Console.WriteLine("V" + V + ": " + vertex.pos.X);
                }
                Console.WriteLine("_____________________________");
                //Console.WriteLine(FPS + " /pos x = " + x);
                x++;
            }

            vertices.Clear();
            foreach (var obj in this.OBJs)
            {
                foreach (Vertex vertexArr in obj.GetGroupeVertex()) this.vertices.Add(vertexArr);
            }
        }*/
        
    }

}
