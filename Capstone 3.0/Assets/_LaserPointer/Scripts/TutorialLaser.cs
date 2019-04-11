using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TutorialLaser : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public Transform gunEnd;

    public float laserRange = 50.0f;

    public GameObject point;


    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;

    public Material green;

    private LineRenderer laserLine;

  



    void Start() 

    {
        string[] joysticks = Input.GetJoystickNames();
        foreach (string j in joysticks)
        {
            Debug.Log(j);
        }

      

    }

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            Debug.Log("Horizontal axis value is " + Input.GetAxis("Horizontal").ToString("#.####"));
        }

        Vector3 rayOrigin = gunEnd.position;

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Physics.Raycast(rayOrigin, gunEnd.forward, out hit, laserRange))
            {
                point.transform.position = hit.point;


                if (hit.transform.tag == "Cube1")
                {
                    Debug.Log("Success 1!");
                    box1.GetComponent<Renderer>().material = green;
                }


                if (hit.transform.tag == "Cube2")
                    box2.GetComponent<Renderer>().material = green;

                if (hit.transform.tag == "Cube3")
                    box3.GetComponent<Renderer>().material = green;

                if (hit.transform.tag == "Cube4")
                    box4.GetComponent<Renderer>().material = green;
            }
        




        }

    }


    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        print("Success at " + Time.time);

        Vector3 rayOrigin = gunEnd.position;

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, gunEnd.forward, out hit, laserRange))
            {
                point.transform.position = hit.point;

           
                if (hit.transform.tag == "Cube1")
                {
                    Debug.Log("Success 1!");
                    box1.GetComponent<Renderer>().material = green;
                }
                    

                if (hit.transform.tag == "Cube2")
                    box2.GetComponent<Renderer>().material = green;

                if (hit.transform.tag == "Cube3")
                    box3.GetComponent<Renderer>().material = green;

                if (hit.transform.tag == "Cube4")
                    box4.GetComponent<Renderer>().material = green;
            

                

                   



            }
        

        else
        {
            laserLine.SetPosition(1, gunEnd.forward * laserRange);
        }



    }



}



