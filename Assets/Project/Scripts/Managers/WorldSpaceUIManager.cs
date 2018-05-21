using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceUIManager : MonoBehaviour
{
    public Text teleportInstructionText;
    public GameObject interactionBar;

    Vector3 offset = new Vector3(0, 1, 0);

    public void SetTextContentAndPosition(string textToDisplay, Vector3 position, GameObject collisionObject)
    {
        if (collisionObject.gameObject.tag == "Player")
        {
            teleportInstructionText.gameObject.SetActive(true); // Activate the instruction text
            teleportInstructionText.text = textToDisplay; // Set set the text to display (inputed when we call the method)
            teleportInstructionText.rectTransform.position = position + offset; // Set the position of the text
        } 
    }

    // Disable the instruction text
    public void DisableUI()
    {
        teleportInstructionText.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        teleportInstructionText.rectTransform.LookAt(Camera.main.transform);
        teleportInstructionText.rectTransform.Rotate(Vector3.up - new Vector3(0, 180, 0));
    }
}
