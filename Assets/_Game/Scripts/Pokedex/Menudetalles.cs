using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menudetalles : MonoBehaviour
{
    public static Menudetalles singleton;

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
            descripcionTexto.text = "Tipo: " + criatura.tipo + "\n\n" + "Nivel: " + criatura.nivel + "\n\n" + "Vida: " + criatura.vida + "\n\n" + "Ataque: " + criatura.ataque + "\n\n" + criatura.nombre + " " + criatura.descripcion;
        }
    }

    public void OcultarDetalles()
    {
        panelDetalles.SetActive(false);
    }
}
