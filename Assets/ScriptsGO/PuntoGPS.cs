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
        Criatura criatura = Previsualizador.singleton.pokedex.GetCriaturaPorID(id);//oBTENER ID POKEMON
        Debug.Log("Este es la criatura: " + criatura.nombre);
        GameObject udemon = Instantiate(criatura.prefab, transform.position, transform.rotation);//Instanciar pokemon
        udemon.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);//mANIPULAR SU ESCALA
    }


    private void OnDrawGizmosSelected()
    {
        ActualizarPosicion();
    }
}
