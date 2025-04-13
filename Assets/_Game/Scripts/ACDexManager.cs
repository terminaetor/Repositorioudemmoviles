using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ACDexManager : MonoBehaviour
{
    private string _filePath;
    public ACCriaturas _acCriaturas;

    void Start()
    {
        _filePath = Application.persistentDataPath + "/Dex.json";//Determina direccion en donde se guarda el json que tiene los datos guardados
        CargarDex();
    }

    public void CargarDex()
    {
        if(File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);//si existe el archivo se lee la informacion
            _acCriaturas = JsonUtility.FromJson<ACCriaturas>(json);//Recoger info json
        }
        else
        {
            _acCriaturas = new ACCriaturas();
            GuardarDex();
        }
    }

     public void GuardarDex()
    {
        string json = JsonUtility.ToJson(_acCriaturas, true);//Convertir informacion a json
        File.WriteAllText(_filePath, json);//Funcion que guarda el json
    }
}
