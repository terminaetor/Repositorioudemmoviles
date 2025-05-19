using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionadorEnemigo : MonoBehaviour
{
    public Pokedex pokedex; // Para traer pokedex
    public int idIndicado;
    public static SeleccionadorEnemigo singleton;

    private void Awake()
    {
        singleton = this;
    }

    public void Start()
    {
        Debug.Log(pokedex.criaturaEnemigaActivaID);
    }

    public void SeleccionarCriaturaPorID()
    {
        // Guarda el ID en PlayerPrefs
        PlayerPrefs.SetInt("CriaturaEnemigaActivaID", idIndicado);
        PlayerPrefs.Save();

        // Actualiza la pokedex si ya está cargada
        pokedex.criaturaEnemigaActivaID = idIndicado;

        Debug.Log("¡Criatura seleccionada con ID: " + idIndicado + "!");
    }
}
