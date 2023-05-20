using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 offset;
  

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, Target.position + offset, .125f);

    }
}
