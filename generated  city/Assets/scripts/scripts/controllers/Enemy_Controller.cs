using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{

    //wander AI
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;

    private bool isRotLeft = false;
    private bool isRotRight = false;
    private bool isWalking = false;







    public float lookRad = 10;
    public  int enemyHealth=100;

    //bullet

    public float bossSpray=5;
   public float shootTank = 600;
    public float shootGunner = 60;
    public float shootBoss = 10;
    public GameObject bullet;
    public float tankFireSpeed=10f;
    public float gunnerFireSpeed = 10f;
    public float BossFireSpeed = 10f;
    private GameObject _instBullet;
    public EnemyType type;
    EnemySpawner pop;
    Counting money;
   //where the units fires from
    public GameObject  firingBarrel;
  //  public GameObject firingGunner;
    //where bullets target
    //where bullets target

    //agent

    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
       

        //tank firing position? 


        //agent
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRad)
        {
            agent.SetDestination(target.position);

            //tank bullet
            if (type==EnemyType.tank)
            {
                shootTank-=1;
                if (shootTank <= 0 && Time.timeScale>0f)
                {
                    _instBullet = Instantiate(bullet, firingBarrel.transform.position, Quaternion.identity) as GameObject;
                    Rigidbody instBulletRigidbody = _instBullet.GetComponent<Rigidbody>();
                    instBulletRigidbody.AddForce((target.transform.position-transform.position).normalized*tankFireSpeed);
                    Destroy(_instBullet, 5);
                    shootTank = 60;
                }
            }
            if (type == EnemyType.gunner && Time.timeScale > 0f)
            {
                shootGunner -= 1;
                if (shootGunner <= 0)
                {
                    _instBullet = Instantiate(bullet, firingBarrel.transform.position, Quaternion.identity) as GameObject;
                    Rigidbody instBulletRigidbody = _instBullet.GetComponent<Rigidbody>();
                    instBulletRigidbody.AddForce((target.transform.position - transform.position).normalized * gunnerFireSpeed);
                    Destroy(_instBullet, 1);
                    shootGunner = 60;
                }
            }
            if (type == EnemyType.boss && Time.timeScale > 0f)
            {
                shootBoss -= 1;
                if (shootBoss <= 0)
                {
                    _instBullet = Instantiate(bullet, firingBarrel.transform.position, Quaternion.identity) as GameObject;
                    Rigidbody instBulletRigidbody = _instBullet.GetComponent<Rigidbody>();
                    instBulletRigidbody.AddForce((target.transform.position - transform.position).normalized * BossFireSpeed);
                    Destroy(_instBullet, 5);
                    shootBoss = 10;
                 
                }
            }
        }
        else
        {
            //wandering
            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }
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
 
       // Debug.Log(enemyHealth);
       
       
    }

  
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRad);
    }

    //wander Ai
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

    public enum EnemyType
    {
        meele,
        tank,
        boss,
            gunner
            }



}
