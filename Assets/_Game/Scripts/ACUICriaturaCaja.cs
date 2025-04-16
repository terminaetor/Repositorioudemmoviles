using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ACUICriaturaCaja : MonoBehaviour //script que va en la caja de cada criatura de la pokedex
{
    public TextMeshProUGUI nombreTexto;
    public Criatura criatura;
    public Image imgCriatura;
    public void Mostrar(Criatura datos)
    {
        //nombreTexto.text = datos.atrapado ? datos.nombre : datos.id.ToString();//muestra informacion dependiendo si atrapado o falso es verdadero
        criatura = datos;
        imgCriatura.sprite = criatura.img;
        if (Capturados.singleton.VerificarCaptura(criatura.id))
        {
            imgCriatura.color = Color.white;
        }
        else
        {
            imgCriatura.color = Color.black;
        }
        nombreTexto.text = criatura.nombre;
    }

    public void Previsualizar()
    {
        if (!Capturados.singleton.VerificarCaptura(criatura.id))
        {
            Previsualizador.singleton.Limpiar();
            return;
        }
        Previsualizador.singleton.Previsualizar(criatura.id);
    }
}
