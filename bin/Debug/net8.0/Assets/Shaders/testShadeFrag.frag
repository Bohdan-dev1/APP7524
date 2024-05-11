#version 450
layout(binding = 1) uniform sampler2D texSampler;

layout(location = 0) in vec4 fragColor;
layout(location = 1) in vec2 fragTexCoord;
layout(location = 2) in float texturingFlag;

layout(location = 0) out vec4 outColor;

void main() {
    
    //outColor = texture(texSampler, fragTexCoord);
    if (texturingFlag == 0) outColor = vec4(fragColor.x, fragColor.y, fragColor.z, fragColor.w);
    else outColor = texture(texSampler, fragTexCoord);
}
