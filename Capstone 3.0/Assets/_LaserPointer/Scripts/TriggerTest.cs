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

    private Animator animGirl;
    private Animator animSkin;
    private Animator animMuscle;
    private Animator animSkinSideLean;

    public GameObject TestGirl;
    public GameObject manSkin;
    public GameObject manMuscle;
    public GameObject manSkinSideLean;

    private Vector3 originalPos;
    private Quaternion originalRot;

    public Transform alisonTransform;
    public Transform skinTransform;
    public Transform muscleTransform;



    void Start() //Monobehaviours without a Start function cannot be disabled in Editor, just FYI

    {

        originalPos = alisonTransform.transform.position;
        originalRot = alisonTransform.transform.rotation;

        animGirl = TestGirl.GetComponent<Animator>();
        animSkin = manSkin.GetComponent<Animator>();
        animMuscle = manMuscle.GetComponent<Animator>();
        animSkinSideLean = manSkinSideLean.GetComponent<Animator>();

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

            if (hit.transform.tag == "Skin")
            {
                Debug.Log("Skin");
                manSkin.SetActive(true);
                manMuscle.SetActive(false);
                TestGirl.SetActive(false);
            }

            if (hit.transform.tag == "Muscle")
            {
                Debug.Log("Muscle");
                manSkin.SetActive(false);
                manMuscle.SetActive(true);
                TestGirl.SetActive(false);
            }

            if (hit.transform.tag == "Girl")
            {
                Debug.Log("Skin");
                manSkin.SetActive(false);
                manMuscle.SetActive(false);
                TestGirl.SetActive(true);
            }


            if (hit.transform.tag == "Anim1")
            {
                Debug.Log("Hit!");
              
                animGirl.Play("Hand Assist");
                animSkin.Play("Hand Assist");
                animMuscle.Play("Hand Assist");
            }

            if (hit.transform.tag == "Anim2")
            {
                Debug.Log("Hit!");
                
                animGirl.Play("Far Forward Lean");
                animSkin.Play("Far Forward Lean");
                animMuscle.Play("Far Forward Lean");
            }

            if (hit.transform.tag == "Anim3")
            {
                Debug.Log("Hit!");
               
                animGirl.Play("Knee Stand");
                animSkin.Play("Knee Stand");
                animMuscle.Play("Knee Stand");

            }

            if (hit.transform.tag == "Anim4")
            {
                Debug.Log("Hit!");

                manSkin.SetActive(false);
                manMuscle.SetActive(false);
                TestGirl.SetActive(false);
                manSkinSideLean.SetActive(true);

                animSkinSideLean.Play("Side Lean");

                Invoke("SneakyTrick", 27f);

            }

                if (hit.transform.tag == "Mocap")
            {
                Debug.Log("Hit!");
                
                animGirl.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");
                animSkin.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");
                animMuscle.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");

            }

            if (hit.transform.tag == "Reset")
            {
                animGirl.Play("Idle_Neutral_2");
                animSkin.Play("Idle_Neutral_2");
                animMuscle.Play("Idle_Neutral_2");
                alisonTransform.transform.SetPositionAndRotation(originalPos, originalRot);
                skinTransform.transform.SetPositionAndRotation(originalPos, originalRot);
                muscleTransform.transform.SetPositionAndRotation(originalPos, originalRot);
            }

        }
    }

    private void SneakyTrick()
    {
        
        manSkinSideLean.SetActive(false);
    }
}
