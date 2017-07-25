using UnityEngine;
using System.Collections;

public class RenderGlassTexture : MonoBehaviour
{

    /// <summary>  
    /// 辅助摄像机   
    /// 原理:就是将辅助摄像机所看到的内容渲染到玻璃物体上,所以就实现了实时反射的镜面效果  
    /// 因为玻璃也是场景中的物体,所以辅助摄像机也会看见他  
    /// 所以最好能将玻璃物体单独放在一个层级中,让辅助摄像机不去渲染他  
    /// </summary>  
    public Camera cam;
    private RenderTexture renderTex;
    /// <summary>  
    /// 玻璃shader  
    /// </summary>  
    public Shader glassShader;
    /// <summary>  
    /// 玻璃材质  
    /// </summary>  
    private Material m_GlassMaterial;
    protected Material GlassMaterial
    {
        get
        {
            if (m_GlassMaterial == null)
            {
                m_GlassMaterial = new Material(glassShader);
            }
            return m_GlassMaterial;
        }
    }

    // Use this for initialization  
    void Start()
    {
        renderTex = new RenderTexture(Screen.width, Screen.height, 16);
        cam.targetTexture = renderTex;
    }

    //在摄像机开始裁剪场景之前调用  
    void OnPreCull()
    {
        GlassMaterial.SetTexture("_MainTex", renderTex);
    }

    //在相机完成场景渲染后调用  
    void OnPostRender()
    {
        GlassMaterial.SetTexture("_MainTex", null);
    }
}