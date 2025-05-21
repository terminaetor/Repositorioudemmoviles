using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavigationManager : MonoBehaviour
{
    public static NavigationManager singleton;

    private void Awake()
    {
        singleton = this;
    }
    public void GoToRealidadAumentada()
    {
        SceneManager.LoadScene("AR");
    }

    public void GoToPokedex()
    {
        SceneManager.LoadScene("Pokedex");
    }

    public void GoToPersonalizacion()
    {
        SceneManager.LoadScene("Personalizacion");
    }

    public void GoToCombate()
    {
        SceneManager.LoadScene("combate");
    }

    public void GoToNavegacion()
    {
        SceneManager.LoadScene("Navegacion");
    }

}
