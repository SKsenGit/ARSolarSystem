using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawOrbit : MonoBehaviour
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 100;
    
    public float radiusMercury;
    public float radiusVenus;
    public float radiusEarth;
    public float radiusMars;
    public float radiusJupiter;
    public float radiusSaturn;
    public float radiusUranus;
    public float radiusNeptune;

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        float radiusSun = GetComponent<SphereCollider>().radius;
        
        radiusMercury = radiusSun*1.2f;
        radiusVenus = radiusSun * 2f;
        radiusEarth = radiusSun * 3f;
        radiusMars = radiusSun * 4f;
        radiusJupiter = radiusSun * 5f;
        radiusSaturn = radiusSun * 6f;
        radiusUranus = radiusSun * 7f;
        radiusNeptune = radiusSun * 8f;



        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINES);
        //Mercury
        float a = 0;
        float angle = 0;
        
        GL.Vertex3(radiusMercury, 0, 0);

        for (int i = 1; i < lineCount; ++i)
        {
            a = i / (float)lineCount;
            angle = a * Mathf.PI * 2;
            GL.Color(new Color(0.7F, 0.8F, 0.9F, 0.5F)); 
            GL.Vertex3(Mathf.Cos(angle) * radiusMercury, 0, Mathf.Sin(angle) * radiusMercury);
            GL.Vertex3(Mathf.Cos(angle) * radiusMercury, 0, Mathf.Sin(angle) * radiusMercury);

        }
        GL.Vertex3(radiusMercury, 0, 0);

        for (float j = 2f; j<9f;++j)
        { 
            a = 0;
            angle = 0;
            float orbitRadius = radiusSun * j;
            GL.Vertex3(orbitRadius, 0, 0);

            for (int i = 1; i < lineCount; ++i)
            {
                a = i / (float)lineCount;
                angle = a * Mathf.PI * 2;
                GL.Color(new Color(0.7F, 0.8F, 0.9F, 0.5F));
                GL.Vertex3(Mathf.Cos(angle) * orbitRadius, 0, Mathf.Sin(angle) * orbitRadius);
                GL.Vertex3(Mathf.Cos(angle) * orbitRadius, 0, Mathf.Sin(angle) * orbitRadius);

            }
            GL.Vertex3(orbitRadius, 0, 0);
        }


        GL.End();
        GL.PopMatrix();
    }
}
