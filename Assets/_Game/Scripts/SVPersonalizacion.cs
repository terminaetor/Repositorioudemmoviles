using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVPersonalizacion : MonoBehaviour
{
    public GameObject[] cabezas;
    public GameObject[] cuerpos;
    public GameObject[] cabellos;
    public GameObject[] espadas;

    int cabezaActual = 0;
    int cuerpoActual = 0;
    int cabelloActual = 0;
    int espadaActual = 0;

    void Start()
    {
        ActivarParte(cabezas, cabezaActual);
        ActivarParte(cuerpos, cuerpoActual);
        ActivarParte(cabellos, cabelloActual);
        ActivarParte(espadas, espadaActual);
    }

    void ActivarParte(GameObject[] partes, int indiceActivo)
    {
        for (int i = 0; i < partes.Length; i++)
        {
            partes[i].SetActive(i == indiceActivo);
        }
    }

    public void CambiarCabeza()
    {
        cabezaActual = (cabezaActual + 1) % cabezas.Length;
        ActivarParte(cabezas, cabezaActual);
    }

    public void CambiarCuerpo()
    {
        cuerpoActual = (cuerpoActual + 1) % cuerpos.Length;
        ActivarParte(cuerpos, cuerpoActual);
    }

    public void CambiarCabello()
    {
        cabelloActual = (cabelloActual + 1) % cabellos.Length;
        ActivarParte(cabellos, cabelloActual);
    }

    public void CambiarEspada()
    {
        espadaActual = (espadaActual + 1) % espadas.Length;
        ActivarParte(espadas, espadaActual);
    }
}