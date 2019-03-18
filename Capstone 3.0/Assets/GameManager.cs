using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Vector3 originalPos;
    private Quaternion originalRot;

    public Transform alisonTransform;

    private Animator animTestGirl;
    public GameObject TestGirl;

    private void Start()
    {
        originalPos = alisonTransform.transform.position;
        originalRot = alisonTransform.transform.rotation;

        animTestGirl = TestGirl.GetComponent<Animator>();
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
            animTestGirl.Play("Idle_Neutral_2");
            alisonTransform.transform.SetPositionAndRotation(originalPos, originalRot);
        }


    }
}
