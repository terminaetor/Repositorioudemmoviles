using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ACUIDexManager : MonoBehaviour
{
    //public ACDexManager _acDexManager;// Objeto que instancia a ACDexManager para usar la lista donde estan los datos de las criaturas
    public Pokedex pokedex;
    public GameObject cajaPrefab; //Variable para añadir caja base donde va a estar los datos de criatura
    public Transform contenedor;// transform donde se van a instanciar en la escena las cajas
    private List<ACUICriaturaCaja> cajasCriaturas = new List<ACUICriaturaCaja>();//Lista donde se añaden todas las cajas
    public static ACUIDexManager singleton;
    private int cantidadTotal;
    public TextMeshProUGUI nTotal;
    public TextMeshProUGUI nAtrapados;
    

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        GenerarCajas();
        cantidadTotal = pokedex.criaturas.Count;
        nTotal.text = cantidadTotal.ToString();
    }

    void GenerarCajas()//Funcion que instancia, la caja y la informacion de cada criatura
    {
        //Debug.Log("Cantidad de criaturas en Dex: " + _acDexManager._acCriaturas.acCriaturas.Count);

        foreach (Criatura criatura in pokedex.criaturas)
        {
            GameObject nuevaCaja = Instantiate(cajaPrefab, contenedor);//Aqui se instancia cada caja en la pokedex
            ACUICriaturaCaja uiCaja = nuevaCaja.GetComponent<ACUICriaturaCaja>();//Obtiene el script atachado de cada caja
            uiCaja.Mostrar(criatura);//actualizar informacion cajas
            cajasCriaturas.Add(uiCaja);
        }
    }

    public void ActualizarCajas()
    {
        foreach (ACUICriaturaCaja criaturaCaja in cajasCriaturas)
        {
            ACUICriaturaCaja uiCaja = criaturaCaja.GetComponent<ACUICriaturaCaja>();
            uiCaja.Mostrar(criaturaCaja.criatura);
            Capturados.singleton.ActualizarNivelJugador();
        }
    }
}


