using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLaser : MonoBehaviour
{

public Transform gunEnd;

public float laserRange = 50.0f;

public GameObject point;

private LineRenderer laserLine;

private Animator animTestGirl;

public GameObject TestGirl;



// Start is called before the first frame update
void Start()
{
    laserLine = GetComponent<LineRenderer>();

    animTestGirl = TestGirl.GetComponent<Animator>();

}

// Update is called once per frame
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

    //    if (Input.GetKeyDown(KeyCode.Alpha1)) //&& hit.transform.tag == "Anim1")
    //    {
    //        Debug.Log("Hit!");
     //       animTestGirl.Play("Hand Assist");

    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha2)) //&& hit.transform.tag == "Anim2")
    //    {
    //        Debug.Log("Hit!");
    //        animTestGirl.Play("Far Forward Lean");

    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha3)) //&& hit.transform.tag == "Anim3")
     //   {
     //       Debug.Log("Hit!");
     //       animTestGirl.Play("Knee Stand");

     //   }

     //   if (Input.GetKeyDown(KeyCode.Alpha4)) //&& hit.transform.tag == "Anim4")
     //   {
     //       Debug.Log("Hit!");
     //       animTestGirl.Play("SmallSteps_NeutralFaceFwdALLAnglesFwdTOBack_1");

     //   }

    }

    else
    {
        laserLine.SetPosition(1, gunEnd.forward * laserRange);
    }


}
}