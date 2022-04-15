using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using UnityEngine.Localization.Settings;

public class BeatScroller : MonoBehaviour
{
    private GameObject BeatScrollerGO;
    private GameObject Beat;

    public float Tempo;
    private float Speed;
    public bool Started = false;
    private float time;
    private float timeLeft = 0f;
    public List<float> ButtonPressTime;
    public List<float> TimeBetween;
    public List<int> ButtonPressClass;
    public List<float> Depth;

    public GameObject BeatSprite;
    public TMP_Text ScoreText;
    private string ScoreLocalize;

    public static BeatScroller instance;

    private int Score = 0;
    private int ScorePerBeat = 50;
    private int NumBeats = 0;
    private int NumBeatsPassed = 0;
    private int NumBeatsPressed = 0;

    public GameObject ResultsUI, ScoreUI;
    public TMP_Text FreqResultText;
    public TMP_Text DepthResultText;
    public double MeanFreq;
    public double MeanDepth;

    public TMP_Text BPMLevelText;
    public TMP_Text DepthLevelText;

    public GameObject BPMPointer;
    public GameObject DepthPointer;
    private double IdealDepth = 5;
    private double BPMHigh;
    private double BPMLow;
    private double DepthHigh;
    private double DepthLow;

    void Start()
    {
        instance = this;
        BeatScrollerGO = gameObject;
        Speed = Tempo * 8 / 60f;
        time = 1 / (Tempo / 60f);
        ScoreLocalize = LocalizationSettings.StringDatabase.GetLocalizedString("BPMTrain", "Score");
        ScoreText.text = ScoreLocalize + Score;
        BPMHigh = Tempo + 30;
        BPMLow = Tempo - 30;
        DepthHigh = IdealDepth + 3;
        DepthLow = IdealDepth - 3;
}
    void Update()
    {
        
        if (Started)
        {
            
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                if (NumBeats < 30)
                {
                    SpawnBeat();
                    NumBeats++;
                }
                else if (NumBeatsPassed < 30)
                {
                    timeLeft = time;
                    NumBeats++;
                }
                else
                {
                    ShowResults();
                }
            }
            transform.position -= new Vector3(Speed * Time.deltaTime, 0f, 0f);
        }
    }

    void SpawnBeat()
    {
        Beat = Instantiate(BeatSprite, new Vector3(22, 0, 0), transform.rotation);
        Beat.transform.SetParent(BeatScrollerGO.transform);
        timeLeft = time;
    }

    public void BeatHit(int Multiplier)
    {
        Score += ScorePerBeat * Multiplier;
        ScoreText.text = ScoreLocalize + Score;
        ButtonPressTime.Add(NumBeats * time - timeLeft);
        ButtonPressClass.Add(Multiplier);
        if (NumBeatsPressed > 0)
        {
            TimeBetween.Add(ButtonPressTime[NumBeatsPressed] - ButtonPressTime[NumBeatsPressed - 1]);
            double CurrentBPM = Math.Round(60 / TimeBetween[NumBeatsPressed - 1], 0);
            BPMLevelText.text = CurrentBPM.ToString();
            double PercentBPM = (CurrentBPM - BPMLow)/(BPMHigh - BPMLow);
            BPMPointer.GetComponent<Pointer>().ChangeDestination(PercentBPM);
        }
        else 
            BPMLevelText.text = "110";
        NumBeatsPressed++;
        NumBeatsPassed++;
    }

    public void DepthScore(float CurrentDepth)
    {
        DepthLevelText.text = Math.Round(CurrentDepth, 2).ToString();
        Depth.Add(CurrentDepth);
        double PercentDepth = (CurrentDepth - DepthLow) / (DepthHigh - DepthLow);
        DepthPointer.GetComponent<Pointer>().ChangeDestination(PercentDepth);

    }

    public void BeatMiss()
    {
        NumBeatsPassed++;
    }

    void ShowResults()
    {
        MeanFreq = Math.Round(60 / TimeBetween.Average(), 2);
        MeanDepth = Math.Round(Depth.Average(), 2);
        BPMModeManager.instance.ShowResults();
    }
}
