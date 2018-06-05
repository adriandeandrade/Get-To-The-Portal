using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit = new RaycastHit();
    [SerializeField] private LayerMask targetMask;

    public GameObject originalObject;
    public GameObject otherObject;
    public GameObject selectedObject;

    public List<GameObject> playerObjects = new List<GameObject>(); // This list includes the clone and original player.

    private void Update()
    {
        SelectPlayer();
    }

    private void SelectPlayer()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, targetMask))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    GameObject objectHit = hit.transform.gameObject; // Reference the object we hit
                    Player p = objectHit.GetComponent<Player>(); // Player component on referenced object above
                    if (!p.selected)
                    {
                        p.selected = true;
                        if (otherObject != null)
                        {
                            otherObject = selectedObject;
                            selectedObject = objectHit;
                            otherObject.GetComponent<Player>().selected = false;
                        }
                        else
                        {
                            Debug.Log("No duplicate detected.");
                        }
                        Debug.Log("Object hit");
                    }
                }
            }
        }
    }
}
