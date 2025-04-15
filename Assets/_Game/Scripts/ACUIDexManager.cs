using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACUIDexManager : MonoBehaviour
{
    public ACCriaturas _acUICriaturas;
    public ACDexManager _acDexManager;
    public GameObject cajaPrefab;
    public Transform contenedor;
    private List<ACUICriaturaCaja> cajasCriaturas = new List<ACUICriaturaCaja>();

    void GenerarCajas()
    {
        foreach (var datos in _acDexManager._acCriaturas.acCriaturas)
        {
            GameObject nuevaCaja = Instantiate(cajaPrefab, contenedor);
            ACUICriaturaCaja uiCaja = nuevaCaja.GetComponent<ACUICriaturaCaja>();
            uiCaja.id = datos.id;
            uiCaja.Mostrar(datos);
            cajasCriaturas.Add(uiCaja);

        }
    }
}


