using App75241305.Engine;
using Silk.NET.Maths;
using Silk.NET.Vulkan;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace App75241305.Engine

{
    struct Vertex
    {
        public Vector3D<float> pos;
        public Vector4D<float> color;
        public Vector2D<float> textCoord;

        public static VertexInputBindingDescription GetBindingDescription()
        {
            VertexInputBindingDescription bindingDescription = new()
            {
                Binding = 0,
                Stride = (uint)Unsafe.SizeOf<Vertex>(),
                InputRate = VertexInputRate.Vertex,
            };

            return bindingDescription;
        }

        public static VertexInputAttributeDescription[] GetAttributeDescriptions()
        {
            var attributeDescriptions = new[]
            {
            new VertexInputAttributeDescription()
            {
                Binding = 0,
                Location = 0,
                Format = Format.R32G32B32Sfloat,
                Offset = (uint)Marshal.OffsetOf<Vertex>(nameof(pos)),
            },
            new VertexInputAttributeDescription()
            {
                Binding = 0,
                Location = 1,
                Format = Format.R32G32B32Sfloat,
                Offset = (uint)Marshal.OffsetOf<Vertex>(nameof(color)),
            },
            new VertexInputAttributeDescription()
            {
                Binding = 0,
                Location = 2,
                Format = Format.R32G32Sfloat,
                Offset = (uint)Marshal.OffsetOf<Vertex>(nameof(textCoord)),
            }
        };

            return attributeDescriptions;
        }
    }
    struct UniformBufferObject
    {
        //Basic Options
        public Vector4D<float> OBJcolor;
        public string texturePath;
    }
    internal unsafe class Engine
    {


        private UniformBufferObject UBO;
        private List<Vertex[]> vertices;
        private List<int[]> indexListVertex;
        public void Main()
        {

            VkAPI vkAPI = new VkAPI();
            if (!vkAPI.GetStatusInit()) {
                Console.WriteLine("Error Init API Vulkan");
                return;
            }

            UBO = new UniformBufferObject();
            initBaseUBO();
        }

        protected void AddOBJ(Vertex[] vertex, int indexDraw)
        {

        }
        private void initBaseUBO()
        {
            this.UBO.OBJcolor = new Vector4D<float>(0.0f, 0.0f, 0.0f, 0.0f );
            this.UBO.texturePath = "";
        }
    }
}
