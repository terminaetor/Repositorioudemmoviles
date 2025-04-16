using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACClickeable : MonoBehaviour
{
    public GameObject cubo;
    public void OnMouseDown()
    {
        cubo = this.gameObject; 
        Debug.Log("Click");
    }
}
