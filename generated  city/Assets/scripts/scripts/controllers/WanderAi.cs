using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAi : MonoBehaviour
{

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;

    private bool isRotLeft = false;
    private bool isRotRight = false;
    private bool isWalking = false;


    
    public float dis = 100;

    //    Transform tr_Player;
   Transform target;
    Transform tr_Player;
    float f_RotSpeed = 3.0f, f_MoveSpeed = 11.0f;

    // Use this for initialization
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
      
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

       
        if (distance <=dis)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

            /* Move at Player*/
            transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
        }
        else {
            if (isWandering == false)
            {
                StartCoroutine(Wander());

                if (isRotRight == true)
                {
                    transform.Rotate(transform.up * Time.deltaTime * rotSpeed);

                }

                if (isRotLeft == true)
                {
                    transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);

                }
                if (isWalking == true)
                {
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                }
            }
        }



        IEnumerator Wander()
        {
            int rotTime = Random.Range(1, 3);
            int rotWait = Random.Range(1, 4);

            int rotLorR = Random.Range(1, 2);
            int walkWait = Random.Range(1, 4);
            int walkTime = Random.Range(1, 5);

            isWandering = true;
            yield return new WaitForSeconds(walkWait);
            isWalking = true;
            yield return new WaitForSeconds(walkTime);
            isWalking = false;
            yield return new WaitForSeconds(rotWait);
            if (rotLorR == 1)
            {

                isRotRight = true;
                yield return new WaitForSeconds(rotTime);
                isRotRight = false;

            }
            if (rotLorR == 2)
            {
                isRotLeft = true;
                yield return new WaitForSeconds(rotTime);
                isRotLeft = false;


            }

            isWandering = false;
        }
    }
}
