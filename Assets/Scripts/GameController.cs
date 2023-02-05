using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI Objective;
    public TextMeshProUGUI Timer;
    public float timeInSeconds = 120f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(decrementCounter),0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ComputerReached(){
        Objective.text = "Done !";
    }
    void decrementCounter(){
        timeInSeconds-=1;
        if(timeInSeconds<0) {
            LostGame();
        }
        Timer.text = Mathf.Floor(timeInSeconds/60f) + ":"+ timeInSeconds%60;
    }
    public void LostGame(){
        Objective.text = "You lost !";
        Time.timeScale = 0;
    }
}
