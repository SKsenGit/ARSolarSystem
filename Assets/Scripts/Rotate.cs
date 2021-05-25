using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool rotate;
    MeshRenderer rend;
    Color original;

    // Start is called before the first frame update
    void Start()
    {
        rotate = true;
      
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            if (name == "InfoSaturn")
            {
                transform.Rotate(0, -90f * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(transform.up * Time.deltaTime * 45f, Space.Self);
            }
            
        }
         
    }
    public void InterruptRotation()
    {
      
        rotate = !rotate;
    }
}
