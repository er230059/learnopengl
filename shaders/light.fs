#version 330 core
out vec4 FragColor;

uniform vec3 lightColor;

void main()
{
    FragColor = vec4(lightColor.x, lightColor.y, lightColor.z, 1.0);
}