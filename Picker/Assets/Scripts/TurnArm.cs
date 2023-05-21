using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnArm : MonoBehaviour
{
    private bool Turn;
    [SerializeField] private float turnValue;
    public void TurnStart()
    {
        Turn = true;
    }
    void Update()
    {
        if(Turn)
        transform.Rotate(0, 0, turnValue, Space.Self);
    }
}