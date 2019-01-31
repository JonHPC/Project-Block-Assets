using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeaPlayer : MonoBehaviour {

    public float moveSpeed; //speed at which the player moves
    public float jumpPowerX;//power of jump X axis
    public float jumpPowerY;//power of the jump Y axis
    public float pushPower;//power of the push

    public Joystick joystick;//references the joystick UI
    public JumpButton jumpButton;//references the jumpButton script
    public bool isJumping;//checks to see if the player is jumping
    public Button grabButton;//references the grab button
    public Button letGoButton;//references the let go button
    public bool grabButtonOn;//gets turned on when grab button is pressed

    public bool isGrounded;//checks to see if the player is grounded
    public bool isMoving;//checks to see if the player is moving
    public bool isPushing;//checks to see if the player is pushing a block
    public bool isPulling;//checks to see if the player is pulling a block
    public bool isGrabbing;//checks to see if the player is grabbing a block
    public bool touchingWallLeft;//checks to see if the left facing player raycast is touching a wall
    public bool touchingWallRight;//checks to see if the right facing player raycast is touching a wall on the right side
    public bool touchingBlockLeft;//checks to see if the left facing player raycast is touching a block
    public bool touchingBlockRight;//checks to see if the right facing player raycast is touching a block

    //public PushBlock pushBlock;//references the PushBlock game object
    

    public LayerMask layermask;//chose which layer (floor) the raycast should hit
    public float Maxdistance = 2f;//how far the raycast travels
    public Vector2 direction = -Vector2.up;//direction of the raycast
    public RaycastHit2D hit;//the result of the hit on floots
    public RaycastHit2D wallHitLeft;//result of the wall hit left side
    public Vector2 leftDirection = Vector2.left;//direction for raycast
    public RaycastHit2D wallHitRight;//result of the wall hit right side
    public Vector2 rightDirection = Vector2.right;//directionf for raycast

    public LayerMask blockLayerMask;//layer for the block
    public RaycastHit2D blockHit;//result of the hit on the block to check isGrounded
    public RaycastHit2D blockHitLeft;//result of the hit on the block when going left
    public RaycastHit2D blockHitRight;//result of hte hit on the block when going right

    private Rigidbody2D playerRb;//stores the Rigidbody component
    private Vector3 pos;//stores the players current transform.position
    private Animator animator;//references and controls the animation
    private SpriteRenderer flipIt;//flips the X axis of the sprite when needed
    private AudioSource jumpSound;//references the jump sound



    // Use this for initialization
	void Start () {
        playerRb = GetComponent<Rigidbody2D>();//initializes the Rigidbody component
        animator = GetComponent<Animator>();//initializes the Animator component
        flipIt = GetComponent<SpriteRenderer>();//gets the spriterender component 
        jumpSound = GetComponent<AudioSource>();//initializes the Audio Source component

	}
	
	// Update is called once per frame
	void Update () {

        playerRb.AddForce(new Vector2(0f, -50f));//adds constant force downward

        Debug.DrawRay(transform.position, direction * Maxdistance, Color.green);//draws the ray for debugging
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, Maxdistance, layermask);//stores the result of the hit into this variable
        blockHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, Maxdistance, blockLayerMask);//stores the result of the hit into this variable

        if (hit.collider!=null || blockHit.collider!=null)//if the raycast hits, do this code
        {
            //the ray collided with something, you can interact
            // with the hit object now by using hit.collider.gameObject
            isGrounded = true;//changes this boolean
            animator.SetBool("isGrounded", isGrounded);//sets the animation according to whether or not the bunny is grounded.
        }
        else
        {
            isGrounded = false;//if the raycast does not hit anything, set this bool to false
            animator.SetBool("isGrounded", isGrounded);//sets the animation according to whether or not the bunny is grounded.
        }

        Debug.DrawRay(transform.position, leftDirection * Maxdistance, Color.blue);//draws the ray for debugging
        wallHitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), leftDirection, Maxdistance, layermask);//stores the result of the hit into this variable

        if (wallHitLeft.collider != null)//if the left raycast hits a block, run this code
        {
            touchingWallLeft = true;//sets this bool to true 

        }
        else
        {
            touchingWallLeft = false;//otherwise, this bool is false

        }


        Debug.DrawRay(transform.position, rightDirection * Maxdistance, Color.red);//draws the ray for debugging
        wallHitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), rightDirection, Maxdistance, layermask);//stores the result of the hit into this variable

        if (wallHitRight.collider != null)//if the right raycast hits a wall, run this code
        {
            touchingWallRight = true;//sets this bool to true

        }
        else
        {
            touchingWallRight = false;//otherwise, this bool is false

        }








        


        blockHitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), leftDirection, Maxdistance, blockLayerMask);//stores the result of the hit into this variable
        blockHitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), rightDirection, Maxdistance, blockLayerMask);//stores the result of the hit into this variable

        if (blockHitLeft.collider != null)//if the left raycast hits a block, run this code
        {
            touchingBlockLeft = true;//sets this bool to true 
            PushBlock pushBlock = blockHitLeft.collider.gameObject.GetComponent<PushBlock>();//if player is in contact with a pushblock, access its script
            //grabButton.gameObject.SetActive(true);//sets grab button to be visible
            //if (Input.GetKeyDown(KeyCode.UpArrow) && touchingBlockLeft == true)//only allows toggling when up arrow is pressed and the raycast hit is true
            if( grabButtonOn == true && touchingBlockLeft == true)
            {
                isGrabbing = true;//toggles the isGrabbing bool when the up arrow is pressed
                Debug.Log("grabbing");
                animator.SetBool("isGrabbing", isGrabbing);//sets the animation to grabbing

                pushBlock.beingGrabbed = true;//toggles the beingGrabbed bool in the PushBlock script
                
                isPushing = false;//resets this bool for animation purposes
                animator.SetBool("isPushing", isPushing);//sets the Animation to not pushing

                isPulling = false;//resets this bool for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling


            }
            else if (grabButtonOn == false && touchingBlockLeft == true)
            {
                isGrabbing = false;//toggles the isGrabbing bool when the up arrow is pressed
                Debug.Log("grabbing");
                animator.SetBool("isGrabbing", isGrabbing);//sets the animation to grabbing

                pushBlock.beingGrabbed = false;//toggles the beingGrabbed bool in the PushBlock script

                isPushing = false;//resets this bool for animation purposes
                animator.SetBool("isPushing", isPushing);//sets the Animation to not pushing

                isPulling = false;//resets this bool for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling
                grabButton.gameObject.SetActive(true);//sets the grab button active when touching a block but not grabbing

            }

            //else if (Input.GetAxis("Horizontal") > 0.01f && isGrabbing == true && touchingBlockLeft == true && isGrounded == true)//pulls the block to the right
            if (joystick.Horizontal > 0.01f && isGrabbing == true && touchingBlockLeft == true && isGrounded == true)//pulls the block to the right
            {
                flipIt.flipX = false;//flips the sprite to face right
                isPulling = true;
                animator.SetBool("isPulling", isPulling);//sets this animation to pulling right
                pushBlock.beingPulledRight = true;//calls the PushBlock script and sets the bool to true to apply the necessary velocity
            }
            //else if (Input.GetAxis("Horizontal") < -0.01f && isGrabbing == true && touchingBlockLeft == true && isGrounded == true)//pushes the block to the left
            else if (joystick.Horizontal < -0.01f && isGrabbing == true && touchingBlockLeft == true && isGrounded == true)//pushes the block to the left
            {
                flipIt.flipX = true;//flips the sprite to face left
                isPushing = true;
                animator.SetBool("isPushing", isPushing);//sets the animation to pushing left
                pushBlock.beingPushedLeft = true;//calls the pushblock script and sets the bool to true
            }
            else if (isGrounded == false && isGrabbing == true)
            {
                isGrabbing = false; //player is no longer grabbing
                animator.SetBool("isGrabbing", isGrabbing);//sets the animation
                isPulling = false;//resets for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling
                pushBlock.beingGrabbed = false;//if player is not grounded, let go of the block
            }
            else
            {
                isPushing = false;//resets for animation purposes
                animator.SetBool("isPushing", isPushing);//sets the Animation to not pushing

                isPulling = false;//resets for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling

                animator.SetBool("isGrabbing", isGrabbing);//sets the bool for isGrabbing (sets to not grabbing when block fixedjoint breaks)
                pushBlock.beingPulledRight = false;//resets
                pushBlock.beingPushedLeft = false;//resets


            }
        }
        else if (blockHitRight.collider != null)//if the right raycast is hitting a block, run this code
        {
            touchingBlockRight = true;//sets this bool to true 
            PushBlock pushBlock = blockHitRight.collider.gameObject.GetComponent<PushBlock>();//if player is in contact with a pushblock, access its script
            //if (Input.GetKeyDown(KeyCode.UpArrow) && touchingBlockRight == true)//only allows grabbing when touching a block
            if(grabButtonOn == true && touchingBlockRight == true)
            {
                isGrabbing = true;//toggles the isGrabbing bool when the up arrow is pressed
                Debug.Log("grabbing");
                animator.SetBool("isGrabbing", isGrabbing);//sets the animation to grabbing

                pushBlock.beingGrabbed = true;//toggles the beingGrabbed bool in the PushBlock script

                isPushing = false;//resets this bool for animation purposes
                animator.SetBool("isPushing", isPushing);//sets the Animation to not pushing

                isPulling = false;//resets this bool for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling

            }
            else if(grabButtonOn == false && touchingBlockRight == true)
            {
                isGrabbing = false;//toggles the isGrabbing bool when the up arrow is pressed
                Debug.Log("grabbing");
                animator.SetBool("isGrabbing", isGrabbing);//sets the animation to grabbing

                pushBlock.beingGrabbed = false;//toggles the beingGrabbed bool in the PushBlock script

                isPushing = false;//resets this bool for animation purposes
                animator.SetBool("isPushing", isPushing);//sets the Animation to not pushing

                isPulling = false;//resets this bool for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling
                grabButton.gameObject.SetActive(true);//sets the grab button active when touching a block but not grabbing

            }

            //else if (Input.GetAxis("Horizontal") < -0.01f && isGrabbing == true && touchingBlockRight == true && isGrounded == true)//pulls the block to the left 
            if (joystick.Horizontal < -0.01f && isGrabbing == true && touchingBlockRight == true && isGrounded == true)//pulls the block to the left 
            {
                flipIt.flipX = true;//flips the sprite to face left
                isPulling = true;
                animator.SetBool("isPulling", isPulling);//sets this animation to pulling left
                pushBlock.beingPulledLeft = true;//calls the PushBlock script and sets the bool to true to apply the necessary velocity
            }
            //else if (Input.GetAxis("Horizontal") > 0.01f && isGrabbing == true && touchingBlockRight == true && isGrounded == true)//pushes the block to the right
            else if (joystick.Horizontal > 0.01f && isGrabbing == true && touchingBlockRight == true && isGrounded == true)//pushes the block to the right
            {
                flipIt.flipX = false;//flips the sprite to face right
                isPushing = true;
                animator.SetBool("isPushing", isPushing);//sets the animation to pushing right
                pushBlock.beingPushedRight = true;//calls the oushblock script and sets the bool to true
            }
            else if (isGrounded == false && isGrabbing == true)
            {
                isGrabbing = false; //player is no longer grabbing
                animator.SetBool("isGrabbing", isGrabbing);//sets the animation
                isPulling = false;//resets for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling
                pushBlock.beingGrabbed = false;//if player is not grounded, let go of the block
            }
            else
            {
                isPushing = false;//resets for animation purposes
                animator.SetBool("isPushing", isPushing);//sets the Animation to not pushing

                isPulling = false;//resets for animation purposes
                animator.SetBool("isPulling", isPulling);//sets the animation to not pulling

                animator.SetBool("isGrabbing", isGrabbing);//sets the bool for isGrabbing (sets to not grabbing when block fixedjoint breaks)

                pushBlock.beingPulledLeft = false;//resets
                pushBlock.beingPushedRight = false;//resets

            }
        }
       
        else
        {
            touchingBlockLeft = false;//otherwise, this bool is false
            touchingBlockRight = false;
            grabButton.gameObject.SetActive(false);//grab button set false when no longer touching a block
            letGoButton.gameObject.SetActive(false);//
        }










        pos = transform.position;//stores the player's current position every frame

        //if (Input.GetAxis("Horizontal")>0.01f && touchingWallRight == false && touchingBlockRight == false && isGrabbing == false)//if the right arrow key is pressed down and not touching a wall on the right side
        if (joystick.Horizontal > 0.01f && touchingWallRight == false && touchingBlockRight == false && isGrabbing == false)
        {
            flipIt.flipX = false;//keeps the sprite facing right

            {
                pos.x += moveSpeed*Time.deltaTime;//adds tiltSpeed amount to the position
                transform.position = pos;//updates the position to the new position
                isMoving = true;//sets the isMoving boolean to True
                animator.SetBool("isMoving", isMoving);//sets the Animation to running
            }
        }
        //else if (Input.GetAxis("Horizontal")<-0.01f && touchingWallLeft == false && touchingBlockLeft == false && isGrabbing == false)//if the left arrow key is pressed down and not touching a wall on the left side
        else if (joystick.Horizontal < -0.01f && touchingWallLeft == false && touchingBlockLeft == false && isGrabbing == false)
        {
            flipIt.flipX = true;//flips the sprite to face left


            {
                pos.x -= moveSpeed*Time.deltaTime;//subtracts tiltSpeed amount to the position
                transform.position = pos;//updates the position to the new position
                isMoving = true;//sets the isMoving boolean to True
                animator.SetBool("isMoving", isMoving);//sets the Animation to running
            }
        }


        else
        {
            isMoving = false;//resets for animation purposes
            animator.SetBool("isMoving", isMoving);//sets player to not moving


        }

        if (jumpButton.pressed == true && isGrounded == true && isGrabbing == false)//if the jump button is pressed, the player is grounded, and not grabbing, allows jumps
        {
            if(isJumping == false)//prevents spamming jumps when holding button down
            {
                playerRb.AddForce(new Vector2(0f, jumpPowerY)); //adds the jumpPower of force to the player rigidbody to make it jump
                jumpSound.Play(); //plays jumpSound
                isJumping = true;//sets this to true to prevent spamming jumps
            }

        }
        /*if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true && isGrabbing == false)//if the space bar is pressed, the player is grounded, and not grabbing, allows jumps
        {
            playerRb.AddForce(new Vector2(0f, jumpPowerY)); //adds the jumpPower of force to the player rigidbody to make it jump
            jumpSound.Play(); //plays jumpSound
        }*/




    }


    public void grabButtonPress()
    {
        grabButtonOn = true;//toggles this bool
        grabButton.gameObject.SetActive(false);
        letGoButton.gameObject.SetActive(true);
    }

    public void letGoButtonPress()
    {
        grabButtonOn = false;
        letGoButton.gameObject.SetActive(false);
    }

}
