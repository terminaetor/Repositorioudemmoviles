using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoGPS : MonoBehaviour
{
    public Vector3 punto;
    public UbicadorPuntosGPSGO ubicador;
    public int id;
    //public Pokedex pokedex;
    [ContextMenu("actualizate")]
    public void ActualizarPosicion()
    {        
        transform.position = ubicador.GetPosUnity(punto.x, punto.z);
    }

    public void Start()
    {
        Criatura criatura = Previsualizador.singleton.pokedex.GetCriaturaPorID(id);
        Debug.Log("Este es la criatura: " + criatura.nombre);
    }


    private void OnDrawGizmosSelected()
    {
        ActualizarPosicion();
    }
}
