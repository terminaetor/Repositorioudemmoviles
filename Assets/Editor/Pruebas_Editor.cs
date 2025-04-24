using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
[CustomEditor(typeof(Pruebas))]
public class Pruebas_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("capturar"))
        {
            Pruebas p = (Pruebas)target;
            p.Capturar();
        }

        if (GUILayout.Button("borrar capturas"))
        {
            PlayerPrefs.SetString("capturas", "");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (GUILayout.Button("Capturar criatura"))
        {
            Pruebas p = (Pruebas)target;
            p.CapturarEnCombate();
        }
    }
}
