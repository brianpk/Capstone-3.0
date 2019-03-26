using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTrigger : MonoBehaviour

{
    private Animator animGirl;
    private Animator animSkin;
    private Animator animMuscle;
    private Animator animSkinSideLean;

    public GameObject TestGirl;
    public GameObject manSkin;
    public GameObject manMuscle;
    public GameObject manSkinSideLean;

    void Start()
    {
        animGirl = TestGirl.GetComponent<Animator>();
        animSkin = manSkin.GetComponent<Animator>();
        animMuscle = manMuscle.GetComponent<Animator>();
        animSkinSideLean = manSkinSideLean.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Hit!");

            animGirl.Play("Hand Assist");
            animSkin.Play("Hand Assist");
            animMuscle.Play("Hand Assist");

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Hit!");

            animGirl.Play("Far Forward Lean");
            animSkin.Play("Far Forward Lean");
            animMuscle.Play("Far Forward Lean");

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Hit!");

            animGirl.Play("Knee Stand");
            animSkin.Play("Knee Stand");
            animMuscle.Play("Knee Stand");

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Hit!");

            manSkin.SetActive(false);
            manMuscle.SetActive(false);
            TestGirl.SetActive(false);
            manSkinSideLean.SetActive(true);

            animSkinSideLean.Play("Side Lean");

            Invoke("SneakyTrick", 27f); //check here if there is a problem
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Hit!");

            animGirl.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");
            animSkin.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");
            animMuscle.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Skin");
            manSkin.SetActive(true);
            manMuscle.SetActive(false);
            TestGirl.SetActive(false);
            manSkinSideLean.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Muscle");
            manSkin.SetActive(false);
            manMuscle.SetActive(true);
            TestGirl.SetActive(false);
            manSkinSideLean.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("Skin");
            manSkin.SetActive(false);
            manMuscle.SetActive(false);
            TestGirl.SetActive(true);
            manSkinSideLean.SetActive(false);

        }
    }

    private void SneakyTrick()
    {
        manSkin.SetActive(true);
        manSkinSideLean.SetActive(false);
    }
}
