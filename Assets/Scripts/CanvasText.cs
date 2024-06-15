using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    [SerializeField]
    Text txttime;
    [SerializeField]
    int totalTime = 120;
    float time;
    bool isPaused = false;
    [SerializeField]
    Text txtPaused;

    // Start is called before the first frame update
    void Start()
    {
        txttime.text = "Time: " + totalTime.ToString();
        time = 0;
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            totalTime -= 1;
            txttime.text = "Time: " + totalTime.ToString();
            time = 0;

        }
        if (time == 0)
        {
            Time.timeScale = 0;
        }
    }
    public void PausedGaame()
    {
        Debug.Log("Da Bam Nut");
        if (!isPaused)
        {
            //biến thành play game
            isPaused = false;
            txtPaused.text = "Paused";
            Time.timeScale = 1;
        }
        else
        {
            //biến thành pause game
            isPaused = true;
            txtPaused.text = "Replay";
            Time.timeScale = 0;
        }
    }
}