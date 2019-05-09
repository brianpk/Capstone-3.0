﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private Vector3 originalPos;
    private Quaternion originalRot;

    public Transform alisonTransform;
    public Transform skinTransform;
    public Transform muscleTransform;

    private Animator animGirl;
    private Animator animSkin;
    private Animator animMuscle;

    public GameObject TestGirl;
    public GameObject manSkin;
    public GameObject manMuscle;

    private void Start()
    {
        originalPos = alisonTransform.transform.position;
        originalRot = alisonTransform.transform.rotation;

        animGirl = TestGirl.GetComponent<Animator>();
        animSkin = manSkin.GetComponent<Animator>();
        animMuscle = manMuscle.GetComponent<Animator>();
    }

    public void ResetPos()
    {
        animGirl.Play("Idle_Neutral_2");
        animSkin.Play("Idle_Neutral_2");
        animMuscle.Play("Idle_Neutral_2");
        alisonTransform.transform.SetPositionAndRotation(originalPos, originalRot);
        skinTransform.transform.SetPositionAndRotation(originalPos, originalRot);
        muscleTransform.transform.SetPositionAndRotation(originalPos, originalRot);
    }

    
        
}