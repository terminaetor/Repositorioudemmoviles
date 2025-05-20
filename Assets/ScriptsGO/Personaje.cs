using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public Vector3 datos;
    public PuntoGPS puntosGPS;

    IEnumerator Start()
    {
        Input.location.Start();

        while (true)
        {
            datos = new Vector3
            (
                Input.location.lastData.latitude,
                Input.location.lastData.longitude,
                Input.location.lastData.altitude
            );

            puntosGPS.punto.x = Input.location.lastData.latitude;
            puntosGPS.punto.z = Mathf.Abs(Input.location.lastData.longitude);

            puntosGPS.ActualizarPosicion();
            yield return new WaitForSeconds(1);
        }
    }

    private void OnDestroy()
    {
        Input.location.Stop();
    }
}
