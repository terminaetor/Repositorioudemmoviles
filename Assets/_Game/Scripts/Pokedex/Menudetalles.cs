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

        Debug.Log(SeleccionadorCriaturas.singleton.idActivo = id);//Aqui asigno el valor del id del pokemon detallado para que el boton funcione

        if (criatura != null && Previsualizador.singleton.creado != null)
        {
            panelDetalles.SetActive(true);
            nombreTexto.text = criatura.nombre;
            descripcionTexto.text = criatura.descripcion;
        }
    }

    public void OcultarDetalles()
    {
        panelDetalles.SetActive(false);
    }
}
