using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class BeatScroller : MonoBehaviour
{
    private GameObject BeatScrollerGO;
    private GameObject Beat;

    public float Tempo;
    private float Speed;
    private bool Started;
    private float time;
    private float timeLeft = 0f;
    public List<float> ButtonPressTime;
    public List<float> TimeBetween;
    public List<int> ButtonPressClass;
    public List<float> Depth;

    public GameObject BeatSprite;
    public TMP_Text ScoreText;

    public static BeatScroller instance;

    private int Score = 0;
    private int ScorePerBeat = 50;
    private int NumBeats = 0;
    private int NumBeatsPassed = 0;

    public GameObject ResultsUI, ScoreUI;
    public TMP_Text FreqResultText;
    public TMP_Text DepthResultText;
    private double MeanFreq;
    private double MeanDepth;

    public TMP_Text BPMLevelText;
    public TMP_Text DepthLevelText;

    void Start()
    {
        instance = this;
        BeatScrollerGO = gameObject;
        Speed = Tempo * 8 / 60f;
        time = 1 / (Tempo / 60f);
        ScoreText.text = "Нажмите пробел, чтобы начать.";
        BPMLevelText.enabled = false;
        DepthLevelText.enabled = false;
    }
    void Update()
    {
        if(!Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Started = true;
                ScoreText.text = "Очки: " + Score;
                BPMLevelText.enabled = true;
                DepthLevelText.enabled = true;
            }
        }
        else
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
        ScoreText.text = "Очки: " + Score;
        ButtonPressTime.Add(NumBeats * time - timeLeft);
        ButtonPressClass.Add(Multiplier);
        if (NumBeatsPassed > 0)
        { 
            TimeBetween.Add(ButtonPressTime[NumBeatsPassed] - ButtonPressTime[NumBeatsPassed-1]);
            BPMLevelText.text = "BPM: " + Math.Round(60 / TimeBetween[NumBeatsPassed-1], 2); ;
        }
        NumBeatsPassed++;
    }

    public void DepthScore(float CurrentDepth)
    {
        DepthLevelText.text = "Глубина: " + (Math.Round(CurrentDepth, 2));
        Depth.Add(CurrentDepth);
    }

    public void BeatMiss()
    {
        NumBeatsPassed++;
    }

    void ShowResults()
    {
        ScoreUI.SetActive(false);
        ResultsUI.SetActive(true);
        gameObject.SetActive(false);
        MeanFreq = Math.Round(60 / TimeBetween.Average(), 2);
        MeanDepth = Math.Round(Depth.Average(), 2);
        FreqResultText.text = "Средняя частота: " + MeanFreq;
        DepthResultText.text = "Средняя глубина: " + MeanDepth;
    }
}
