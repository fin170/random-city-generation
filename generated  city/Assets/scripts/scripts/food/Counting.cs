using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Counting : MonoBehaviour
{
   
    public GameObject gunText;
 
    

    void Update()
    {
        
      
       
        gunText.GetComponent<Text>().text = "Kill Count:" + Target.killcount;

    }
}
