using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnimeMovmint : MonoBehaviour
{
    private ScriptPlayrs playr;
    private NavMeshAgent agent;
    private Animator animator;
    public float maxSpeed = 5;
    public float cureentSped;
    public float stopingDistantse =22; 
    private float  Vect3;
    bool startMove = false;
    private EnimeAttacking enimeAttacking;
    private IEnumerator Start ()
    {
        yield return (new WaitForSeconds(3));
        startMove = true;
     
    }
    private void Awake()
    {
        enimeAttacking = GetComponent<EnimeAttacking>();
        playr = FindObjectOfType<ScriptPlayrs>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
     

    }
    private void Update()
    {
        if (!startMove)
        {
            return;
        }
        if(playr)
        Move();
    }
    public virtual void  Move() {
   
        Vect3 = Vector3.Distance(playr.transform.position, transform.position);
        if (Vect3 >= stopingDistantse)
        {
            enimeAttacking.StopAttaking();
            agent.SetDestination(playr.transform.position);
            animator.SetFloat("Move", cureentSped/maxSpeed);
            cureentSped += Time.deltaTime;
              cureentSped = Mathf.Clamp(cureentSped, 0, 5);
            animator.SetBool("Attack", false);
        }
        else {

          
            agent.SetDestination(transform.position);
            cureentSped = 0;
            animator.SetFloat("Move", 0 );
            enimeAttacking.Attaking();
        }
    }
    
}
