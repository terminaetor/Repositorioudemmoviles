using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickeable : MonoBehaviour
{
    public PuntoGPS puntoGPS; // Asignar desde el Inspector

    void OnMouseDown()
    {
        SeleccionadorEnemigo.singleton.idIndicado = puntoGPS.id;
        Debug.Log("Acabo de tocar a " + SeleccionadorEnemigo.singleton.idIndicado);
        SeleccionadorEnemigo.singleton.SeleccionarCriaturaPorID();
        NavigationManager.singleton.GoToCombate();
    }
}
