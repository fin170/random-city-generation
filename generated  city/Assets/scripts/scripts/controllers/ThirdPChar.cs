using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPChar : MonoBehaviour
{
    public float speed;
    public float run;
    public float fly;
    float jump;
       public float high=1;
    public GameObject grounded;
    bool skeet=false;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {


            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
  if (skeet)
        {
            transform.position += transform.forward * Time.deltaTime * fly;
            skeet = false;
        }
        if (!skeet && Input.GetKey(KeyCode.Space))
        {
         
            skeet = true;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = 2;
        }
        else run = 1;


        Vector3 PlayerMovement = new Vector3(hor, jump * high, ver) * speed * run * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);




    }
}
