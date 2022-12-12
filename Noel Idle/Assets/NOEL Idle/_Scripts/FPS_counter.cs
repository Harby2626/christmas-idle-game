using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS_counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI FpsText;
    float pollingTime = 1f, time;
    int frameCount;
    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        Application.targetFrameRate = 300;

        DontDestroyOnLoad(this);
    }
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;
        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " FPS";
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
