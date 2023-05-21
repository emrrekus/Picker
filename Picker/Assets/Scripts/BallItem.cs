using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallItem : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private string itemType;
    [SerializeField] private int bonusBallIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickerBorderObject"))
        {

            if (itemType == "Palet")
            {
                _gameManager.PaletIsActive();
                gameObject.SetActive(false);
            }
            else
            {
                _gameManager.BonusBallAdd(bonusBallIndex);
                gameObject.SetActive(false);
            }
            
        }
    }
}
