using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickeable : MonoBehaviour
{
    public int idClick;
    void OnMouseDown()
    {
        SeleccionadorEnemigo.singleton.idIndicado = PuntoGPS.singleton.id;
        Debug.Log("Acabo de tocar a " + SeleccionadorEnemigo.singleton.idIndicado);
        SeleccionadorEnemigo.singleton.SeleccionarCriaturaPorID();

    }
}
