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

    // Start is called before the first frame update
    void Start()
    {
        finishedGame.text = "yes";
    }

    // Update is called once per frame
    void Update()
    {
        if(button1 && button2 && button3)
        {
            finishedGame.text ="yes";
        }
    }
}
