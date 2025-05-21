using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public ARSimplePlace arPlace;
    public Text tutorialPlace;
    void Update()
    {
        tutorialPlace.gameObject.SetActive(!arPlace.placed);
    }
}
