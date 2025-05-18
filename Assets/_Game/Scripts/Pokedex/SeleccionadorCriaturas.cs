using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionadorCriaturas : MonoBehaviour
{
    public Pokedex pokedex; // Para traer pokedex

    public void Start()
    {
        Debug.Log(pokedex.criaturaActivaID);
    }

    public void SeleccionarCriaturaPorID(int id)
    {
        // Guarda el ID en PlayerPrefs
        PlayerPrefs.SetInt("CriaturaActivaID", id);
        PlayerPrefs.Save();

        // Actualiza la pokedex si ya está cargada
        pokedex.criaturaActivaID = id;

        Debug.Log("¡Criatura seleccionada con ID: " + id + "!");
    }
}
