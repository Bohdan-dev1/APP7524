using Silk.NET.Maths;
using App75241305.Engine;

namespace App75241305.Accets.UI
{
    internal class BoxDraw : Engine.Engine
    {
        Engine.Engine engine;
        private List<Vertex[]> vertices = new List<Vertex[]>();

        public BoxDraw() { }
        public BoxDraw(
            Engine.Engine engine, 
            string type, 
            string Text = "",
            int[] SizeBoxL = null,
            int[] PositionL = null,
            Vector4D<ushort> Color = new(),
            bool DefaultColorText = true,
            Vector4D<ushort> TextBackround = new(),
            Vector4D<float> BackgroundColor = new(),
            int TextureIndex = -1,
            float ZIndex = 1.0f)   
        {
            this.engine = engine;
            Text ??= "";
            SizeBoxL ??= [120, 120];
            PositionL ??= [0,0];
            if (DefaultColorText == true)
                Color = new Vector4D<ushort>(255, 255, 255, 255);

            Vector3D<float>[] vertex = new Vector3D<float>[4];
            switch (type) {
                case "TextLable":
                    TextLable lable = new TextLable(this.engine, Color, TextBackround, Text);
                    vertex = this.GenPostionVertex([lable.textureWidth, lable.textureHeight], PositionL, ZIndex: ZIndex);
                    break;
            }

            this.vertices.Add(new Vertex[] {
                new Vertex { pos = vertex[0],color = BackgroundColor, TextureIndex = TextureIndex, textCoord = new Vector2D<float>(0.0f, 1.0f)  },
                new Vertex { pos = vertex[1], color = BackgroundColor, TextureIndex = TextureIndex, textCoord = new Vector2D<float>(1.0f, 1.0f) },
                new Vertex { pos = vertex[2], color = BackgroundColor, TextureIndex = TextureIndex, textCoord = new Vector2D<float>(1.0f, 0.0f) },
                new Vertex { pos = vertex[3], color = BackgroundColor, TextureIndex = TextureIndex, textCoord = new Vector2D<float>(0.0f, 0.0f) }});
        }

        //TypePosition = 0 - coordinate (0,0) left height 
        //Origin - center move obj/ def = 0 (center)
        private Vector3D<float>[] GenPostionVertex(int[] SizeBox = null, int[] position = null, float ZIndex = 1.0f, ushort TypePosition = 0, ushort Origin = 0)
        {
            Vector3D<float>[] vertex = new Vector3D<float>[4];
            int heightHalf = SizeBox[1] / 2;
            int widthHalf = SizeBox[0] / 2;

            switch (TypePosition)
            {
                default:
                    vertex[0] = new Vector3D<float>(-widthHalf, -heightHalf, -ZIndex);
                    vertex[1] = new Vector3D<float>(widthHalf, -heightHalf, -ZIndex);
                    vertex[2] = new Vector3D<float>(widthHalf, heightHalf , -ZIndex);
                    vertex[3] = new Vector3D<float>(-widthHalf, heightHalf , -ZIndex);
                    break;
            }

            return vertex;
        }

        public Vertex[] GetGroupeVertex () {
            return this.vertices.SelectMany(a => a).ToArray(); 
        }

        public void UpdateBox(int[] FrameSize)
        {

        }

        
    }
}
