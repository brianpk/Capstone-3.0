using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //I think this is old code. All of the updated laser code should be in "TriggerTest"
    public Transform gunEnd;

    public float laserRange = 50.0f;

    public GameObject point;

    private LineRenderer laserLine;

    private WaitForSeconds gunRecharge = new WaitForSeconds(1.0f);

    private Animator animGirl1;
    private Animator animGirl2;
    private Animator animGirl3;
    private Animator animTestGirl;
    

    public GameObject Girl1;
    public GameObject Girl2;
    public GameObject Girl3;
    public GameObject TestGirl;



    
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();

        animGirl1 = Girl1.GetComponent<Animator>();
        animGirl2 = Girl2.GetComponent<Animator>();
        animGirl3 = Girl3.GetComponent<Animator>();
        animTestGirl = TestGirl.GetComponent<Animator>();

    }

    
    void Update()
    {
        laserLine.enabled = true;

        Vector3 rayOrigin = gunEnd.position;

        RaycastHit hit;
        laserLine.SetPosition(0, gunEnd.position);


        if (Physics.Raycast(rayOrigin, gunEnd.forward, out hit, laserRange))
        {
            laserLine.SetPosition(1, hit.point);
            point.transform.position = hit.point;

            if (Input.GetKeyDown(KeyCode.A) && hit.transform.tag == "Anim1")
            {
                Debug.Log("Hit!");
                Girl1.SetActive(true);
                Girl2.SetActive(false);
                Girl3.SetActive(false);
                animGirl1.Play("Animation");
                animTestGirl.Play("Animation");

            }

            if (Input.GetKeyDown(KeyCode.A) && hit.transform.tag == "Anim2")
            {
                Debug.Log("Hit!");
                Girl2.SetActive(true);
                Girl1.SetActive(false);
                Girl3.SetActive(false);
                animGirl2.Play("Take 001");
                animTestGirl.Play("Take 001");

            }

            if (Input.GetKeyDown(KeyCode.A) && hit.transform.tag == "Anim3")
            {
                Debug.Log("Hit!");
                Girl2.SetActive(false);
                Girl1.SetActive(false);
                Girl3.SetActive(true);
                animGirl3.Play("Animation");
                animTestGirl.Play("Animation 0");

            }

            if (Input.GetKeyDown(KeyCode.A) && hit.transform.tag == "Anim4")
            {
                Debug.Log("Hit!");
                Girl2.SetActive(false);
                Girl1.SetActive(false);
                Girl3.SetActive(true);
                animTestGirl.Play("PlantNTurn180_Run_R_1");

            }

        }

        else
        {
            laserLine.SetPosition(1, gunEnd.forward * laserRange);
        }

        
    }
}

        
            

           
   

      
