﻿using UnityEngine;
using System.Collections;

public class CharacterRangeScript : MonoBehaviour
{
    public float speed = 1000f;

    private GameObject rangeWeapon;
    private GameObject rangeWeaponInstance;     //a copy of the range weapon
    private Stats baseStats = new Stats();
    private MoveCharacterScript moveCharacter;  //reference to the move character script to get the facing direction.

    // Use this for initialization
    void Start()
    {
        rangeWeapon = GameObject.FindGameObjectWithTag("RangeWeapon");
        moveCharacter = gameObject.GetComponent<MoveCharacterScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            //check to see if they press double tap
            if (Input.GetTouch(0).tapCount == 2)
            {
                if (moveCharacter.facingRight)
                {
                    if (rangeWeaponInstance == null)
                    {
                        //create a new instance of the range weapon
                        rangeWeaponInstance = (GameObject)Instantiate(rangeWeapon, new Vector3(transform.localPosition.x + 5, transform.localPosition.y + 14, 0), Quaternion.Euler(0, 0, 0));

                        //shoot it right
                        rangeWeaponInstance.rigidbody2D.AddForce(new Vector2(speed, 0));
                    }
                }
                else
                {
                    if (rangeWeaponInstance == null)
                    {
                        //create a new instance of the range weapon
                        rangeWeaponInstance = (GameObject)Instantiate(rangeWeapon, new Vector3(transform.localPosition.x - 5, transform.localPosition.y + 14, 0), Quaternion.Euler(0, 0, 180f));
                        //shoot it left
                        rangeWeaponInstance.rigidbody2D.AddForce(new Vector2(-speed, 0));
                    }
                }
            }
        }
    }
}