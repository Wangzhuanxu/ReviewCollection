#ifndef CUSTOM_LIGHTING_INCLUDE
#define CUSTOM_LIGHTING_INCLUDE

float3 GetIncomingLight(Surface surface,Light light)
{
    return max(0,dot(surface.normal,light.direction)) * light.color;
}


float3 GetLighting(Surface surface,Light light,BRDF brdf)
{
    return GetIncomingLight(surface,light) * GetDireBDRF(light,surface,brdf);
}

float3 GetLighting(Surface surface,BRDF brdf) 
{
    float3 color = float3(0,0,0);
    for(int i = 0;i < GetDirectionLightCount();i++)
    {
        color += GetLighting(surface,GetDirectionLight(i),brdf);
    }
    return color;
}



#endif