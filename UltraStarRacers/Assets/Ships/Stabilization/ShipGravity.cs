using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using UnityEngine;

public class ShipGravity : MonoBehaviour
{
    public Rigidbody Rigidbody;

    private void FixedUpdate()
    {
        Rigidbody.AddForce(Physics.gravity);
    }
}
