using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
public class PlaceOnPlane : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject PlaneMarkerPrefab;
    private ARRaycastManager ARRaycastManagerScript;
    public GameObject SolarSystemObject;
    public GameObject buttonRotate;
    public GameObject buttonInfo;
    public TextMeshProUGUI textWaitMesh;
    
    private bool placedSS;
    
    
    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();
        PlaneMarkerPrefab.SetActive(false);
        SolarSystemObject.SetActive(false);
        placedSS = false;
        buttonRotate.SetActive(placedSS);
        buttonInfo.SetActive(placedSS);
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!placedSS)
        {
            ShowPlaneMarker();
        }
        buttonRotate.SetActive(placedSS);
        buttonInfo.SetActive(placedSS);
       

    }

    void ShowPlaneMarker()
    {

        textWaitMesh.text = "Wait for the blue marker...";
        List<ARRaycastHit> planes = new List<ARRaycastHit>();
            ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), planes, TrackableType.Planes);
            if (planes.Count > 0)
            {
                PlaneMarkerPrefab.transform.position = planes[0].pose.position;
                PlaneMarkerPrefab.SetActive(true);
                textWaitMesh.text = "";

            }

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                //Instantiate(SolarSystemObject, planes[0].pose.position, SolarSystemObject.transform.rotation);
                SolarSystemObject.transform.position = planes[0].pose.position;
                SolarSystemObject.SetActive(true);
                PlaneMarkerPrefab.SetActive(false);
                placedSS = true;
                
        }
        

    }
}
