using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    int foodCount;
    public GameObject food;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name== "food")
        {

            foodCount++;
           Destroy(food);
            Debug.Log(foodCount);
        }


        
    }
}
