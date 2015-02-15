using UnityEngine;
using System.Collections;

public class CharacterRanngeScript : MonoBehaviour
{

    public Transform rangeWeapon;
    public float speed = 20f;

    private Rigidbody2D rangeWeaponInstance;            //an instance of the currently thrown
    private Stats baseStats = new Stats();
    private MoveCharacterScript moveCharacter;  //reference to the move character script to get the facing direction.

    // Use this for initialization
    void Start()
    {

    }

    void Awake()
    {
        moveCharacter = transform.root.GetComponent<MoveCharacterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rangeWeaponInstance == null)
        {
            if (Input.touchCount > 0)
            {
                //check to see if they press double tap
                if (Input.GetTouch(0).tapCount == 2)
                {

                    if (moveCharacter.facingRight)
                    {
                        //create a new instance of the range weapon
                        rangeWeaponInstance = Instantiate(rangeWeapon, transform.position, Quaternion.Euler(0, 0, 0)) as Rigidbody2D;
                        //shoot it right
                        rangeWeaponInstance.AddForce(new Vector2(speed, 0));

                    }
                    else
                    {
                        //create a new instance of the range weapon
                        rangeWeaponInstance = Instantiate(rangeWeapon, transform.position, Quaternion.Euler(0, 0, 180f)) as Rigidbody2D;
                        //shoot it left
                        rangeWeaponInstance.AddForce(new Vector2(-speed, 0));
                    }
                }
            }
        }
    }
}