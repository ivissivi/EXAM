using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButtons : MonoBehaviour
{
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    [SerializeField] private Text finishedGame;
    [SerializeField] private Text timer;

    [SerializeField] public int limit;

    private int startTime;
    private int score;
    public bool startCountdown = false;

    // Start is called before the first frame update
    void Start()
    {
        finishedGame.text = "";
        startTime = limit;
    }

    IEnumerator countdownClock()
    {
        startCountdown = true;
        yield return new WaitForSeconds(1);
        limit -= 1;
        timer.text = "Time left: " + limit.ToString();
        startCountdown = false;
    }

    // Update is called once per frame
    void Update()
    {   
        score = startTime - limit;
        if (startCountdown == false && limit > 0)
        {
            StartCoroutine(countdownClock());
        }

        if(button1.active && button2.active && button3.active && limit > 0)
        {
                finishedGame.color = Color.green;
                finishedGame.text ="COMPLETED! Your time was " + score + " seconds!";
                timer.text = "";
                StopCoroutine(countdownClock());
        } 

        if(limit <= 0)
        {
            finishedGame.color = Color.red;
            finishedGame.text ="FAILED!";
            StopCoroutine(countdownClock());
        }
    }
}
