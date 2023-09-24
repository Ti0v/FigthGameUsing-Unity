using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayrs : MonoBehaviour
{


    public float moveSpeed = 14;
    private Animator playerAnimator;
    private float verticarValue;
   
    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();

    }

 
    private void Update()//return Fnc Move() && Turn()
    {
        verticarValue = Input.GetAxisRaw("Vertical");
        Move();
        Turn();
    }
    private void Move()//player Movment && Fire
    {
        //PlayerMovment
        if (verticarValue != 0)
        {
            playerAnimator.SetBool("Run", true);
            playerAnimator.SetFloat("Dirction", verticarValue);
            transform.position = transform.position + transform.forward*moveSpeed*verticarValue *Time.deltaTime; 
        }
        else {
            playerAnimator.SetBool("Run", false);
        }
    }
    
    private void Turn() {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;
        if (Physics.Raycast(cameraRay, out groundHit,Mathf.Infinity)) {
            Vector3 playerTomose = groundHit.point - transform.position;
            playerTomose.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(playerTomose);
            transform.rotation = newRotation;
        }

    } //Turn with mouse

}
    

