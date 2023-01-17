using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void FixedUpdate()
    {
        Ray _ray = new Ray(transform.position, Vector3.forward);
        Physics.Raycast(_ray, out RaycastHit _raycastHit, 5f);

        
        Debug.Log(_raycastHit.collider.ToString());

        Vector3 forvard = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forvard, Color.red);
    }
}
