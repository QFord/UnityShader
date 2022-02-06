// Shader的名称
Shader "Learning/MySimpleShader"
{
    // 属性
    Properties 
    {
        _Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
    }

    SubShader
    {
        Pass
        {   
            // 设定名称、绘制状态和标签，可选项目
            // 在这个例子中，我们不需要进行更多设置

            // 开始编写Shader
            CGPROGRAM

            // 声明vertex / fragment shader的名称
            #pragma vertex vert
            #pragma fragment frag
            
            // 使用定义在Properties区块的属性
            // 注意：变量必须和区块中的属性以及变量名称一致
            fixed4 _Color;
            
            // 顶点 着色器
            float4 vert(float4 v : POSITION) : SV_POSITION {
                return UnityObjectToClipPos(v);
            }
            
            // 片段 着色器
            fixed4 frag() : SV_TARGET {
                return _Color;
            }
            ENDCG
            // 结束编写
        }
    }
    
    // 若以上两种Shader皆无法运行，则使用这个最低阶的Shader
    // 若“不留后路”，也可直接关闭该选项
    // `Fallback Off`
    Fallback "VertexLit"
}