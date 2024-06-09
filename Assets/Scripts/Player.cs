using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Transform transformPlayer;
    public Transform transformMoveGoEmptyPlayer;
    public Transform transformRotationPlayer;
    public Rigidbody rigidbodyPlayer;

    public float factorAnimator = 1f;
    public float factorSpeedMove = 1.8f;

    public float speedInfo;
    Vector3 posStar;

    void Update()
    {
        if(_delta.magnitude != 0)
            transformRotationPlayer.rotation = Quaternion.LookRotation(transformMoveGoEmptyPlayer.position - transformPlayer.position);
    }


    private void FixedUpdate()
    {
        speedInfo = (transformPlayer.position - posStar).magnitude / Time.fixedDeltaTime;
        
        posStar = transformPlayer.position;
        
        
        
        animator.SetFloat("InputHorizontal", 0, 0.25f, Time.deltaTime);
        //animator.SetFloat("InputVertical", 0, 0.25f, Time.deltaTime);
        animator.SetFloat("InputMagnitude", speedInfo * factorAnimator, 0f, Time.deltaTime);
        //Багуля с рывками анимаций у перса
    
    }

    Vector3 _delta;

    public void Move(Vector3 delta)
    {
        //delta *= factorSpeedMove;
        transformMoveGoEmptyPlayer.localPosition = delta;
        
        //rigidbodyPlayer.AddForce(transformMoveGoEmptyPlayer.position - transformPlayer.position, ForceMode.Force);
        gameObject.transform.position += delta;
        _delta = delta;
    }
}
