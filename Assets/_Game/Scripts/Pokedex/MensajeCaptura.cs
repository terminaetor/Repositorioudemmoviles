using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MensajeCaptura : MonoBehaviour
{
   public static MensajeCaptura singleton; 
   public GameObject mensajeAtrapado, pokedexUI;
   public TextMeshProUGUI nombreTexto;

    private void Awake()
    {
        singleton = this;
    }

    public void MostrarMensaje(int id)
    {
        Criatura criatura = Previsualizador.singleton.pokedex.GetCriaturaPorID(id);
         if (criatura != null)
        {
            
            mensajeAtrapado.SetActive(true);
            pokedexUI.SetActive(false);
            nombreTexto.text = criatura.nombre;
            Previsualizador.singleton.Previsualizar(id);
           
            
        }
    }

    public void OcultarMensaje()
    {
        mensajeAtrapado.SetActive(false);
        pokedexUI.SetActive(true);
    }
}
