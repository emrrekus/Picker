using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


[Serializable]
public class BallAreaTechinical
{
    public Animator ballAreaElevator;
    public TextMeshProUGUI numberText;
    public int needBall;
    public GameObject[] balls;

}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pickerObject;
    [SerializeField] private GameObject[] pickerPaletObject;
    [SerializeField] private GameObject[] bonusBalls;
    private bool paletThereIs;
    [SerializeField] private GameObject ballControlObject;

    [SerializeField] public bool pickerMoveCase;

    private int pointBallCount;
    private int checkPointCount;
    private int currentCheckPointIndex;
    
  [SerializeField]  public List<BallAreaTechinical> _BallAreaTechinicals = new List<BallAreaTechinical>();
    
    
    void Start()
    {
        pickerMoveCase = true;
        for (int i = 0; i < _BallAreaTechinicals.Count; i++)
        {
            _BallAreaTechinicals[i].numberText.text = pointBallCount + "/" + _BallAreaTechinicals[i].needBall;
        }
       
        

        checkPointCount = _BallAreaTechinicals.Count-1;

    }

    
    void Update()
    {
        if (pickerMoveCase)
        {
            pickerObject.transform.position += 5f * Time.deltaTime * pickerObject.transform.forward;

            if (Time.timeScale != 0)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pickerObject.transform.position= Vector3.Lerp(pickerObject.transform.position,new Vector3(pickerObject.transform.position.x -.1f,pickerObject.transform.position.y,pickerObject.transform.position.z),.05f);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pickerObject.transform.position= Vector3.Lerp(pickerObject.transform.position,new Vector3(pickerObject.transform.position.x +.1f,pickerObject.transform.position.y,pickerObject.transform.position.z),.05f);
                }
            }
            
            
        }
        
    }

    public void PaletIsActive()
    {
        paletThereIs = true;
        pickerPaletObject[0].SetActive(true);
        pickerPaletObject[1].SetActive(true);
    }

    public void BonusBallAdd(int bonusBallIndex)
    {
        bonusBalls[bonusBallIndex].SetActive(true);
    }

    public void BorderIsComing()
    {
        if (paletThereIs)
        {
            pickerPaletObject[0].SetActive(false);
            pickerPaletObject[1].SetActive(false);
        }
        pickerMoveCase = false;
        
        Invoke("LevelControl",2f);

        Collider[] HitColl = Physics.OverlapBox(ballControlObject.transform.position,
            ballControlObject.transform.localScale / 2, Quaternion.identity);
        int i = 0;
        while (i<HitColl.Length)
        {
            HitColl[i].GetComponent<Rigidbody>().AddForce(new Vector3(0,0,.8f),ForceMode.Impulse);   
            i++;
        }
        

    }

    public void BallCount()
    {
        pointBallCount++;
        _BallAreaTechinicals[currentCheckPointIndex].numberText.text = pointBallCount + "/" + _BallAreaTechinicals[currentCheckPointIndex].needBall;
        
    }

    void LevelControl()
    {
        if (pointBallCount >= _BallAreaTechinicals[currentCheckPointIndex].needBall)
        {
            
            
            _BallAreaTechinicals[currentCheckPointIndex].ballAreaElevator.Play("Elevator");

            foreach (var item in _BallAreaTechinicals[currentCheckPointIndex].balls)
            {
                item.SetActive(false);
            }

            if (currentCheckPointIndex == checkPointCount)
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
            else
            {
                currentCheckPointIndex++; 
                pointBallCount = 0;
                if (paletThereIs)
                {
                    pickerPaletObject[0].SetActive(true);
                    pickerPaletObject[1].SetActive(true);
                }
            }
            
        } 
        else
        {
            Debug.Log("Kaybettin");
        }
    }
   

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(ballControlObject.transform.position,ballControlObject.transform.localScale);
    }*/
}