#ifndef CUSTOM_SHDOW_CASTER_PASS
#define CUSTOM_SHDOW_CASTER_PASS

#include "../ShaderLibrary/Common.hlsl"

CBUFFER_START(UnityPerMaterial)
   float4 _BaseColor;
   float4 _BaseMap_ST;
   float _CutOff;
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

Varying ShadowCasterVertex(Attributes input) 
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

void ShadowCasterFragment(Varying input)
{
    UNITY_SETUP_INSTANCE_ID(input);
    float4 texColor = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
    #ifdef _CLIPPING
        clip(texColor.a - _CutOff);
    #endif
}
#endif