using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Previsualizador : MonoBehaviour
{
    public GameObject creado;
    public GameObject btnInformacion;
    public Pokedex pokedex;
    public TextMeshProUGUI nombreCriaturaTexto;
    public static Previsualizador singleton;
    private Button boton;
    private int idSeleccionado;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        boton = btnInformacion.GetComponent<Button>();
    }
    public void Previsualizar(int id)
    {
        Limpiar();
        Criatura criatura = pokedex.GetCriaturaPorID(id);
        if (criatura != null)
        {
            creado = Instantiate(criatura.prefab, transform.position, transform.rotation);
            nombreCriaturaTexto.text = criatura.nombre;

            btnInformacion.SetActive(true);
            idSeleccionado = id;
            boton.onClick.AddListener(() => MenuDetalles.singleton.MostrarDetalles(idSeleccionado));
            
            
        }

    }

    public void Limpiar()
    {
        if (creado != null)
        {
            nombreCriaturaTexto.text = "Este Udemon esta bloqueado";
            Destroy(creado);
        }
    }
}
