using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionadorCriaturas : MonoBehaviour
{
    public Pokedex pokedex; // Para traer pokedex
    public int idActivo;
    public static SeleccionadorCriaturas singleton;

    private void Awake()
    {
        singleton = this;
    }

    public void Start()
    {
        Debug.Log(pokedex.criaturaActivaID);
    }

    public void SeleccionarCriaturaPorID()
    {
        // Guarda el ID en PlayerPrefs
        PlayerPrefs.SetInt("CriaturaActivaID", idActivo);
        PlayerPrefs.Save();

        // Actualiza la pokedex si ya está cargada
        pokedex.criaturaActivaID = idActivo;

        Debug.Log("¡Criatura seleccionada con ID: " + idActivo + "!");
    }
}
