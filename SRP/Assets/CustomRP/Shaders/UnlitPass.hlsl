#ifndef CUSTOM_UNLIT_PASS
#define CUSTOM_UNLIT_PASS

float4 UnlitVertex(float3 positionOS : POSITION) : SV_POSITION
{
    return float4(positionOS,1);
}

float4 UnlitFragment() : SV_Target
{
    return float4(1,1,1,1);
}
#endif