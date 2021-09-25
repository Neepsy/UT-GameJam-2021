Shader "Custom/TestBlackLit"
{
    Properties
    {
        _ColorTrue ("True Color", Color) = (1,1,1,1)
        _ColorA ("ColorA", Color) = (1,1,1,1)
        _ColorB ("ColorB", Color) = (1,1,1,1)
        _ColorStart ("Color Start", Range(0,1)) = 1
        _ColorEnd ("Color End", Range(0,1))  = 1
        
        _Distance ("Distance Threshold", Float) = 1
        _Threshold ("Threshold", Range(0.0, 1.0)) = 1
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        float4 _ColorTrue;
        float4 _ColorA;
        float4 _ColorB;
        float1 _ColorStart;
        float1 _ColorEnd;
        float4 _distanceColor;
        float1 _Distance;
        float1 _Threshold;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float InverseLerp(float a, float b, float v)
        {
            return (v-a)/(b-a);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);

            float4 fadeDistance = saturate(distance(_WorldSpaceCameraPos, IN.worldPos) / _Distance); 
            //float2 uvShadingTest = IN.uv_MainTex;

            float4 boundedGradient = InverseLerp(_ColorStart, _ColorEnd, fadeDistance);

            float4 outColor = saturate(lerp(_ColorA, _ColorB, boundedGradient));

            o.Albedo =  saturate (_ColorTrue * c.rgb * outColor.rgb);
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a * pow(outColor.rgb, _Threshold);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
