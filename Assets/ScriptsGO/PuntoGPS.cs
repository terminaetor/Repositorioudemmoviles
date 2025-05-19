using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoGPS : MonoBehaviour
{
    public Vector3 punto;
    public UbicadorPuntosGPSGO ubicador;
    [ContextMenu("actualizate")]
    public void ActualizarPosicion()
    {        
        transform.position = ubicador.GetPosUnity(punto.x, punto.z);
    }

    private void OnDrawGizmosSelected()
    {
        ActualizarPosicion();
    }
}
