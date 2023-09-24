using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronAttacking : EnimeAttacking
{
    public GameObject bulletPrefaps;
    public Transform fireSpawnPoint;
    private float fireRate = 0.25f;
    private float Nextbulet;

  
    public override void Attaking()
    {
        if (Time.time > Nextbulet)
        {
            Nextbulet = Time.time + fireRate;
            GameObject bulet = Instantiate(bulletPrefaps, fireSpawnPoint.position, Quaternion.identity);
            bulet.GetComponent<Rigidbody>().velocity = transform.forward * 100;
            bulet.GetComponent<BulletDes>().targetTag = "Player";
            bulet.GetComponent<BulletDes>().target = BulletDes.TargetToDestroy.Player;
        }

    }
   






}
