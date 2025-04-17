using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Previsualizador : MonoBehaviour
{
    public GameObject creado;
    public Pokedex pokedex;
    public static Previsualizador singleton;

    private void Awake()
    {
        singleton = this;
    }
    public void Previsualizar(int id)
    {
        Limpiar();
        Criatura criatura = pokedex.GetCriaturaPorID(id);
        if (criatura != null)
        {
            creado = Instantiate(criatura.prefab, transform.position, transform.rotation);
            Debug.Log($"[{criatura.nombre}] Nivel: {criatura.nivel}, Tipo: {criatura.tipo}, Vida: {criatura.vida}, Daño: {criatura.ataque}");
        }

    }

    public void Limpiar()
    {
        if (creado != null)
        {
            Destroy(creado);
        }
    }
}
