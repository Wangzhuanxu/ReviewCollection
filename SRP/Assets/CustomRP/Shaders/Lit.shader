Shader "CustomRP/Lit"
{
    Properties
    {
       _BaseMap("BaseMap",2D) = "white" {}
       _BaseColor("BaseColor",Color) = (1,1,1,1)
       [Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Src Blend", Float) = 1
	   [Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Dst Blend", Float) = 0
	   //当toggle为true的时候自动产生一个_ZWRITE_ON的shader 变体;为false的时候将会去掉
	   [Toggle]_ZWrite("ZWrite",Float) = 0
	   //当toggle为true的时候自动产生一个名为_CLIPPING的shader 变体（括号中有值时，用括号的值）;为false的时候将会去掉
	   [Toggle(_CLIPPING)]_Clip("Clip",Float) = 1
	   _CutOff("CutOff",Range(0,1)) = 0.5
	   
    }
    SubShader
    {
        Tags{"Queue" = "Geometry" }
        Pass
        {
           Tags{"LightMode" = "CustomLit"}
           Blend [_SrcBlend][_DstBlend]
           ZWrite [_ZWrite]
           HLSLPROGRAM
           #pragma target 3.5
           //相当于声明了一个INSTANCING_ON的变体
           #pragma multi_compile_instancing
           #pragma shader_feature _CLIPPING
           #include "LitPass.hlsl"
           #pragma vertex LitVertex
           #pragma fragment LitFragment
           ENDHLSL
        }
    }
}
