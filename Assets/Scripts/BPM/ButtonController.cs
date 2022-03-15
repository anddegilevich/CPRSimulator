using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer SR;
    public KeyCode KeyToPress;
    public Sprite DefaultImage;
    public Sprite PressedImage;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            SR.sprite = PressedImage;
        }

        if (Input.GetKeyUp(KeyToPress))
        {
            SR.sprite = DefaultImage;
        }
    }
}
