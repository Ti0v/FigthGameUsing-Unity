using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershotingf : MonoBehaviour
{
    public GameObject bulletPrefaps;
    public Transform FilreSpownPoint;
    private Animator PlayerAnimator;
    private float fireRate = 0.25f;
    private float Nextbulet;
    private void Awake()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        //fire
        if (Input.GetMouseButton(0))
        {
            PlayerAnimator.SetBool("Fire", true); ;
            if (Time.time > Nextbulet)
            {
                Nextbulet = Time.time + fireRate;
                GameObject bulet = Instantiate(bulletPrefaps, FilreSpownPoint.position, Quaternion.identity);
                bulet.GetComponent<Rigidbody>().velocity = transform.forward * 100;
                bulet.GetComponent<BulletDes>().targetTag = "Enemy";
                bulet.GetComponent<BulletDes>().target = BulletDes.TargetToDestroy.Enemy;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            PlayerAnimator.SetBool("Fire", false);
        }
    }
}
