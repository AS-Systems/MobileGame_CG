Shader "Custom/OutlineGlowTextureURP"
{
    Properties
    {
        _MainTex("Base Texture", 2D) = "white" {}
        _OutlineColor("Outline Color", Color) = (0, 1, 1, 1)
        _OutlinePower("Outline Power", Range(1,10)) = 3
        _OutlineIntensity("Outline Intensity", Range(0,5)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalRenderPipeline" }

        Pass
        {
            Name "OutlineGlowPass"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float3 normalWS : TEXCOORD0;
                float3 viewDirWS : TEXCOORD1;
                float2 uv : TEXCOORD2;
            };

            // User properties
            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _OutlineColor;
            float _OutlinePower;
            float _OutlineIntensity;

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS);
                OUT.normalWS = normalize(TransformObjectToWorldNormal(IN.normalOS));
                OUT.viewDirWS = normalize(GetCameraPositionWS() - TransformObjectToWorld(IN.positionOS).xyz);
                OUT.uv = IN.uv;
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                // Sample the original texture
                half4 baseColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);

                // Fresnel glow
                float fresnel = 1.0 - saturate(dot(IN.normalWS, IN.viewDirWS));
                fresnel = pow(fresnel, _OutlinePower);

                half4 outlineGlow = _OutlineColor * fresnel * _OutlineIntensity;

                // Combine base texture + glow
                return baseColor + outlineGlow;
            }
            ENDHLSL
        }
    }
}
