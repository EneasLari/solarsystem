using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public GameObject MainMenuPanel;
    public GameObject InGamePanel;
    public Text ScoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "0";
    }

    public void StartPlaying() {
        MainMenuPanel.SetActive(false);
        Camera.main.GetComponent<flycamera>().enabled = true;
        Camera.main.GetComponent<shootmeteor>().enabled = true;
        InGamePanel.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
