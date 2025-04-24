using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCaptura : MonoBehaviour
{
    public Pokedex pokedex; // Asigna el ScriptableObject desde el inspector
    public Transform puntoSpawn;
    public Capturados nivelJ;
    public int id;
    private Criatura criaturaActual;
    private GameObject criaturaInstanciada;
    public static ControladorCaptura singleton;

    private void Start()
    {
        PrepararCaptura(id);
        singleton = this;
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

    public void IntentarCapturar()
    {
        if (criaturaActual == null)
        {
            Debug.LogWarning("No hay criatura para capturar.");
            return;
        }

        bool capturada = criaturaActual.IntentarCaptura(nivelJ.nivelJugador);
        if (capturada)
        {
            Debug.Log($"¡Has capturado a {criaturaActual.nombre}!");
            Capturados.singleton.Capturar(id);
            // Aquí puedes agregar a la pokedex del jugador o eliminar de la escena
        }
        else
        {
            Debug.Log($"{criaturaActual.nombre} se ha escapado...");
        }
    }
}
