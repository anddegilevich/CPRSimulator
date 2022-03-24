using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoManager : MonoBehaviour
{
    public InformationBlock[] InformationBlocks;
    public Image InformationImage;
    public TMP_Text InformationText;
    private int PageIndex = 0;
    private int StepNum;
    public Button PrevButton;
    public Button NextButton;

    // Start is called before the first frame update
    void Start()
    {
        StepNum = InformationBlocks.Length;
        ShowStep();
    }

    void ShowStep()
    {
        InformationText.text = InformationBlocks[PageIndex].InformationText;
        InformationImage.sprite = InformationBlocks[PageIndex].Sprite;
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
