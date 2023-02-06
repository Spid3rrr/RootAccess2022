using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI Objective;
    public TextMeshProUGUI Timer,Timer2;
    public GameObject winPanel,losePanel,puzzlePanel;
    public AudioClip deathSound;
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
        StartCoroutine(CoPuzzle());
    }
    void decrementCounter(){
        timeInSeconds-=1;
        if(timeInSeconds<0) {
            LostGame();
        }
        Timer.text = Mathf.Floor(timeInSeconds/60f) + ":"+ timeInSeconds%60;
        if(timeInSeconds<60) Timer.color = new Color(255,0,0,100);
        Timer2.text = Mathf.Floor(timeInSeconds/60f) + ":"+ timeInSeconds%60;
        if(timeInSeconds<60) Timer2.color = new Color(255,0,0,100);
    }
    public void LostGame(){
        gameObject.GetComponent<AudioSource>().clip = deathSound;
        gameObject.GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        StartCoroutine(CoLost());
    }

    public void WinGame(){
        puzzlePanel.SetActive(false);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator CoPuzzle (){
        yield return new WaitForSecondsRealtime(2);
        puzzlePanel.SetActive(true);
    }
    IEnumerator CoLost (){
        yield return new WaitForSecondsRealtime(4);
        puzzlePanel.SetActive(false);
        losePanel.SetActive(true);
    }

    public void Reset(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
