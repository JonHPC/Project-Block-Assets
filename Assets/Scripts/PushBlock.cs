using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour {

    public GameObject playerRb;
    public float pullPower;

    public bool isGrounded;
    public bool beingGrabbed;
    public bool fixedJointSpawned;

    public bool beingPushedRight;
    public bool beingPushedLeft;

    public bool beingPulledRight;
    public bool beingPulledLeft;

    public LayerMask layermask;//chose which layer (floor) the raycast should hit
    public float Maxdistance = 6f;//how far the raycast travels
    public Vector2 direction = -Vector2.up;//direction of the raycast
    public RaycastHit2D hit;//the result of the hit on the floor left side


    private FixedJoint2D fj2d;

    private AudioSource pushSound;
    private Rigidbody2D blockRb;

	// Use this for initialization
	void Start () {
        //pushSound = GetComponent<AudioSource>();//initializes the audio source
        blockRb = GetComponent<Rigidbody2D>();//initializes the rigidbody2D component
        beingPushedRight = false;
        beingPushedLeft = false;
        beingPulledRight = false;
        beingPulledLeft = false;

	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), direction * Maxdistance, Color.green);//draws the ray for debugging
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), direction, Maxdistance, layermask);//stores the result of the hit into this variable

        if (hit.collider != null )//if the raycast hits, do this code
        {
            isGrounded = true;//changes this boolean
        }
        else
        {
            isGrounded = false;//if the raycast does not hit anything, set this bool to false
            playerRb.GetComponent<TeaPlayer>().isGrabbing = false;//turns this to false so the player lets go of the block if the block is no longer grounded
            playerRb.GetComponent<TeaPlayer>().grabButtonOn = false;//
            beingGrabbed = false;//turns this off so the fixed joint is destroyed

        }





        if (beingGrabbed == true)//if player grabs the push block, it makes this bool true
        {
            if(fixedJointSpawned == false)//makes sure only one fixed joint spawns
            {
                gameObject.AddComponent<FixedJoint2D>();//adds the fixedjoint2d component to the pushblock
                fixedJointSpawned = true;//makes this true to prevent extra fixedjoint2d components
                fj2d = GetComponent<FixedJoint2D>();//initializes the component
                fj2d.connectedBody = playerRb.GetComponent<Rigidbody2D>();//the fixed joint attaches to the player's rigidbody
            }


            if (beingPulledRight == true || beingPushedRight == true)//checks these booleans from the player script
            {
                blockRb.velocity = new Vector2(pullPower, 0f);//applies this much pullPower to the right for both push or pull
            }
            else if (beingPulledLeft == true || beingPushedLeft == true)
            {
                blockRb.velocity = new Vector2(-pullPower, 0f);//applies this much pullPower to the left
            }
        }
        else if (beingGrabbed == false || isGrounded == false )//if the pushblock is no longer being grabbed or if the block is not grounded, this runs
        {
            if(fixedJointSpawned == true)//if there is a fixed joint component spawned...
            {
                fj2d.connectedBody = null;// when no longer grabbed, removed player rigidbody from the fixed joint
                Destroy(fj2d);//destroys the fixedjoint2d component
            }

            fixedJointSpawned = false;//sets this to false (no fixed joint component)
        }




       
	}


}
