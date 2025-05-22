using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickeable : MonoBehaviour
{
    public CriaturaGPS criaturaGPS; // Asignar desde el Inspector

    void OnMouseDown()
    {
        SeleccionadorEnemigo.singleton.idIndicado = criaturaGPS.id;
        Debug.Log("Acabo de tocar a " + SeleccionadorEnemigo.singleton.idIndicado);
        SeleccionadorEnemigo.singleton.SeleccionarCriaturaPorID();
        NavigationManager.singleton.GoToCombate();
    }
}
