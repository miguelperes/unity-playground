// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "ShaderDev/BareBone"
{
	Properties
	{
		_Color ("Main Color", Color) = (1, 1, 1, 1)
	}

	Subshader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			uniform half4 _Color;

			// Collection of a mesh attributes
			struct vertexInput {
				float4 vertex : POSITION; // List of keywords: https://msdn.microsoft.com/en-us/library/windows/desktop/bb509647(v=vs.85).aspx#VS
			};

			struct vertexOutput {
				// For the frag shader it's not a position anymore, it's an interpolation. Position of a particular fragment
				float4 pos : SV_POSITION; // More on SV_POSITION: https://msdn.microsoft.com/en-us/library/windows/desktop/bb509647(v=vs.85).aspx#System_Value
			};

			vertexOutput vert(vertexInput v) {
				vertexOutput o;

				// o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				o.pos = UnityObjectToClipPos(v.vertex);

				return o;
			}

			half4 frag(vertexOutput i) : COLOR {
				return _Color;
			}
			
			ENDCG
		}
	}
}