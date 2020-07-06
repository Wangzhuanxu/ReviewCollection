#ifndef CUSTOM_LIGHT_INCLUDE
#define CUSTOM_LIGHT_INCLUDE

#define MAX_DIRECTION_LIGHT_COUNT 4

CBUFFER_START(CustomLight)
    int DirectionLightCount;
    float4 DirectionLightDirection[MAX_DIRECTION_LIGHT_COUNT];
    float4 DirectionLightColor[MAX_DIRECTION_LIGHT_COUNT];
CBUFFER_END

struct Light
{
    float3 color;//光源颜色
    float3 direction;//光线方向，顶点指向，光源位置
};

int GetDirectionLightCount()
{
    return DirectionLightCount;
}   

Light GetDirectionLight(int index)
{
    Light light;
    light.color = DirectionLightColor[index].rgb;
    light.direction = DirectionLightDirection[index].xyz;
    return light;
}

#endif