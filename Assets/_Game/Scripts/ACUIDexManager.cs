using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACUIDexManager : MonoBehaviour
{
    public ACDexManager _acDexManager;// Objeto que instancia a ACDexManager para usar la lista donde estan los datos de las criaturas
    public GameObject cajaPrefab; //Variable para añadir caja base donde va a estar los datos de criatura
    public Transform contenedor;// transform donde se van a instanciar en la escena las cajas
    private List<ACUICriaturaCaja> cajasCriaturas = new List<ACUICriaturaCaja>();//Lista donde se añaden todas las cajas

    void Start()
    {
        GenerarCajas();
    }

    void GenerarCajas()//Funcion que instancia, la caja y la informacion de cada criatura
    {
        Debug.Log("Cantidad de criaturas en Dex: " + _acDexManager._acCriaturas.acCriaturas.Count);

        foreach (var datos in _acDexManager._acCriaturas.acCriaturas)
        {
            GameObject nuevaCaja = Instantiate(cajaPrefab, contenedor);//Aqui se instancia cada caja en la pokedex
            ACUICriaturaCaja uiCaja = nuevaCaja.GetComponent<ACUICriaturaCaja>();//Obtiene el script atachado de cada caja
            uiCaja.id = datos.id;
            uiCaja.Mostrar(datos);//actualizar informacion cajas
            cajasCriaturas.Add(uiCaja);
        }
    }
}


