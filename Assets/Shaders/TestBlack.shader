Shader "Unlit/TestBlack"
{
    Properties
    {
        _ColorA ("Color A", Color) = (1, 1, 1, 1)
        _ColorB ("Color B", Color) = (1, 1, 1, 1)
        _Distance ("Distance Threshold", Float) = 1
        _Gloss ("Gloss", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _ColorA;
            float4 _ColorB;
            float1 _Distance;

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal: NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            //holds data for vertex shader use
            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
                float1 dis : TEXCOORD3;
                
            };


            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.dis = distance(_WorldSpaceCameraPos, o.worldPos);
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.uv = v.uv0;
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                //float4 outColor = lerp(_ColorA, _ColorB, trueDis);
                //return outColor;
                float4 outColor = saturate (lerp(_ColorA, _ColorB, distance(_WorldSpaceCameraPos, i.worldPos) / _Distance));//i.uv.x * trueDis);
                //outColor = lerp(_ColorA, _ColorB, distance(_WorldSpaceCameraPos.z, i.worldPos.z) / _Distance);

                return outColor;
                //return outColor;//float4 (i.worldPos.xyz, 1);
            }
            ENDCG
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            float _Gloss;

            struct MeshData
            {
                float4 vertex : POSITION;
                float3 normal: NORMAL;
                float2 uv0 : TEXCOORD0;
            };

            //holds data for vertex shader use
            struct Interpolators
            {
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD0;
                float2 uv : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };


            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.uv = v.uv0;
                 o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                float3 N = normalize(i.normal);
                float3 L = _WorldSpaceLightPos0.xyz;
                float3 lambert = saturate(dot(N, L));
                float3 diffuse = lambert * _LightColor0.xyz;

                float3 V = normalize(_WorldSpaceCameraPos - i.worldPos);
               // float3 R = reflect(-L, N);
                float3 H = normalize(L + V);
                //float3 S = saturate(dot(V, R));
                float3 S = saturate(dot(H, N)) * (lambert > 0);

                float specularExponent = exp2(_Gloss * 6) + 1;

                S = pow(S, specularExponent);
                S *= _LightColor0.xyz;

                return float4(diffuse + S, 1);
                //return outColor;//float4 (i.worldPos.xyz, 1);
            }
            ENDCG
        }
    }
}
