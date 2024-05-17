#version 450
layout(binding = 1) uniform sampler2D texSampler[256];

layout(location = 0) in vec4 fragColor;
layout(location = 1) in vec2 fragTexCoord;
layout(location = 2) in flat int TextureIndex;

layout(location = 0) out vec4 outColor;

void main() {
    
    if (TextureIndex >= 0 && TextureIndex < 256){
        outColor = texture(texSampler[TextureIndex], fragTexCoord);
    }
    else {
        outColor = vec4(fragColor.x, fragColor.y, fragColor.z, fragColor.w);
    }
}
