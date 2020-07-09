#ifndef CUSTOM_BRDF_INCLUDE
#define CUSTOM_BRDF_INCLUDE

#define MIN_REFLECTIVITY 0.04

struct BRDF
{
    float3 diffuse;
    float3 specular;
    float roughness;//粗糙度
};

//计算漫反射率
float OneMinusReflectivity(float metallic)
{
    return (1 - MIN_REFLECTIVITY) * (1 - metallic);
} 

BRDF GetBRDF(Surface surface,bool applyAlphaToDiffuse)
{
    BRDF brdf;
    brdf.diffuse = surface.color * OneMinusReflectivity(surface.metallic);
    if(applyAlphaToDiffuse)
    {
        brdf.diffuse *= surface.alpha;
    }
    brdf.specular = lerp(MIN_REFLECTIVITY,surface.color,surface.metallic);
    float perceptualRoughness = //在CommonMaterial.hlsl
		PerceptualSmoothnessToPerceptualRoughness(surface.smoothness);//1 - smoothness = n
	brdf.roughness = PerceptualRoughnessToRoughness(perceptualRoughness); // n = n * n,将结果平方，为了效果更显著
    return brdf;
}

float SpecularStrength(Light light,Surface surface,BRDF brdf)
{
    float r2 = Square(brdf.roughness);
    float3 h = SafeNormalize(light.direction + surface.viewDirection);
    float nh2 = Square(dot(surface.normal,h));
    float lh2 = Square(dot(light.direction,h));
    float d2 = Square(nh2 * (r2 - 1) + 1.0001);
    float n =  4 * brdf.roughness + 2;
    float m_lh2 = max(0.1,lh2);
    return r2 /(d2 * m_lh2 * n);  
}

float3 GetDireBDRF(Light light,Surface surface,BRDF brdf)
{
    return SpecularStrength(light,surface,brdf) * brdf.specular + brdf.diffuse;
}

#endif