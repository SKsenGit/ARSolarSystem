using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemRotation : MonoBehaviour
{
    public GameObject Sun;
    public GameObject Mercury;
    public GameObject MercuryGroup;
    public GameObject Venus;
    public GameObject VenusGroup;
    public GameObject Earth;
    public GameObject Moon;
    public GameObject EarthGroup;
    public GameObject Mars;
    public GameObject MarsGroup;
    public GameObject AsteroidGroups;
    public GameObject Jupiter;
    public GameObject JupiterGroup;
    public GameObject Saturn;
    public GameObject SaturnGroup;
    public GameObject Uranus;
    public GameObject UranusGroup;
    public GameObject Neptune;
    public GameObject NeptuneGroup;
    bool rotate;
    static Material lineMaterial;
    void Start()
    {
        rotate = true;
      //  Venus.SetActive(false);

        // Sun.transform.localScale = (new Vector3(0.5f, 0.5f, 0.5f));
        //  Mercury.transform.SetPositionAndRotation();



    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            Sun.transform.Rotate(Sun.transform.up * Time.deltaTime * 10f, Space.Self);

            MercuryGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 22f * Time.deltaTime);
            Mercury.transform.Rotate(Mercury.transform.up * Time.deltaTime * 10f, Space.Self);


            VenusGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 17f * Time.deltaTime);
            Venus.transform.Rotate(Venus.transform.up * Time.deltaTime * -10f, Space.Self);

            EarthGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 15f * Time.deltaTime);
            Earth.transform.Rotate(Earth.transform.up * Time.deltaTime * 45f, Space.Self);
            Moon.transform.RotateAround(EarthGroup.transform.position, Vector3.forward, 25f * Time.deltaTime);

            MarsGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 10f * Time.deltaTime);
            Mars.transform.Rotate(Mars.transform.up * Time.deltaTime * 45f, Space.Self);

            AsteroidGroups.transform.RotateAround(Sun.transform.position, Vector3.up,  Time.deltaTime);

            JupiterGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 6f * Time.deltaTime);
            Jupiter.transform.Rotate(Jupiter.transform.up * Time.deltaTime * 90f, Space.Self);


            SaturnGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 4f * Time.deltaTime);
            // Saturn.transform.Rotate(Saturn.transform.up * Time.deltaTime * 90f, Space.Self);
            Saturn.transform.Rotate(0,-90f * Time.deltaTime, 0);

            UranusGroup.transform.RotateAround(Sun.transform.position, Vector3.up, 2f * Time.deltaTime);
            //Uranus.transform.Rotate(Uranus.transform.up * Time.deltaTime * 90f, Space.Self);
            Uranus.transform.Rotate(0, 90f* Time.deltaTime, 0);

            NeptuneGroup.transform.RotateAround(Sun.transform.position, Vector3.up,  Time.deltaTime);
            Neptune.transform.Rotate(Neptune.transform.up * Time.deltaTime * 90f, Space.Self);



        }
       

    }
    public void InterruptRotation()
    {
       rotate = !rotate;
    }

    
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
        float radiusSun = Sun.GetComponent<SphereCollider>().radius;
        radiusSun = 0.1f;
        int lineCount = 100;
        float radiusMercury = radiusSun * 1.2f;
      /*  radiusVenus = radiusSun * 2f;
        radiusEarth = radiusSun * 3f;
        radiusMars = radiusSun * 4f;
        radiusJupiter = radiusSun * 5f;
        radiusSaturn = radiusSun * 6f;
        radiusUranus = radiusSun * 7f;
        radiusNeptune = radiusSun * 8f;*/



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

       /* GL.Vertex3(radiusMercury, 0, 0);

        for (int i = 1; i < lineCount; ++i)
        {
            a = i / (float)lineCount;
            angle = a * Mathf.PI * 2;
            GL.Color(new Color(0.7F, 0.8F, 0.9F, 0.5F));
            GL.Vertex3(Mathf.Cos(angle) * radiusMercury, 0, Mathf.Sin(angle) * radiusMercury);
            GL.Vertex3(Mathf.Cos(angle) * radiusMercury, 0, Mathf.Sin(angle) * radiusMercury);

        }
        GL.Vertex3(radiusMercury, 0, 0);*/

        for (float j = 0.121f; j < 0.62f; j=j+0.07f)
        {
            a = 0;
            angle = 0;
            float orbitRadius =  j;
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
