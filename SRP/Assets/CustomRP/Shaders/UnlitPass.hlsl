#ifndef CUSTOM_UNLIT_PASS
#define CUSTOM_UNLIT_PASS

#include "../ShaderLibrary/Common.hlsl"

#ifdef INSTANCING_ON
    UNITY_INSTANCING_BUFFER_START(UnityPerMaterial) //声明名为UnityPerMaterial的结构
        UNITY_DEFINE_INSTANCED_PROP(float4,_BaseColor) //结构中声明变量type var 
        UNITY_DEFINE_INSTANCED_PROP(float4,_BaseMap_ST)
        UNITY_DEFINE_INSTANCED_PROP(float,_CutOff)
    UNITY_INSTANCING_BUFFER_END(UnityPerMaterial    ) //结构结束，并且声明一个名为UnityPerMaterial的结构数组
#else
    CBUFFER_START(UnityPerMaterial)
        float4 _BaseColor;
        float4 _BaseMap_ST;
        float _CutOff;
    CBUFFER_END
#endif

TEXTURE2D(_BaseMap);
SAMPLER(sampler_BaseMap);

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

Varying UnlitVertex(Attributes input) 
{
    Varying output;
    UNITY_SETUP_INSTANCE_ID(input); //将instanceID保存在一个名为unity_InstanceID的全局变量中，供其他有关instance有关的宏使用
    UNITY_TRANSFER_INSTANCE_ID(input,output); // output.instanceID = UNITY_GET_INSTANCE_ID(input)，将instanceID从Vertex传入Fragment着色器
                                              //以供片元着色器使用
    float3 worldPos = TransformObjectToWorld(input.positionOS);
    output.positionCS = TransformWorldToHClip(worldPos);
    #ifdef INSTANCING_ON 
        float4 st = UNITY_ACCESS_INSTANCED_PROP(UnityPerMaterial,_BaseMap_ST);
        output.uv = input.uv * st.xy + st.zw;
    #else
        output.uv = TRANSFORM_TEX(input.uv,_BaseMap);
    #endif
    return output;
}

float4 UnlitFragment(Varying input) : SV_Target
{
    UNITY_SETUP_INSTANCE_ID(input)
    float4 texColor = SAMPLE_TEXTURE2D(_BaseMap,sampler_BaseMap,input.uv);
    float4 reslutColor;
    float cutOff;
    #ifdef INSTANCING_ON
        reslutColor = UNITY_ACCESS_INSTANCED_PROP(UnityPerMaterial,_BaseColor) * texColor;//通过保存的InstanceID从结构数组中获取对应的项中的_BaseColor变量
        cutOff = UNITY_ACCESS_INSTANCED_PROP(UnityPerMaterial,_CutOff);
    #else
        reslutColor =  _BaseColor * texColor;
        cutOff = _CutOff;
    #endif
    #ifdef _CLIPPING
        clip(reslutColor.a - cutOff);
    #endif
    return reslutColor;
}
#endif