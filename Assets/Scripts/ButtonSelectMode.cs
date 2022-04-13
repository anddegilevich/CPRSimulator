using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelectMode : MonoBehaviour
{
    public int ModeID;
    // Start is called before the first frame update

    public void ModeSelect()
    {
        MainMenu.ID = ModeID;
        SceneManager.LoadScene(1);
    }
}
