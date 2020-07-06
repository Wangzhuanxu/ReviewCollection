#ifndef CUSTOM_Lit_PASS
#define CUSTOM_Lit_PASS

#include "../ShaderLibrary/Common.hlsl"
#include "../ShaderLibrary/Surface.hlsl"
#include "../ShaderLibrary/Light.hlsl"
#include "../ShaderLibrary/Lighting.hlsl"

CBUFFER_START(UnityPerMaterial)
   float4 _BaseColor;
   float4 _BaseMap_ST;
   float _CutOff;
CBUFFER_END

TEXTURE2D(_BaseMap);
SAMPLER(sampler_BaseMap);
StructuredBuffer<float3> positionList;

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
    return output;
}

float4 LitFragment(Varying input) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(input);
    Surface surface;
    surface.normal = normalize(input.normalWS);
    surface.color = _BaseColor.rgb;
    surface.alpha = _BaseColor.a;
    float3 color = GetLighting(surface);
    return float4(color,surface.alpha);
}
#endif