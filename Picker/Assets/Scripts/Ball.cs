using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallCounter"))
        {
            _gameManager.BallCount();
        }
    }

  
}
