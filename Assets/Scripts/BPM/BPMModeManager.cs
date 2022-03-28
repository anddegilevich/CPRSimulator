using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BPMModeManager : MonoBehaviour
{
    public GameObject CalibrationUI, ResultsUI, ScoreUI;
    public static BPMModeManager instance;
    public GameObject Button, BeatHolder;

    private void Start()
    {
        instance = this;
    }

    public void StartSimulation()
    {
        ScoreUI.SetActive(true);
        Button.SetActive(true);
        CalibrationUI.SetActive(false);
        BeatScroller.instance.Started = true;
    }

    public void ShowResults()
    {
        ResultsUI.SetActive(true);
        Button.SetActive(false);
        //Results.instance.ShowResults();
        ScoreUI.SetActive(false);
    }
}
