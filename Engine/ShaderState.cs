using Silk.NET.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App75241305.Engine
{
    internal class ShaderState
    {
        public struct UniformBufferObjectSahder
        {
            //Basic Options
            public Vector4D<float> OBJcolor;

            public int shaderType;
            public bool texturing;
        }
    }
}
