using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCaptura : MonoBehaviour
{
    public Pokedex pokedex; // Asigna el ScriptableObject desde el inspector
    public Transform puntoSpawn;
    private Criatura criaturaActual;
    private GameObject criaturaInstanciada;
}
