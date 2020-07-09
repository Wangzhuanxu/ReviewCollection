#ifndef CUSTOM_Lit_PASS
#define CUSTOM_Lit_PASS

#include "../ShaderLibrary/Common.hlsl"
#include "../ShaderLibrary/Surface.hlsl"
#include "../ShaderLibrary/Light.hlsl"
#include "../ShaderLibrary/BRDF.hlsl"
#include "../ShaderLibrary/Lighting.hlsl"

CBUFFER_START(UnityPerMaterial)
   float4 _BaseColor;
   float4 _BaseMap_ST;
   float _CutOff;
   float _Metallic;
   float _Smoothness;
CBUFFER_END

TEXTURE2D(_BaseMap);
SAMPLER(sampler_BaseMap);

struct Attributes
{
    float3 positionOS : POSITION;
    float2 uv : TEXCOORD0;
    float3 normalOS : NORMAL;
    UNITY_VERTEX_INPUT_INSTANCE_ID  //相当于uint instanceID : SV_InstanceID;
};

struct Varying
{
    float4 positionCS : SV_POSITION;
    float2 uv:TEXCOORD0;
    float3 normalWS : TEXCOORD1;
    float3 positionWS: TEXCOORD2;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

Varying LitVertex(Attributes input) 
{
    Varying output;
    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_TRANSFER_INSTANCE_ID(input,output);
                                              
    float3 worldPos = TransformObjectToWorld(input.positionOS);
    output.positionCS = TransformWorldToHClip(worldPos);
    output.uv = TRANSFORM_TEX(input.uv,_BaseMap);
    output.normalWS = TransformObjectToWorldNormal(input.normalOS);
    output.positionWS = TransformObjectToWorld(input.positionOS);
    return output;
}

float4 LitFragment(Varying input) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(input);
    float4 texColor = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
    #ifdef _CLIPPING
        clip(texColor.a - _CutOff);
    #endif
    Surface surface;
    surface.normal = normalize(input.normalWS);
    surface.color = _BaseColor.rgb * texColor.rgb;
    surface.alpha = texColor.a;
    surface.metallic = _Metallic;
    surface.smoothness = _Smoothness;
    surface.viewDirection = normalize(_WorldSpaceCameraPos - input.positionWS);
    #ifdef _PREMULTIPLY_ALPHA
        BRDF brdf = GetBRDF(surface,true);
    #else
        BRDF brdf = GetBRDF(surface,false);
    #endif
    
    float3 color = GetLighting(surface,brdf);
    return float4(color,surface.alpha);
}
#endif