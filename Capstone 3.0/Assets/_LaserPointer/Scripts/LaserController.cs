using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserController : MonoBehaviour
{
    public SteamVR_Action_Boolean TriggerClick;
    private SteamVR_Input_Sources inputSource;

    public Transform gunEnd;

    public float laserRange = 50.0f;

    public GameObject point;

    private LineRenderer laserLine;

    private Animator animTestGirl;

    public GameObject TestGirl;

    private void Start() //Monobehaviours without a Start function cannot be disabled in Editor, just FYI

    {
        laserLine = GetComponent<LineRenderer>();

        animTestGirl = TestGirl.GetComponent<Animator>();

    }

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    // Update is called once per frame
    void Update()
    {
        laserLine.enabled = true;

        laserLine.SetPosition(0, gunEnd.position);

 

    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        print("Success at " + Time.time);

        Vector3 rayOrigin = gunEnd.position;

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, gunEnd.forward, out hit, laserRange))
        {
            laserLine.SetPosition(1, hit.point);
            point.transform.position = hit.point;

            if (Input.GetKeyDown("VR_Trigger_Press")) //&& hit.transform.tag == "Anim1")
            {
                Debug.Log("Hit!");
                animTestGirl.Play("Hand Assist");

            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) //&& hit.transform.tag == "Anim2")
            {
                Debug.Log("Hit!");
                animTestGirl.Play("Far Forward Lean");

            }

            if (Input.GetKeyDown(KeyCode.Alpha3)) //&& hit.transform.tag == "Anim3")
            {
                Debug.Log("Hit!");
                animTestGirl.Play("Knee Stand");

            }

            if (Input.GetKeyDown(KeyCode.Alpha4)) //&& hit.transform.tag == "Anim4")
            {
                Debug.Log("Hit!");
                animTestGirl.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");

            }

        }

        else
        {
            laserLine.SetPosition(1, gunEnd.forward * laserRange);
        }


    }
}