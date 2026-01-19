using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction; 
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1; //0:left, 1:middle, 2:right
    public float laneDistance = 4f; //distance b/w 2 lanes

    public float jumpForce;
    public float gravity = -20f;

    public Animator animator;
    public bool isSliding = false;
    private bool isGrounded;
    public LayerMask groundedLayer;
    public Transform groundCheck;

    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        
        if (groundCheck == null)
        {
            GameObject go = new GameObject("GroundCheck");
            go.transform.SetParent(transform);
            // Assuming pivot is center, place at bottom. If pivot is feet, this might be offset, but let's try bounds.
            // Using a safe estimate based on standard capsule (height 2 -> offset -1)
            go.transform.localPosition = new Vector3(0, -1f, 0); 
            groundCheck = go.transform;
        }

        if (groundedLayer.value == 0)
        {
            groundedLayer = LayerMask.GetMask("Default");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        //Increase speed
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        animator.SetBool("isGameStarted", true);
        isGrounded = controller.isGrounded;
        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded)
        {
            direction.y = -1;
            if(SwipeManager.swipeUp || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
            if(SwipeManager.swipeDown && !isSliding || Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Slide());
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        //gather on which lane we should be
        if(SwipeManager.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3)
            desiredLane = 2;
        }

        if(SwipeManager.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1)
            desiredLane = 0;
        }

        Vector3 moveVector = transform.forward * forwardSpeed * Time.deltaTime;

        // Apply vertical velocity
        moveVector.y = direction.y * Time.deltaTime;

        // Calculate target X based on lane
        float targetX = (desiredLane - 1) * laneDistance;
        
        // Smoothly interpolate current X to target X
        float newX = Mathf.Lerp(transform.position.x, targetX, 10 * Time.deltaTime);
        moveVector.x = newX - transform.position.x;
        // controller.center = controller.center;

        controller.Move(moveVector);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Obstacles")
        {
            PlayerManager.ganeOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true); 
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false); 
        isSliding = false;
    }
}
