using UnityEngine;
using System.Collections;

public class MoveCharacterScript : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			        // For determining which way the player is currently facing.

	public float moveForce = 5f;			        // Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				        // The fastest the player can travel in the x axis.

    


	void Update()
	{
	}
	
	
	void FixedUpdate ()
	{
        try
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    Vector3 touchPosition = Input.GetTouch(0).position;

                    //if they touched the the right of the screen 
                    if (touchPosition.x > Screen.width / 2)
                    {
                        transform.Translate(Vector3.right * 10 * Time.deltaTime);
                    }
                    else if (touchPosition.x < Screen.width / 2)
                    {
                        transform.Translate(Vector3.left * 10 * Time.deltaTime);
                    }

                    CheckAndFlip(touchPosition);
                }
            }
        }
        catch(UnityException e)
        {
            //do nothing
        }
	}
	
	
    private void CheckAndFlip (Vector3 side)
	{
        bool needsFlipped = false;  //flag to identify if the character needs to be flipped.

        if (side.x > Screen.width / 2 && !facingRight)   //if the player is left and then clicks right
        {
            needsFlipped = true;
        }
        else if (side.x < Screen.width / 2 && facingRight)  //if the player is right and then clicks left
        {
            needsFlipped = true;
        }

        //flips character if needed
        if (needsFlipped == true)
        {
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
	}
}
