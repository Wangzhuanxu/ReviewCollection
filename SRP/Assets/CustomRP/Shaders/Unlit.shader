Shader "CustomRP/Unlit"
{
    Properties
    {
       
    }
    SubShader
    {
        Tags{"Queue" = "Geometry" }
        Pass
        {
           Tags{}
           
           HLSLPROGRAM
           
           #include "UnlitPass.hlsl"
           #pragma vertex UnlitVertex
           #pragma fragment UnlitFragment
           ENDHLSL
        }
    }
}
