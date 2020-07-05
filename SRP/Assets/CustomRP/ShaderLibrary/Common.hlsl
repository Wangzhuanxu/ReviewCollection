#ifndef COMMON_INCLUDE
#define COMMON_INCLUDE

//在这里仅仅是引入常用的Graphic Api ，例如real4等等
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Common.hlsl" 
#include "UnityInput.hlsl"

#define UNITY_MATRIX_M unity_ObjectToWorld
#define UNITY_MATRIX_I_M unity_WorldToObject
#define UNITY_MATRIX_V unity_MatrixV
#define UNITY_MATRIX_VP unity_MatrixVP
#define UNITY_MATRIX_P glstate_matrix_projection

//这俩的顺序不可以变化，因为是否使用GPUInstance，UNITY_MATRIX_M宏代表的不是一个东西。
//用，单纯代表一个otw矩阵，否则代表一个根据instance_id从结构数组中获取某一项中的otw矩阵。
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/UnityInstancing.hlsl"
#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/SpaceTransforms.hlsl"

/*float3 TransformObjectToWorld(float3 positionOS)
{
    return mul(unity_ObjectToWorld,float4(positionOS,1)).xyz;
}

float4 TransformWorldToHClip(float3 worldPos)
{
    return mul(unity_MatrixVP,float4(worldPos,1)); 
}*/

#endif