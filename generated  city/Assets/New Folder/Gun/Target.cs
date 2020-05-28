
using UnityEngine;

public class Target : MonoBehaviour
{
    public float hp = 50f;
   public static int killcount;
    public void TakeDamage (float amount)
    {
        hp -= amount;
        if(hp<=0)
        {
            Die();
        }
    }

  void Die()
    {
        killcount++;
        Destroy(gameObject);
    }
    
}
