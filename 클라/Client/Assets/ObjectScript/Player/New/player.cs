using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eState
{
    IDLE,
    MOVE,
    ATTACK,
}

public class player : MonoBehaviour
{
    #region singleton
    static player instance = null;
    public static player GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }
    #endregion
    
    public Vector3 moveVec;
    public float gravityPower;
    public float maxForward;// .3
    public float maxSide; // .2

    public float _movementSpeed = 5;

    public bool isJump;
    
    public CharacterController charCtrl;

    public eState curState;

    private void Start()
    {
        // CharacterController Init
        charCtrl = transform.GetComponent<CharacterController>();

        // State Init
        curState = eState.IDLE;
        
        // Data Init
        maxForward = .3f;
        maxSide = .2f;
        isJump = true;
    }

    private void Update()
    {
        GravityUpdate();
    }

    private void GravityUpdate()
    {
        if (charCtrl.isGrounded)
        {
            isJump = true;
            gravityPower = 0;
        }
        else
        {
            gravityPower += -10f * Time.deltaTime;
        }
        //if (gravityPower < -3f) _animator.SetBool("Jump", !_player.charCtrl.isGrounded);
    }
}