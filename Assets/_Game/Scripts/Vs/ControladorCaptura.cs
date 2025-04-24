using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCaptura : MonoBehaviour
{
    public Pokedex pokedex; // Asigna el ScriptableObject desde el inspector
    public Transform puntoSpawn;
    public int id;
    private Criatura criaturaActual;
    private GameObject criaturaInstanciada;

    private void Start()
    {
        PrepararCaptura(id);
    }

    public void PrepararCaptura(int idCriatura)
    {
        // Carga la criatura por ID desde la pokedex
        criaturaActual = pokedex.GetCriaturaPorID(idCriatura);
        if (criaturaActual == null)
        {
            Debug.LogError("No se encontró criatura con ese ID");
            return;
        }

        // Instancia el prefab en la escena
        criaturaInstanciada = Instantiate(criaturaActual.prefab, puntoSpawn.position, Quaternion.identity);
    }
}
