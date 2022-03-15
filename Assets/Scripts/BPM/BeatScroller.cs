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

    public GameObject BeatSprite;
    public TMP_Text ScoreText;

    public static BeatScroller instance;

    private int Score = 0;
    private int ScorePerBeat = 50;
    private int NumBeats = 0;
    private int NumBeatsPassed = 0;

    public GameObject ResultsUI, ScoreUI;
    public TMP_Text ResultText;
    private double MeanFreq;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        BeatScrollerGO = gameObject;
        Speed = Tempo * 8 / 60f;
        time = 1 / (Tempo / 60f);
        ScoreText.text = "Нажмите Пробел, чтобы начать.";
    }

    // Update is called once per frame
    void Update()
    {
        if(!Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Started = true;
                ScoreText.text = "Очки: " + Score;
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
        TimeBetween.Add(0);
        NumBeatsPassed++;
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

        TimeBetween.RemoveAt(TimeBetween.Count - 1);
        for (int i = 0; i < ButtonPressTime.Count - 1; i++)
        {
            TimeBetween[i] = ButtonPressTime[i + 1] - ButtonPressTime[i];
        }
        MeanFreq = Math.Round(60 / TimeBetween.Average(), 2);
        ResultText.text = "Средняя частота: " + MeanFreq;
    }
}
