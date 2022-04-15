using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings;

public class Results : MonoBehaviour
{
    public TMP_Text FreqResultText;
    public TMP_Text DepthResultText;
    public static Results instance;
    private string FreqLocalize;
    private string DepthLocalize;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        FreqLocalize = LocalizationSettings.StringDatabase.GetLocalizedString("BPMTrain", "Frequency");
        DepthLocalize = LocalizationSettings.StringDatabase.GetLocalizedString("BPMTrain", "Depth");
    }

    // Update is called once per frame
    public void ShowResults()
    {
        FreqResultText.text = FreqLocalize + BeatScroller.instance.MeanFreq;
        DepthResultText.text = DepthLocalize + BeatScroller.instance.MeanDepth;
    }
}
