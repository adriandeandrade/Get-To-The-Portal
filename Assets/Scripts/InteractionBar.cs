using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionBar : MonoBehaviour
{
    public Image loadingBar;
    float currentValue;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentValue < 0)
        {
            currentValue = 0;
        }

        if (!Input.GetKey(KeyCode.E))
        {
            currentValue -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E) && currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
        }

        loadingBar.fillAmount = currentValue / 100;
    }
}
