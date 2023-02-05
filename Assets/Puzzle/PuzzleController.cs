using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    private bool rotating;
    public GameObject pipe1,pipe2,pipe3;
    public GameObject Link1,Link2,Link3,Link4,Link5,LinkLast;
    private Color blue,white;
    public Sprite EndFilled,EndEmpty;
    public GameObject End;
    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        blue = new Color32(49,194,252,100);
        white = new Color32(255,255,255,100);
        updateColors();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rotateThis(GameObject pipe)
    {
        StartRotation(pipe);
    }


    private IEnumerator Rotate(Vector3 angles, float duration, GameObject objectToRotate)
    {
        rotating = true;
        Quaternion startRotation = objectToRotate.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            objectToRotate.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }
        objectToRotate.transform.rotation = endRotation;
        rotating = false;
        updateColors();
    }

    public void StartRotation(GameObject pipe)
    {
        if (!rotating)
            StartCoroutine(Rotate(new Vector3(0, 0, 90), 0.5f, pipe));
    }

    bool isCorrect(GameObject pipe){
        float z = pipe.transform.eulerAngles.z;
        if(pipe.name=="Pipe1" && z==270 ) return true;
        if(pipe.name=="Pipe2" && z==90 ) return true;
        if(pipe.name=="Pipe3" && z==0 ) return true;
        return false;
    }

    void updateColors(){
        Link1.GetComponent<Image>().color = blue;
        Link2.GetComponent<Image>().color = isCorrect(pipe3)?blue:white;
        Link3.GetComponent<Image>().color = isCorrect(pipe3)?blue:white;
        Link4.GetComponent<Image>().color = isCorrect(pipe3)&&isCorrect(pipe2)?blue:white;
        Link5.GetComponent<Image>().color = isCorrect(pipe3)&&isCorrect(pipe1)?blue:white;
        LinkLast.GetComponent<Image>().color = isCorrect(pipe3)&&isCorrect(pipe2)&&isCorrect(pipe1)?blue:white;
        End.GetComponent<Image>().sprite = isCorrect(pipe3)&&isCorrect(pipe2)&&isCorrect(pipe1)?EndFilled:EndEmpty;
        if(isCorrect(pipe3)&&isCorrect(pipe2)&&isCorrect(pipe1)) StartCoroutine(CoWin());
    }

    IEnumerator CoWin (){
        yield return new WaitForSeconds(2);
        gc.WinGame();
    }
    /*
    pipe1 0 0 270
    pipe2 0 0 90
    pipe3 0 0 0
    link1 on
    link2 lazem 3
    link3 lazem 3
    link4 lazem 3 w 2
    link5 lazem 3 w 1
    final lazem kol s7i7
    */
}
