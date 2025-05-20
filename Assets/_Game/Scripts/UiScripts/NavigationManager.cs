using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavigationManager : MonoBehaviour
{
    public void GoToRealidadAumentada()
    {
        SceneManager.LoadScene("realidadAumentada");
    }

    public void GoToPokedex()
    {
        SceneManager.LoadScene("pokedex");
    }

    public void GoToPersonalizacion()
    {
        SceneManager.LoadScene("personalizacion");
    }

    public void GoToCombate()
    {
        SceneManager.LoadScene("combate");
    }

    public void GoToNavegacion()
    {
        SceneManager.LoadScene("navegacion");
    }

}
