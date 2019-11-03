using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public float playerSpeed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public Camera mainCamera;
    private Vector3 camFoward;
    private Vector3 CamRight;

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeFloatDown;

    public float pushPower = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove,0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();
        //movePlayer = new Vector3(horizontalMove, 0, verticalMove);
        movePlayer = playerInput.x * CamRight + playerInput.z * camFoward;
        movePlayer = movePlayer * playerSpeed;



        player.transform.LookAt(player.transform.position + movePlayer);
        //transform.rotation = Quaternion.LookRotation(movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime);

        Debug.Log(player.velocity.magnitude);
    }

    public void camDirection()
    {
         camFoward = mainCamera.transform.forward;
        CamRight = mainCamera.transform.right;

        camFoward.y = 0;
        CamRight.y = 0;

        camFoward = camFoward.normalized;
        CamRight = CamRight.normalized;


    }

    public void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity += gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        SlideDown();

    }

    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;

        }
    }

    public void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;

        if (isOnSlope)
        {
            movePlayer.x -= ((1f - hitNormal.y) * hitNormal.x) * slideVelocity;
            movePlayer.z -= ((1f - hitNormal.y) * hitNormal.z) * slideVelocity;

            movePlayer.y -= slopeFloatDown;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;


    }

    
}
