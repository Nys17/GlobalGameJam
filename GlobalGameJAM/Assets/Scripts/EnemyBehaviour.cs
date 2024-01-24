using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 10f;
    public float enemyCooldown = 3f;
    public GameObject player;
    public GameObject enemyWeapon;
    public GameObject firePoint;
    bool canFire;

    
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        EnemyFireCooldown();
    }
    void EnemyFireCooldown()
    {
        if (canFire == true)
        {
            Fire();
            canFire = false;

        }
        if (canFire == false)
        {
            enemyCooldown = enemyCooldown - 1f * Time.deltaTime;
            if (enemyCooldown <= 0f)
            {
                canFire = true;
                enemyCooldown = 5f;
            }
        }
    }
    void Fire()
    {
        GameObject Projectile = Instantiate(enemyWeapon);
        Projectile.transform.position = firePoint.transform.position;
        Projectile.transform.rotation = firePoint.transform.rotation;
    }
}
