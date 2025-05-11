using UnityEngine;

public class Personalizacion : MonoBehaviour
{
    public GameObject[] cabellos;
    public GameObject[] camisas;
    public GameObject[] pantalones;
    public GameObject[] zapatos;

    private int indiceCabello = 0;
    private int indiceCamisa = 0;
    private int indicePantalon = 0;
    private int indiceZapato = 0;

    void Start()
    {
        
        indiceCabello = PlayerPrefs.GetInt("CabelloSeleccionado", 0);
        indiceCamisa = PlayerPrefs.GetInt("CamisaSeleccionada", 0);
        indicePantalon = PlayerPrefs.GetInt("PantalonSeleccionado", 0);
        indiceZapato = PlayerPrefs.GetInt("ZapatoSeleccionado", 0);

        Debug.Log("CARGADO DESDE PlayerPrefs => " +
            "Cabello: " + indiceCabello +
            ", Camisa: " + indiceCamisa +
            ", Pantalón: " + indicePantalon +
            ", Zapato: " + indiceZapato);

        
        ActivarSoloEste(cabellos, indiceCabello);
        ActivarSoloEste(camisas, indiceCamisa);
        ActivarSoloEste(pantalones, indicePantalon);
        ActivarSoloEste(zapatos, indiceZapato);
    }

    public void CambiarCabello()
    {
        indiceCabello = (indiceCabello + 1) % cabellos.Length;
        ActivarSoloEste(cabellos, indiceCabello);
        PlayerPrefs.SetInt("CabelloSeleccionado", indiceCabello);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Cabello => " + indiceCabello);
    }

    public void CambiarCamisa()
    {
        indiceCamisa = (indiceCamisa + 1) % camisas.Length;
        ActivarSoloEste(camisas, indiceCamisa);
        PlayerPrefs.SetInt("CamisaSeleccionada", indiceCamisa);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Camisa => " + indiceCamisa);
    }

    public void CambiarPantalon()
    {
        indicePantalon = (indicePantalon + 1) % pantalones.Length;
        ActivarSoloEste(pantalones, indicePantalon);
        PlayerPrefs.SetInt("PantalonSeleccionado", indicePantalon);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Pantalón => " + indicePantalon);
    }

    public void CambiarZapato()
    {
        indiceZapato = (indiceZapato + 1) % zapatos.Length;
        ActivarSoloEste(zapatos, indiceZapato);
        PlayerPrefs.SetInt("ZapatoSeleccionado", indiceZapato);
        PlayerPrefs.Save();
        Debug.Log("Guardado: Zapato => " + indiceZapato);
    }

    private void ActivarSoloEste(GameObject[] objetos, int indice)
    {
        for (int i = 0; i < objetos.Length; i++)
        {
            objetos[i].SetActive(i == indice);
        }
    }

    
    public void BorrarPersonalizacion()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Personalización borrada.");

        indiceCabello = 0;
        indiceCamisa = 0;
        indicePantalon = 0;
        indiceZapato = 0;

        ActivarSoloEste(cabellos, indiceCabello);
        ActivarSoloEste(camisas, indiceCamisa);
        ActivarSoloEste(pantalones, indicePantalon);
        ActivarSoloEste(zapatos, indiceZapato);
    }
}