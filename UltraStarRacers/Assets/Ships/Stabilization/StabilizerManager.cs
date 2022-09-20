using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using UnityEngine;
using UnityEngine.Serialization;

public class StabilizerManager : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public LayerMask MapMask;

    [SerializeField] private float Range;
    [SerializeField] private float Power;
    [SerializeField] private float Height;
    [SerializeField] private float StabilizingSpeed;
    [SerializeField] private float VerticalDampening;
    [SerializeField, Range(0, 1)] private float InverseStabilizationThreshold;


    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -Rigidbody.transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit, Range, MapMask))
        {
            if (hit.distance < Height)
                Rigidbody.AddForce(transform.up * Power);

            //VerticalDamp();

            StabilizeOrientation(hit.normal);
        }
        else if (Vector3.Dot(Rigidbody.transform.up, Physics.gravity.normalized) > -InverseStabilizationThreshold)
        {
            Ray rayGround = new Ray(transform.position, Physics.gravity);
            if (Physics.Raycast(rayGround, out RaycastHit hitGround, Range, MapMask))
            {
                if (hitGround.distance < Height)
                    Rigidbody.AddForce(-Physics.gravity * Power);

            }

            StabilizeOrientation(-Physics.gravity);
        }
    }

    void StabilizeOrientation(Vector3 normal)
    {
        var forward = Vector3.Cross(Vector3.Cross(Rigidbody.transform.forward, normal), normal);
            
        if (Vector3.Dot(forward, Rigidbody.transform.forward) < 0)
            forward = -forward;
        
        Rigidbody.MoveRotation(Quaternion.RotateTowards(Rigidbody.transform.rotation, Quaternion.LookRotation(forward, normal),
            StabilizingSpeed * Time.fixedDeltaTime));
    }

    private void VerticalDamp()
    {
        var up = Vector3.Project(Rigidbody.velocity, Rigidbody.transform.up);
        Rigidbody.velocity -= up * Mathf.Clamp01(VerticalDampening * Time.fixedDeltaTime);
    }
}
