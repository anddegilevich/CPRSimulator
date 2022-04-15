using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization.Settings;

public class LoadingScreen : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;
    public int SceneID;
    public TMP_Text TipText;
    private System.Random Rand = new System.Random();
    private int TipIndex;
    private int NumTips = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowTip());
        StartCoroutine(LoadSceneCor());
    }

    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(MainMenu.ID);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            LoadBar.fillAmount = progress;
            yield return 0;
        }
    }

    private IEnumerator ShowTip()
    {
        while (true)
        {
            TipIndex = Rand.Next(NumTips)+1;
            TipText.text = LocalizationSettings.StringDatabase.GetLocalizedString("LoadingScreen", $@"Tip{TipIndex}");
            yield return new WaitForSeconds(3f);
        }
    }
}
