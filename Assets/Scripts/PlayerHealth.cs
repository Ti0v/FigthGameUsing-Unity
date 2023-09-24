using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int Helth;
    private const int MAX_HEALTH = 100;
    void Start()
    {
        Helth = MAX_HEALTH;
    }

    public void DcreseHealth(int amontOfDcrese)
    {
        Helth -= amontOfDcrese;
        if (Helth <= 0) {
            Destroy(gameObject);
        }
    }

   
    
}
