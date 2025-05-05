using UnityEngine;

public class SVPersonalizacion : MonoBehaviour
{
    public GameObject[] cabezas;
    public GameObject[] cuerpos;
    public GameObject[] cabellos;
    public GameObject[] espadas;

    private int indiceCabeza = 0;
    private int indiceCuerpo = 0;
    private int indiceCabello = 0;
    private int indiceEspada = 0;

    void Start()
    {
        
        indiceCabeza = PlayerPrefs.GetInt("CabezaSeleccionada", 0);
        indiceCuerpo = PlayerPrefs.GetInt("CuerpoSeleccionado", 0);
        indiceCabello = PlayerPrefs.GetInt("CabelloSeleccionado", 0);
        indiceEspada = PlayerPrefs.GetInt("EspadaSeleccionada", 0);

        // MOSTRAR EN CONSOLA QUE SE CARGÓ
        Debug.Log("CARGADO DESDE PlayerPrefs => " +
            "Cabeza: " + indiceCabeza +
            ", Cuerpo: " + indiceCuerpo +
            ", Cabello: " + indiceCabello +
            ", Espada: " + indiceEspada);

        // Activar partes guardadas
        ActivarSoloEste(cabezas, indiceCabeza);
        ActivarSoloEste(cuerpos, indiceCuerpo);
        ActivarSoloEste(cabellos, indiceCabello);
        ActivarSoloEste(espadas, indiceEspada);
    }

    public void CambiarCabeza()
    {
        indiceCabeza = (indiceCabeza + 1) % cabezas.Length;
        ActivarSoloEste(cabezas, indiceCabeza);
        PlayerPrefs.SetInt("CabezaSeleccionada", indiceCabeza);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Cabeza => " + indiceCabeza);
    }

    public void CambiarCuerpo()
    {
        indiceCuerpo = (indiceCuerpo + 1) % cuerpos.Length;
        ActivarSoloEste(cuerpos, indiceCuerpo);
        PlayerPrefs.SetInt("CuerpoSeleccionado", indiceCuerpo);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Cuerpo => " + indiceCuerpo);
    }

    public void CambiarCabello()
    {
        indiceCabello = (indiceCabello + 1) % cabellos.Length;
        ActivarSoloEste(cabellos, indiceCabello);
        PlayerPrefs.SetInt("CabelloSeleccionado", indiceCabello);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Cabello => " + indiceCabello);
    }

    public void CambiarEspada()
    {
        indiceEspada = (indiceEspada + 1) % espadas.Length;
        ActivarSoloEste(espadas, indiceEspada);
        PlayerPrefs.SetInt("EspadaSeleccionada", indiceEspada);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Espada => " + indiceEspada);
    }

    private void ActivarSoloEste(GameObject[] objetos, int indice)
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(i == indice);
        }
    }

    // Para borrar la personalización guardada
    public void BorrarPersonalizacion()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Personalización borrada.");

        indiceCabeza = 0;
        indiceCuerpo = 0;
        indiceCabello = 0;
        indiceEspada = 0;

        ActivarSoloEste(cabezas, indiceCabeza);
        ActivarSoloEste(cuerpos, indiceCuerpo);
        ActivarSoloEste(cabellos, indiceCabello);
        ActivarSoloEste(espadas, indiceEspada);
    }
}