using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACUIDexManager : MonoBehaviour
{
    public ACDexManager _acDexManager;
    public GameObject cajaPrefab;
    public Transform contenedor;
    private List<ACUICriaturaCaja> cajasCriaturas = new List<ACUICriaturaCaja>();

    void Start()
    {
        GenerarCajas();
    }

    void GenerarCajas()
    {
        Debug.Log("Cantidad de criaturas en Dex: " + _acDexManager._acCriaturas.acCriaturas.Count);

        foreach (var datos in _acDexManager._acCriaturas.acCriaturas)
        {
            GameObject nuevaCaja = Instantiate(cajaPrefab, contenedor);
            ACUICriaturaCaja uiCaja = nuevaCaja.GetComponent<ACUICriaturaCaja>();
            uiCaja.id = datos.id;//actualizar cajas
            uiCaja.Mostrar(datos);
            cajasCriaturas.Add(uiCaja);

        }
    }
}


