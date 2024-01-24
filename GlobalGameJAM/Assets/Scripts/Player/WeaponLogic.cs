using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    int EquippedWeapon;
    public GameObject Weapon1;
    // Start is called before the first frame update
    void Start()
    {
        EquippedWeapon = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (EquippedWeapon == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                fire1();
            }
        }
    }

    void fire1()
    {
        GameObject Projectile = Instantiate(Weapon1);
        Projectile.transform.position = gameObject.transform.position;
        Projectile.transform.rotation = gameObject.transform.rotation;

    }
}
