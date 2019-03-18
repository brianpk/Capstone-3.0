using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TriggerTest : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public Transform gunEnd;

    public float laserRange = 50.0f;

    public GameObject point;

    private Animator animTestGirl;

    public GameObject TestGirl;

    private Vector3 originalPos;
    private Quaternion originalRot;

    public Transform alisonTransform;



    void Start() //Monobehaviours without a Start function cannot be disabled in Editor, just FYI

    {

        originalPos = alisonTransform.transform.position;
        originalRot = alisonTransform.transform.rotation;

        animTestGirl = TestGirl.GetComponent<Animator>();

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
         if(Input.GetAxis("Horizontal") != 0.0f)
        {
            Debug.Log("Horizontal axis value is " + Input.GetAxis("Horizontal").ToString("#.####"));
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

            if (hit.transform.tag == "Anim1")
            {
                Debug.Log("Hit!");
              
                animTestGirl.Play("Hand Assist");

            }

            if (hit.transform.tag == "Anim2")
            {
                Debug.Log("Hit!");
                
                animTestGirl.Play("Far Forward Lean");

            }

            if (hit.transform.tag == "Anim3")
            {
                Debug.Log("Hit!");
               
                animTestGirl.Play("Knee Stand");

            }

            if (hit.transform.tag == "Anim4")
            {
                Debug.Log("Hit!");
                
                animTestGirl.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");

            }

            if (hit.transform.tag == "Reset")
            {
                animTestGirl.Play("Idle_Neutral_2");
                alisonTransform.transform.SetPositionAndRotation(originalPos, originalRot);
            }

        }
    }
}
