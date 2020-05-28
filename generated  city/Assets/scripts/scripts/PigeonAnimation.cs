using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonAnimation : MonoBehaviour
{
    Animator anim;
    public GameObject Player;

    private void Start()
    {
        anim = GetComponent <Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Forward"))
        {
            anim.SetBool("Moving Forward", true);
        }

        if (Input.GetButtonUp("Forward"))
        {
            anim.SetBool("Moving Forward", false);
        }


        if (Input.GetButtonDown("Left")) 
        {
            anim.SetBool("Moving Left", true);
        }

        if (Input.GetButtonUp("Left"))
        {
            anim.SetBool("Moving Left", false);
        }


        if (Input.GetButtonDown("Backwards")) 
        {
            anim.SetBool("Moving Backwards", true);
        }

        if (Input.GetButtonUp("Backwards"))
        {
            anim.SetBool("Moving Backwards", false);
        }


        if (Input.GetButtonDown("Right")) 
        {
            anim.SetBool("Moving Right", true);
        }

        if (Input.GetButtonUp("Right"))
        {
            anim.SetBool("Moving Right", false);
        }
    }
}
