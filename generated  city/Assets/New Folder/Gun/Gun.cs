
using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour
{
    public float damage =10f;
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 10f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private bool isReloading = false;
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    // Update is called once per frame

 public AudioSource a;
   
    public Animator animator;

    private float fire = 0f;

    private void Start()
    {
        a = GetComponent<AudioSource>();
       
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("reload", false);
    }
    void Update()
    {

        if (isReloading)
            return;
            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetButton("Fire1") && Time.time >= fire)
            {
                fire = Time.time + 1f / fireRate;
                Shoot();
            }
        
        
    }
   IEnumerator Reload()
    {
        Debug.Log("reloading");
        isReloading = true;
        animator.SetBool("reload",true);
  
        yield return new WaitForSeconds(reloadTime-.25f);
        currentAmmo = maxAmmo;
        yield return new WaitForSeconds( .25f);
        animator.SetBool("reload", false);
        isReloading = false ;
    }
    void Shoot()
    {
        muzzleFlash.Play();
        a.Play();
        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {

                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
          GameObject impactGo= Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 0.2f);

        }
    }
}
