using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCheck : MonoBehaviour
{
    public GameObject INVENTORY;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Controls.INVENTORY_TOGGLE))
        {
            INVENTORY.SetActive(!INVENTORY.activeSelf);
        }
    }
}
