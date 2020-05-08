Shader "Custom/Wall" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_EmissionColor("EmissionColor",Color) = (1,0,0,1)
		_Emission("Emission",Range(0,1)) = 0.0
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_GlossMap("GlossMap",2D) = "white"{}
		_Glossiness("Smoothness", Float) = 0.5
		_Metallic("Metallic", Float) = 0.0
		_AO("AO",2D) = "white"{}
		_NormalMap("NormalMap",2D) = "bump"{}
		_NormalMapIntensity("NormalMapIntensity",Range(1,5)) = 1.0
	}
		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200
	Stencil
	{
		Ref 1 // ReferenceValue = 1
		Comp NotEqual // Only render pixels whose reference value differs from the value in the buffer.
	}
			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows

			#pragma target 3.0

			sampler2D _MainTex;

			struct Input {
				float2 uv_MainTex;
				float2 uv_Gloss;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			float4 _EmissionColor;
			float _NormalMapIntensity;
			float _Emission;
			sampler2D _GlossMap,_AO,_NormalMap;

			UNITY_INSTANCING_BUFFER_START(Props)
			UNITY_INSTANCING_BUFFER_END(Props)

			void surf(Input IN, inout SurfaceOutputStandard o) {
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness * tex2D(_GlossMap,IN.uv_MainTex);
				o.Alpha = c.a;
				o.Occlusion = tex2D(_AO,IN.uv_MainTex);
				o.Emission = _Emission * _EmissionColor;
				fixed3 n = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex)).rgb;
				n.x *= _NormalMapIntensity;
				n.y *= _NormalMapIntensity;
				o.Normal = normalize(n);
			}
			ENDCG
		}
			FallBack "Diffuse"
}

