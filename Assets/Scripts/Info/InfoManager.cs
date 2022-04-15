using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using TMPro;

public class InfoManager : MonoBehaviour
{
    //public InformationBlock[] InformationBlocks;
    public Sprite[] StepSprites;
    public Image InformationImage;
    public TMP_Text InformationText;
    private int PageIndex = 0;
    private int StepNum = 12;
    public Button PrevButton;
    public Button NextButton;

    // Start is called before the first frame update
    void OnEnable()
    {
        ShowStep();
    }

    void ShowStep()
    {
        //InformationText.text = InformationBlocks[PageIndex].InformationText;
        InformationText.text = LocalizationSettings.StringDatabase.GetLocalizedString("LocalizationMainMenu", $@"Algorithm_Step{PageIndex+1}");
        InformationImage.sprite = StepSprites[PageIndex];
    }

    public void NextStep()
    {
        PageIndex++;
        ShowStep();
        PrevButton.interactable = true;
        if (PageIndex == StepNum-1)
        {
            NextButton.interactable = false;
        }
        
    }

    public void PrevStep()
    {
        PageIndex--;
        ShowStep();
        NextButton.interactable = true;
        if (PageIndex == 0)
        {
            PrevButton.interactable = false;
        }
    }

}
