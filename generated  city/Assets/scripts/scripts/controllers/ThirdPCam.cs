using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPCam : MonoBehaviour
{
    public float rot = 1;
    public Transform Target, Player;
    float mouseX, mouseY;
   // bool pause=true;
    void Start()
    {
       
        NotMenu();
    }
    private void LateUpdate()
    {
        if (Time.timeScale > 0)
        {
            CamControl();
          
        }
       // if (!pause) {
      //      NotMenu();
      //      pause = true;
      //  }
    }
void NotMenu()
    {
Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    
    
    void CamControl()
    {

        mouseX += Input.GetAxis("Mouse X") * rot;
        mouseY -= Input.GetAxis("Mouse Y") * rot;
        mouseY = Mathf.Clamp(mouseY, -35, 60);


        transform.LookAt(Target);
        if (Input.GetKey(KeyCode.LeftControl))
        {

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }

    }

}