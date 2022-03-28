using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Results : MonoBehaviour
{
    public TMP_Text FreqResultText;
    public TMP_Text DepthResultText;
    public static Results instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void ShowResults()
    {
        FreqResultText.text = "—редн€€ частота: " + BeatScroller.instance.MeanFreq;
        DepthResultText.text = "—редн€€ глубина: " + BeatScroller.instance.MeanDepth;
    }
}
