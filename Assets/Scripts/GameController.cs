using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int point;

    public int totalTime = 10;
    private bool isStart, isPanelAppearing;
    private int time;
    private int tempTime;
    public Text txtScore, txtTime, txtFinalScore, txtStartPanel;

    public Button btnRestart;

    public GameObject panel, startPanel;
    private string messages = "Ready";
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        point = 0;
        tempTime += (int)Time.time;
        time = 0;
        isPanelAppearing = true;
        Time.timeScale = 0;
        panel.SetActive(false);
        startPanel.SetActive(true);
        txtStartPanel.text = messages;
        btnRestart.onClick.AddListener(ReStart);
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
        GameProcess();
    }

    void StartGame()
    {
        if (Input.GetMouseButton(0) && isStart == false)
        {
            isStart = true;
        }
    }

    void GameProcess()
    {

        if(isStart && isPanelAppearing){
            isPanelAppearing = false;
            startPanel.SetActive(false);
            Time.timeScale = 1;
            tempTime = (int)Time.time;
        }

        if (isStart && !isPanelAppearing)
        {
            if (Time.timeScale == 0) Time.timeScale = 1;
            time = (int)(Time.time - tempTime);
            int remaining = totalTime - time;
            txtTime.text = "Time: " + remaining.ToString();
            if (remaining <= 0)
            {
                GameOver();
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        txtFinalScore.text = "Your Point\n " + point.ToString();
    }

    void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickObj(int type)
    {
        switch (type)
        {
            case 0:
                point += 1;
                break;
            case 1:
                point += 2;
                break;
            default:
                break;
        }
        txtScore.text = "Score: " + point.ToString();
    }
}
