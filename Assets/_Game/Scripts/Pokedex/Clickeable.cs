using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickeable : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("¡Haz hecho clic sobre " + gameObject.name + "!");
    }
}
