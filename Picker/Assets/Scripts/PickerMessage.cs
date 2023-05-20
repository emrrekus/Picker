using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMessage : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerBorderObject"))
        {
            _gameManager.BorderIsComing();
        }
    }
}
