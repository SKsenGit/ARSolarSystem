using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Add all info objects here")]
    public GameObject[] infoObjects;
    [Header("Add here AR camera")]
    public Camera ARCamera;
    [Header("Add here button Back")]
    public GameObject buttonBack;
    public GameObject solarSystem;
    [Header("Add here Planets info objects")]
    public GameObject infoSun;
    public GameObject infoMercury;
    public GameObject infoVenus;
    public GameObject infoEarth;
    public GameObject infoMars;
    public GameObject infoJupiter;
    public GameObject infoSaturn;
    public GameObject infoUranus;
    public GameObject infoNeptune;
    public GameObject sourceLight;

    private bool infoActive;
    private GameObject CurrentObject;
    


    public void Start()
    {
        infoActive = true;
        ChangeActiveInfo();
        buttonBack.SetActive(false);
        infoSun.SetActive(false);
        infoMercury.SetActive(false);
        infoVenus.SetActive(false);
        infoEarth.SetActive(false);
        infoMars.SetActive(false);
        infoJupiter.SetActive(false);
        infoSaturn.SetActive(false);
        infoUranus.SetActive(false);
        infoNeptune.SetActive(false);
        sourceLight.SetActive(false);
    }
    public void ChangeActiveInfo()
    {
        infoActive = !infoActive;
        
        for (int i = 0; i < infoObjects.Length; i++)
        {
            infoObjects[i].SetActive(infoActive);
        }
      //  TextField..GetComponent<Text>().text = "Hi"; 
    }

    public void AppExit()
    {
        Application.Quit();
    }

    public void Back()
    {
        buttonBack.SetActive(false);
        solarSystem.SetActive(true);
        CurrentObject.SetActive(false);
        CurrentObject = null;
        sourceLight.SetActive(false);

    }
    
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray,out hitObject))
                {


                    //Debug.Log(hitObject.transform.name);

                    if (hitObject.transform.name == "Sun")
                    {
                        infoSun.transform.position = solarSystem.transform.position;
                        CurrentObject = infoSun;
                        
                    }
                    else if (hitObject.transform.name == "Mercury")
                    {
                        infoMercury.transform.position = solarSystem.transform.position;
                        CurrentObject = infoMercury;

                    }
                    else if (hitObject.transform.name == "Venus")
                    {
                        infoVenus.transform.position = solarSystem.transform.position;
                        CurrentObject = infoVenus;

                    }
                    else if (hitObject.transform.name == "Earth")
                    {
                        infoEarth.transform.position = solarSystem.transform.position;
                        CurrentObject = infoEarth;

                    }
                    else if (hitObject.transform.name == "Mars")
                    {
                        infoMars.transform.position = solarSystem.transform.position;
                        CurrentObject = infoMars;

                    }
                    else if (hitObject.transform.name == "Jupiter")
                    {
                        infoJupiter.transform.position = solarSystem.transform.position;
                        CurrentObject = infoJupiter;

                    }
                    else if (hitObject.transform.name == "Saturn" || hitObject.transform.name == "SaturnRing")
                    {
                        infoSaturn.transform.position = solarSystem.transform.position;
                        CurrentObject = infoSaturn;

                    }
                    else if (hitObject.transform.name == "Uranus")
                    {
                        infoUranus.transform.position = solarSystem.transform.position;
                        CurrentObject = infoUranus;

                    }
                    else if (hitObject.transform.name == "Neptune")
                    {
                        infoNeptune.transform.position = solarSystem.transform.position;
                        CurrentObject = infoNeptune;

                    }
                    else if (hitObject.transform.name == "InfoSun" || hitObject.transform.name == "InfoMercury" ||
                            hitObject.transform.name == "InfoVenus" || hitObject.transform.name == "InfoEarth" ||
                            hitObject.transform.name == "InfoMars" || hitObject.transform.name == "InfoJupiter" ||
                            hitObject.transform.name == "InfoSaturn" || hitObject.transform.name == "InfoUranus" ||
                            hitObject.transform.name == "InfoNeptune" )
                    {
                        Back();
                    }

                    if (hitObject.transform.name == "Sun" || hitObject.transform.name == "Mercury" ||
                            hitObject.transform.name == "Venus" || hitObject.transform.name == "Earth" ||
                            hitObject.transform.name == "Mars" || hitObject.transform.name == "Jupiter" ||
                            hitObject.transform.name == "Saturn" || hitObject.transform.name == "Uranus" ||
                            hitObject.transform.name == "Neptune")
                    {
                        solarSystem.SetActive(false);
                        CurrentObject.SetActive(true);
                        buttonBack.SetActive(true);
                        sourceLight.SetActive(true);
                    }
                    /*else if (hitObject.transform.name == "Earth")
                    {
                        MeshRenderer rend = ChangedObject.GetComponent<MeshRenderer>();
                        rend.material.color = Color.blue;
                    }
                    else if (hitObject.transform.name == "Jupiter")
                    {
                        MeshRenderer rend = ChangedObject.GetComponent<MeshRenderer>();
                        rend.material.color = Color.green;
                    }*/
                }
            }
        }
    }

}
