using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization.Settings ;

public class ModeDesciption : MonoBehaviour
{
    private string Description;
    public string IDDescription;
    public TMP_Text Text;
    public Image Image;
    public Sprite Sprite;
    // Start is called before the first frame update
    void OnEnable()
    {
        Description = LocalizationSettings.StringDatabase.GetLocalizedString("LocalizationMainMenu", IDDescription);
    }
    public void ChangeDescription()
    {
        Text.text = Description;
        Image.sprite = Sprite;
    }
}
