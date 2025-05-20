using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoGPS : MonoBehaviour
{
    public Vector3 punto;
    public UbicadorPuntosGPSGO ubicador;
    public int id;
    public static PuntoGPS singleton;
    //public Pokedex pokedex;
    [ContextMenu("actualizate")]
    public void ActualizarPosicion()
    {        
        transform.position = ubicador.GetPosUnity(punto.x, punto.z);
    }

    public void Awake()
    {
        singleton = this;
    }

    public void Start()
    {
        InstanciarPokemon(id);
    }

    public void InstanciarPokemon(int id)
    {
        print(Previsualizador.singleton);
        print(Previsualizador.singleton.pokedex);
        Criatura criatura = Previsualizador.singleton.pokedex.GetCriaturaPorID(id);//oBTENER ID POKEMON
        print(id + " --------------------------------");
        GameObject udemon = Instantiate(criatura.prefab, transform.position, transform.rotation);//Instanciar pokemon
        udemon.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);//mANIPULAR SU ESCALA
    }


    private void OnDrawGizmosSelected()
    {
        ActualizarPosicion();
    }
}
