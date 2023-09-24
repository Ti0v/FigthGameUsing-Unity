using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimeAttacking : MonoBehaviour
{
    private PlayerHealth PlyerHealth;
    private Animator animator;
    bool AttakingActive = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlyerHealth = FindObjectOfType<PlayerHealth>();
    }
    public  virtual void Attaking() {
        if (AttakingActive)
            return;
        AttakingActive = true;
        StartCoroutine(AttackCoroten());
       
       
    }
    public void StopAttaking() {
        AttakingActive = false;
    }
    private IEnumerator AttackCoroten()
    {
        animator.SetBool("Attack", true);
        while (AttakingActive)
        {
         if(PlyerHealth)
            PlyerHealth.DcreseHealth(5);

            yield return (new WaitForSeconds(1));
        }
    }
}
