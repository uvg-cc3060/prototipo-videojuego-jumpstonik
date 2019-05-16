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

        movePlayer = playerInput.x * CamRight + playerInput.z * camFoward;
        movePlayer = movePlayer * playerSpeed;

        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();

        PlayerSkills();

        player.Move(movePlayer * Time.deltaTime*-1);

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

    }

    public void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;

        }
    }
}
