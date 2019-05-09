﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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
    public GameObject menu;

    private void Start()
    {
        originalPos = alisonTransform.transform.position;
        originalRot = alisonTransform.transform.rotation;

        animGirl = TestGirl.GetComponent<Animator>();
        animSkin = manSkin.GetComponent<Animator>();
        animMuscle = manMuscle.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

       



        if (Input.GetKeyDown(KeyCode.Escape))

        {
            Debug.Log("Exited");
            Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            menu.SetActive(!menu.activeSelf);

        }


    }
}
