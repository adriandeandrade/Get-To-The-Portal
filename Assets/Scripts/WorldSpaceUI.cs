using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceUI : MonoBehaviour
{
    public Text teleportInstructionText;

    Vector3 offset = new Vector3(0, 1, 0);

    public void SetTextContentAndPosition(string textToDisplay, Vector3 position, GameObject collisionObject)
    {
        if (collisionObject.gameObject.tag == "Teleporter")
        {
            teleportInstructionText.gameObject.SetActive(true);
            teleportInstructionText.text = textToDisplay;
            teleportInstructionText.rectTransform.position = position + offset;
        }
    }

    public void FixedUpdate()
    {
        teleportInstructionText.rectTransform.LookAt(Camera.main.transform);
        teleportInstructionText.rectTransform.Rotate(Vector3.up - new Vector3(0, 180, 0));
    }
}
