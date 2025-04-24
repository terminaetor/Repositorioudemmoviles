using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCaptura : MonoBehaviour
{
    public Pokedex pokedex; // Asigna el ScriptableObject desde el inspector
    public Transform puntoSpawn; //punto donde va aparecer la criatura
    public Capturados nivelJ; // para traer el nivel del jugador
    public int id;
    private Criatura criaturaActual;
    private GameObject criaturaInstanciada;
    public static ControladorCaptura singleton;

    private void Start()
    {
        PrepararCaptura(id);
        singleton = this;
    }

    public void PrepararCaptura(int idCriatura)// llama criatura desde la pokedex y la instancia
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

    public void IntentarCapturar()//funcion que tiene toda la logica de captura
    {
        if (criaturaActual == null)
        {
            Debug.LogWarning("No hay criatura para capturar.");
            return;
        }

        bool capturada = criaturaActual.IntentarCaptura(nivelJ.nivelJugador);// se llama la funcion intentarcaptura para ver si retorna true o false
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
