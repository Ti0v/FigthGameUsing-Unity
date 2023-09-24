using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDes : MonoBehaviour
{
    public string targetTag;
    public TargetToDestroy target;
    public enum TargetToDestroy {Player, Enemy }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            if (target == TargetToDestroy.Enemy)
            {
               Destroy(collision.gameObject);
            }
            else if (target == TargetToDestroy.Player) 
            collision.gameObject.GetComponent<PlayerHealth>().DcreseHealth(5);
        }
        Destroy(gameObject);

    }
}
