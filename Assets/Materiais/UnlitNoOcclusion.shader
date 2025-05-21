// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/UnlitNoOcclusion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #include "Lighting.cginc"
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 normalDir : TEXCOORD1;
                float3 worldPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.normalDir = normalize(mul((float3x3)unity_WorldToObject, v.normal)); // normals em espaço objeto
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // iluminação padrão da forward base pass
                fixed3 normal = normalize(i.normalDir);
                fixed3 lightDir = normalize(_WorldSpaceLightPos0.xyz);

                // Lambert (difusa)
                float NdotL = max(0, dot(normal, lightDir));

                fixed4 texcol = tex2D(_MainTex, i.uv) * _Color;
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * texcol.rgb;

                fixed3 finalColor = ambient + _LightColor0.rgb * NdotL * texcol.rgb;

                return fixed4(finalColor, texcol.a);
            }
            ENDCG
        }
    }
}