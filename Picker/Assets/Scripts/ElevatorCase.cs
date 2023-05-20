using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCase : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Animator barrierArea;

    public void BarrierUp()
    {
        barrierArea.Play("BarrierUp");
    }

    public void Finish()
    {
        _gameManager.pickerMoveCase = true;
    }
}