using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicadorPuntosGPSGO : MonoBehaviour
{
    public Vector3 referencia;
    public float escala;

    public Vector3 GetPosUnity(float lat, float lon)
    {
        Vector3 gpsPos = new Vector3(lat, 0, lon);
        Vector3 diferencia = gpsPos - referencia; /* punto final menos punto inicial*/
        diferencia *= escala;
        return transform.position + diferencia;
    }

}
