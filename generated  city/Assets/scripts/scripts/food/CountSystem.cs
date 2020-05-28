using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountSystem : MonoBehaviour
{
    public AudioSource collectSound;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            collectSound.Play();
          

            Destroy(gameObject);
        }
        
    }
}
