// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:4795,x:32716,y:32678,varname:node_4795,prsc:2|normal-1147-OUT,alpha-4184-OUT,refract-6516-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31658,y:33277,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31658,y:33433,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Lerp,id:1147,x:31665,y:32651,varname:node_1147,prsc:2|A-5717-OUT,B-8408-RGB,T-6931-OUT;n:type:ShaderForge.SFN_Vector3,id:5717,x:31230,y:32544,varname:node_5717,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Tex2d,id:8408,x:31230,y:32670,ptovrint:False,ptlb:Refraction Map,ptin:_RefractionMap,varname:_Refraction_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9e55bc73467770b448d4bf3ddb8790d2,ntxv:2,isnm:False|UVIN-5569-UVOUT;n:type:ShaderForge.SFN_Slider,id:6931,x:31073,y:32853,ptovrint:False,ptlb:Normal Intensity,ptin:_NormalIntensity,varname:_RefractionIntensity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:1.265337,max:5;n:type:ShaderForge.SFN_Rotator,id:5569,x:30989,y:32670,varname:node_5569,prsc:2|UVIN-5861-UVOUT,SPD-3665-OUT;n:type:ShaderForge.SFN_TexCoord,id:5861,x:30791,y:32579,varname:node_5861,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:1836,x:31459,y:32920,varname:node_1836,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8408-RGB;n:type:ShaderForge.SFN_Multiply,id:3364,x:31459,y:33079,varname:node_3364,prsc:2|A-6931-OUT,B-6276-OUT;n:type:ShaderForge.SFN_Multiply,id:3823,x:31658,y:32930,varname:node_3823,prsc:2|A-1836-OUT,B-3364-OUT;n:type:ShaderForge.SFN_Tex2d,id:3151,x:31658,y:33095,ptovrint:False,ptlb:Opacity Map,ptin:_OpacityMap,varname:_Opacity_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c73e79db84aee4842ac1ceccd251ca8c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:7414,x:31855,y:33142,varname:node_7414,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3151-R;n:type:ShaderForge.SFN_Multiply,id:341,x:32058,y:33065,varname:node_341,prsc:2|A-3823-OUT,B-7414-OUT;n:type:ShaderForge.SFN_Multiply,id:4184,x:32058,y:32856,varname:node_4184,prsc:2|A-1935-OUT,B-3151-R;n:type:ShaderForge.SFN_Slider,id:3665,x:30634,y:32805,ptovrint:False,ptlb:Rotation Speed,ptin:_RotationSpeed,varname:_RotationSpeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:-2,max:5;n:type:ShaderForge.SFN_Slider,id:6276,x:31073,y:33101,ptovrint:False,ptlb:Refraction Value,ptin:_RefractionValue,varname:_RefractionValue_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.5,cur:0.2597275,max:0.5;n:type:ShaderForge.SFN_Multiply,id:6516,x:32428,y:33039,varname:node_6516,prsc:2|A-341-OUT,B-3560-OUT;n:type:ShaderForge.SFN_Vector1,id:1935,x:31870,y:32795,varname:node_1935,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:3560,x:32058,y:33268,varname:node_3560,prsc:2|A-2053-A,B-797-A;proporder:797-8408-6931-3151-3665-6276;pass:END;sub:END;*/

Shader "Particles/Distortion" {
    Properties {
        _TintColor ("Color", Color) = (1,1,1,1)
        _RefractionMap ("Refraction Map", 2D) = "black" {}
        _NormalIntensity ("Normal Intensity", Range(-5, 5)) = 1.265337
        _OpacityMap ("Opacity Map", 2D) = "white" {}
        _RotationSpeed ("Rotation Speed", Range(-5, 5)) = -2
        _RefractionValue ("Refraction Value", Range(-0.5, 0.5)) = 0.2597275
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _TintColor;
            uniform sampler2D _RefractionMap; uniform float4 _RefractionMap_ST;
            uniform float _NormalIntensity;
            uniform sampler2D _OpacityMap; uniform float4 _OpacityMap_ST;
            uniform float _RotationSpeed;
            uniform float _RefractionValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float4 node_6958 = _Time + _TimeEditor;
                float node_5569_ang = node_6958.g;
                float node_5569_spd = _RotationSpeed;
                float node_5569_cos = cos(node_5569_spd*node_5569_ang);
                float node_5569_sin = sin(node_5569_spd*node_5569_ang);
                float2 node_5569_piv = float2(0.5,0.5);
                float2 node_5569 = (mul(i.uv0-node_5569_piv,float2x2( node_5569_cos, -node_5569_sin, node_5569_sin, node_5569_cos))+node_5569_piv);
                float4 _RefractionMap_var = tex2D(_RefractionMap,TRANSFORM_TEX(node_5569, _RefractionMap));
                float3 normalLocal = lerp(float3(0,0,1),_RefractionMap_var.rgb,_NormalIntensity);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _OpacityMap_var = tex2D(_OpacityMap,TRANSFORM_TEX(i.uv0, _OpacityMap));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (((_RefractionMap_var.rgb.rg*(_NormalIntensity*_RefractionValue))*_OpacityMap_var.r.r)*(i.vertexColor.a*_TintColor.a));
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
////// Lighting:
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,(0.0*_OpacityMap_var.r)),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
}
