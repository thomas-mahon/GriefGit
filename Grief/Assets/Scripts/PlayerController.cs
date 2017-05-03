using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    GameObject deathPanel;
    [SerializeField]
    Transform groundDetectPoint;
    [SerializeField]
    float groundDetectRadius;
    [SerializeField]
    LayerMask whatIsGround;
    [SerializeField]
    float moveSpeed = 300f;
    [SerializeField]
    float jumpVelocity = 7f;
    [SerializeField]
    Color color1;
    [SerializeField]
    Color color2;
    [SerializeField]
    Color color3;
    [SerializeField]
    float secondsToWaitForColorFlash;

    [HideInInspector]
    public SpriteRenderer SpriteRenderer;
    [HideInInspector]
    public Transform LastCheckpoint;


    Rigidbody2D myRigidbody2D;
    bool isAlive;
    Animator animator;
    bool isOnGround;
    int randomColorChooser;

    // Use this for initialization
    void Start() {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        isAlive = true;
        LastCheckpoint = transform;
        animator = GetComponent<Animator>();
        ChangeColorAtRandom();
        StartCoroutine(ColorFlash());
    }

    private IEnumerator ColorFlash() {
        yield return new WaitForSeconds(secondsToWaitForColorFlash);
        Color previousColor = SpriteRenderer.color;
        ChangeColorAtRandom();
        while (SpriteRenderer.color == previousColor)
            ChangeColorAtRandom();
        StartCoroutine(ColorFlash());
    }

    private void ChangeColorAtRandom() {
        randomColorChooser = UnityEngine.Random.Range(2,5);
        switch (randomColorChooser)
        {
            case 2:
                SpriteRenderer.color = color1;
                break;
            case 3:
                SpriteRenderer.color = color2;
                break;
            case 4:
                SpriteRenderer.color = color3;
                break;
            default:
                SpriteRenderer.color = Color.white;
                break;
        }
    }



    // Update is called once per frame
    void Update() {
        animator.SetBool("IsOnGround", UpdateIsOnGround());
        if (isAlive)
        {
            HandleMovementInput();
            HandleJumpInput();
            animator.SetBool("IsAlive", true);
            UpdateIsOnGround();
        }
        else
        {
            animator.SetBool("IsAlive", false);
            if (Input.GetButtonDown("Jump"))
                Respawn();
        }
    }

    private void HandleJumpInput() {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            Vector2 velocityToSet = new Vector2(myRigidbody2D.velocity.x, jumpVelocity);
            setVelocity(velocityToSet);
        }
    }

    private bool UpdateIsOnGround() {

        Collider2D[] groundColliders =
            Physics2D.OverlapCircleAll(groundDetectPoint.position, groundDetectRadius, whatIsGround);

        isOnGround = groundColliders.Length > 0;

        return isOnGround;
    }


    private void HandleMovementInput() {
        float movementInput = Input.GetAxis("Horizontal");
        float xVelocity = moveSpeed * movementInput * Time.deltaTime;
        float yVelocity = myRigidbody2D.velocity.y;
        bool isFacingRight = !SpriteRenderer.flipX;

        if (isFacingRight && movementInput < 0)
            SpriteRenderer.flipX = true;
        else if (!isFacingRight && movementInput > 0)
            SpriteRenderer.flipX = false;

        Vector2 velocityToSet = new Vector2(xVelocity, yVelocity);
        setVelocity(velocityToSet);

        animator.SetFloat("XInput", Mathf.Abs(movementInput));
    }

    private void setVelocity(Vector2 velocityToSet) {
        myRigidbody2D.velocity = velocityToSet;
    }

    private void ApplyDamage() {
        isAlive = false;
        deathPanel.SetActive(true);
    }

    private void Respawn() {
        isAlive = true;
        transform.position = LastCheckpoint.position;
        deathPanel.SetActive(false);
    }
}
