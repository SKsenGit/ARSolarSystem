using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ObjectInfo : MonoBehaviour
{
    string[] infoArray;
    // Start is called before the first frame update
    void Start()
    {
        infoArray = new string[] {
            "name: SUN\ndiameter (km): 1392684\n",
            "name: MERCURY\ndiameter (km): 4879\norbital period (years): 0,24 ",
            "name: VENUS\ndiameter (km): 12104\norbital period (years): 0,61",
            "name: EARTH\ndiameter (km): 12756\norbital period (years): 1,00 ",
            "name: MARS\ndiameter (km): 6792\norbital period (years): 1,88 ",
            "name: JUPITER\ndiameter (km): 142984\norbital period (years): 11,86",
            "name: SATURN\ndiameter (km)e: 120536\norbital period (years): 29,45 ",
            "name: URANUS\ndiameter (km): 51118\norbital period (years): 84,02 ",
            "name: NEPTUNE\ndiameter (km): 49528\norbital period (years): 164,77" };

    }

    // Update is called once per frame
    void Update()
    {
        if (name == "InfoSunBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(0);
        }
        else if (name == "InfoMercuryBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(1);
        }
        else if (name == "InfoVenusBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(2);
        }
        else if (name == "InfoEarthBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(3);
        }
        else if (name == "InfoMarsBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(4);
        }
        else if (name == "InfoJupiterBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(5);
        }
        else if (name == "InfoSaturnBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(6);
        }
        else if (name == "InfoUranusBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(7);
        }
        else if (name == "InfoNeptuneBox")
        {
            GetComponent<TextMeshPro>().text = getObjectInfo(8);
        }
    }
    string getObjectInfo(int i)
    {
        return infoArray[i];
    }
}
