using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Controller : MonoBehaviour
{

    Animator playerAnim;
    // Use this for initialization
    void Start()
    {
        playerAnim = this.GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (playerAnim.GetInteger("Stance") == 0)
            {
                playerAnim.SetTrigger("isSAttacking");
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (playerAnim.GetInteger("Stance") == 1)
            {
                playerAnim.SetTrigger("isMAttacking");
            }
        }


        if (Input.GetKey(KeyCode.W))
        {
            if (playerAnim.GetInteger("Stance") == 0)
            {
                playerAnim.SetBool("isWalkingS", true);
            }
            else
            {
                playerAnim.SetBool("isWalkingM", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (playerAnim.GetInteger("Stance") == 0)
            {
                playerAnim.SetBool("isWalkingS", false);
            }
            else
            {
                playerAnim.SetBool("isWalkingM", false);
            }
        }

        if (Input.GetButtonDown("Switch"))
        {
            if (playerAnim.GetInteger("Stance") == 0)
            {
                playerAnim.SetTrigger("isSwitchingtoMagic");
                playerAnim.SetInteger("Stance", 1);
            }
            else
            {
                playerAnim.SetTrigger("isSwitchingtoSword");
                playerAnim.SetInteger("Stance", 0);
            }

        }

    }
}
