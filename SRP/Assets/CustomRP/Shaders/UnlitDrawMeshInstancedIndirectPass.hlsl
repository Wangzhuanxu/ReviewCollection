#ifndef CUSTOM_DRAW_MESH_INSTANCED_INDIRECT_UNLIT_PASS
#define CUSTOM_DRAW_MESH_INSTANCED_INDIRECT_UNLIT_PASS

#include "../ShaderLibrary/Common.hlsl"

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
    UNITY_VERTEX_INPUT_INSTANCE_ID  //相当于uint instanceID : SV_InstanceID;
};

struct Varying
{
    float4 positionCS : SV_POSITION;
    float2 uv:TEXCOORD0;
    UNITY_VERTEX_INPUT_INSTANCE_ID
};

Varying UnlitVertex(Attributes input,uint instanceID : SV_InstanceID) 
{
    Varying output;
    UNITY_SETUP_INSTANCE_ID(input);
    UNITY_TRANSFER_INSTANCE_ID(input,output);
                                              
    float3 worldPos = input.positionOS + positionList[instanceID];
    output.positionCS = TransformWorldToHClip(worldPos);
    output.uv = TRANSFORM_TEX(input.uv,_BaseMap);
    return output;
}

float4 UnlitFragment(Varying input) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(input)
    float4 texColor = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
    float4 reslutColor;
    float cutOff;
    reslutColor =  _BaseColor * texColor;
    cutOff = _CutOff;
    
    #ifdef _CLIPPING
        clip(reslutColor.a - cutOff);
    #endif
    return reslutColor;
}
#endif