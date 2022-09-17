using System;
using System.Collections;
using System.Collections.Generic;
using Ship.Controls;
using UnityEngine;

public class StabilizerManager : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public LayerMask MapMask;

    [SerializeField] private float Range;
    [SerializeField] private float Power;
    [SerializeField] private float Height;
    [SerializeField] private float StabilizingSpeed;


    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, Range, MapMask))
        {
            if (hit.distance < Height)
                Rigidbody.AddForce(transform.up * Power);

            var forward = Vector3.Cross(Vector3.Cross(Rigidbody.transform.forward, hit.normal), hit.normal);
            
            if (Vector3.Dot(forward, Rigidbody.transform.forward) < 0)
                forward = -forward;
            
            Rigidbody.MoveRotation(Quaternion.Lerp(Rigidbody.transform.rotation, Quaternion.LookRotation(forward, hit.normal),
                    StabilizingSpeed * Time.fixedDeltaTime));
        }
    }
    
    
    
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
#endif
}
