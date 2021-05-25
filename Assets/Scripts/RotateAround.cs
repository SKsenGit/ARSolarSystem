using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject target;


    public void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, 25f * Time.deltaTime);
    }

    // Update is called once per frame

}
