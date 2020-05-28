
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public int selectedWeapon;
    void Start()
    {
        Sw();
    }


    void Update()
    {

        int previousW=selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else selectedWeapon++;

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0) { 
                selectedWeapon = transform.childCount-1;
            } else selectedWeapon--;

        }
        if (previousW != selectedWeapon)
        {
            Sw();
        }

    }

    void Sw()
    {

        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}

