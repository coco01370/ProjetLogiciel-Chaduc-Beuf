using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //public
    public float MoveSpeed, JumpForce;
    public Transform GroundCheckPoint;
    public LayerMask WhatIsGround;
    public bool IsKeyboard2;
    public float timeBetweenAttacks = 0.25f;

    //serializeField
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;

    //private
    float velocity;
    private bool isGrounded;
    float attackCounter;
    private int isGroundedHash;
    private int ySpeedHash;
    private int speedHash;


    //encapsulation
    public Rigidbody2D Rb { get => rb; set => rb = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        GameManager.instance.AddPlayer(this);

        //animatorHash
        isGroundedHash = Animator.StringToHash("isGrounded");
        ySpeedHash = Animator.StringToHash("ySpeed");
        speedHash = Animator.StringToHash("speed");

    }

    // Update is called once per frame
    void Update()
    {
        #region multiplayer on Keyboard
        if (IsKeyboard2)
        {
            velocity = 0f;
            if (Keyboard.current.lKey.isPressed)
            {
                velocity += 1f;
            }
            else if (Keyboard.current.jKey.isPressed)
            {
                velocity -= 1f;
            }

            if (isGrounded && Keyboard.current.rightShiftKey.wasPressedThisFrame)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);

            }
            else if (isGrounded && Keyboard.current.rightShiftKey.wasReleasedThisFrame)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * .5f);

            }
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                AttackSetup();
            }
        }
        #endregion

        isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, .2f, WhatIsGround);

        Rb.velocity = new Vector2(velocity * MoveSpeed, Rb.velocity.y);

        attackCounter -= Time.deltaTime;
    }
    private void LateUpdate()
    {
        animator.SetBool(isGroundedHash, isGrounded);
        animator.SetFloat(ySpeedHash, Rb.velocity.y);
        animator.SetFloat(speedHash, Mathf.Abs(Rb.velocity.x));

        transform.eulerAngles = (Rb.velocity.x < 0) ? new Vector2(0, 180) : new Vector2(0, 0);

    }
    public void Move(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.started && isGrounded)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, JumpForce);

        }
        if (context.canceled && Rb.velocity.y > 0f && !isGrounded)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * .5f);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            print("jen jan");
            AttackSetup();
        }
    }

    private void AttackSetup()
    {
        if (attackCounter > 0) return;
        print("Attack");
        animator.SetTrigger("Attack");
        attackCounter = timeBetweenAttacks;
    }
}
