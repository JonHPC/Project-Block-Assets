using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public bool pressed;//checks if the button is pressed
    public TeaPlayer player;//accesses TeaPlayer Script

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
        player.isJumping = false;//sets this bool to false so the player can jump again

    }
}
