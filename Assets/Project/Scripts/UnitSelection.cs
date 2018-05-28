using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit = new RaycastHit();
    [SerializeField] private LayerMask targetMask;
    public GameObject otherObject;

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
                    
                    GameObject g = hit.transform.gameObject; // Reference the object we hit
                    Player p = g.GetComponent<Player>(); // Player component on referenced object above
                    if(!p.selected)
                    {
                        p.selected = true;
                        otherObject.GetComponent<Player>().selected = false;
                        g = otherObject;
                        Debug.Log("Object hit");
                    }
                }
            }
        }
    }
}
