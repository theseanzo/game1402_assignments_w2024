using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))] //require component forces us to take on a component

public class A2Animal : MonoBehaviour
{
    protected bool canMove = false; //boolean which will tell if the animal can or cannot move, this will be used to control when the player moves

    // Update is called once per frame
    void Awake()
    {

    }
    public virtual void Move()
    {
        canMove = !canMove; //toggling the canmove to true only when the player can actually move, since it starts as false
    }

}
