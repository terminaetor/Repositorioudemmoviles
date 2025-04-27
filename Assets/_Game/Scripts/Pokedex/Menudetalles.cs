using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menudetalles : MonoBehaviour
{
    public static MenuDetalles singleton;

    public GameObject panelDetalles;
    public TextMeshProUGUI nombreTexto;
    public TextMeshProUGUI descripcionTexto;

    private void Awake()
    {
        singleton = this;
    }

    public void MostrarDetalles(int id)
    {
        Criatura criatura = Previsualizador.singleton.pokedex.GetCriaturaPorID(id);

        if (criatura != null)
        {
            panelDetalles.SetActive(true);
            nombreTexto.text = criatura.nombre;
            descripcionTexto.text = "Descripción de prueba del Pokémon " + criatura.nombre;

        }
    }

    public void OcultarDetalles()
    {
        panelDetalles.SetActive(false);
    }
}
