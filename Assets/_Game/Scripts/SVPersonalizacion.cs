using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVPersonalizacion : MonoBehaviour
{
    public Transform headSlot;
    public Transform bodySlot;
    public Transform hairSlot;
    public Transform accessoriesSlot;

    public GameObject[] headOptions;
    public GameObject[] bodyOptions;
    public GameObject[] hairOptions;
    public GameObject[] accessoriesOptions;

    public void EquipHead(int index)
    {
        ClearSlot(headSlot);
        Instantiate(headOptions[index], headSlot);
    }

    public void EquipBody(int index)
    {
        ClearSlot(bodySlot);
        Instantiate(bodyOptions[index], bodySlot);
    }

    public void EquipHair(int index)
    {
        ClearSlot(hairSlot);
        Instantiate(hairOptions[index], hairSlot);
    }

    public void EquipAccessories(int index)
    {
        ClearSlot(accessoriesSlot);
        Instantiate(accessoriesOptions[index], accessoriesSlot);
    }

    private void ClearSlot(Transform slot)
    {
        foreach (Transform child in slot)
        {
            Destroy(child.gameObject);
        }
    }
}
