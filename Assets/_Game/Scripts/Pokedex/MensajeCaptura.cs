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
   public Pokedex pokedex;
   public ACUICriaturaCaja caja;
   public GameObject _creado;

    private void Awake()
    {
        singleton = this;
    }

    public void MostrarMensaje(int id)
    {
        Criatura criatura = pokedex.GetCriaturaPorID(id);
       

        mensajeAtrapado.SetActive(true);
        //pokedexUI.SetActive(false);
        _creado = Instantiate(criatura.prefab, transform.position, transform.rotation);
        nombreTexto.text = criatura.nombre;
        //Previsualizador.singleton.Previsualizar(id);
           
            
    }

    public void OcultarMensaje()
    {
        mensajeAtrapado.SetActive(false);
        pokedexUI.SetActive(true);
        ACUIDexManager.singleton.ActualizarCajas();
        Destroy(_creado);
    }
}
