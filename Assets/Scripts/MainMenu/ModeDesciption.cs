using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeDesciption : MonoBehaviour
{
    public string Description;
    public TMP_Text Text;
    public Image Image;
    public Sprite Sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {

    }
    public void ChangeDescription()
    {
        Text.text = Description;
        Image.sprite = Sprite;
    }
}
