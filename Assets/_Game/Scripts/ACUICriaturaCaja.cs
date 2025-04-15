using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACUICriaturaCaja : MonoBehaviour //script que va en la caja de cada criatura de la pokedex
{
    public int id;
    public TextMeshProUGUI nombreTexto;

    public void Mostrar(ACDatos datos)
    {
        nombreTexto.text = datos.atrapado ? datos.nombre : datos.id.ToString();//muestra informacion dependiendo si atrapado o falso es verdadero
    }
}
