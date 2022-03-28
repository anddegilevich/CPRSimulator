using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calibration : MonoBehaviour
{

    public TMP_Text CalibrateText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BPMModeManager.instance.StartSimulation();
        }
    }
}
