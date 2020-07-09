#ifndef CUSTOM_UNITY_INPUT
#define CUSTOM_UNITY_INPUT
//与 urp的unity input 保持一致

CBUFFER_START(UnityPerDraw)

float4x4 unity_ObjectToWorld;
float4x4 unity_WorldToObject;
float4 unity_LODFade;
real4 unity_WorldTransformParams;

CBUFFER_END

CBUFFER_START(UnityPerFrame)

float4x4 unity_MatrixVP;
float4x4 unity_MatrixV;
float4x4 glstate_matrix_projection;

CBUFFER_END

float3 _WorldSpaceCameraPos;

CBUFFER_START(UnityPerCamera)

CBUFFER_END

#endif