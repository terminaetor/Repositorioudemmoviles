using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACUICriaturaCaja : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI nombreTexto;

    public void Mostrar(ACDatos datos)
    {
        nombreTexto.text = datos.atrapado ? datos.nombre : "???";
    }
}
