using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionBar : MonoBehaviour
{
    public Image loadingBar;
    [Range(0, 100)]
    [SerializeField]
    public float currentValue;
    public float speed;

    //[HideInInspector]
    public bool isComplete = false;

    void Start()
    {
        loadingBar.fillAmount = 0; // Set fillAmount to 0 when level starts.
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }

    void UpdateProgressBar()
    {
        if (currentValue < 100) isComplete = false; // If the current value goes below 100, toggle isComplete

        if (currentValue >= 99) // If the current value goes above 99, cap is back to 100 to keep it from going over
        {
            currentValue = 100;
            isComplete = true; // Set isComplete to true to teleport.
        }

        if (!Input.GetKey(KeyCode.E) && currentValue >= 0.01) currentValue -= speed * Time.deltaTime; // If were not pressing the E key, decrement the current value

        if (Input.GetKey(KeyCode.E) && currentValue < 100f) currentValue += speed * Time.deltaTime; // If were pressing the E key, incrementt he current value

        loadingBar.fillAmount = currentValue / 100f; // Set the fill amount to whatever the current value is.
    }
}
