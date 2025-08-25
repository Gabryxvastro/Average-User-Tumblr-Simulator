using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSistem : MonoBehaviour
{
    public string Nomefinale;

    public void SaveFinale(string _Nomefinale)
    {
        PlayerPrefs.SetInt(_Nomefinale, 1);
        PlayerPrefs.Save();
        Debug.Log("Salvato il finale" + _Nomefinale);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag  == "Player")
        {
            SaveFinale(Nomefinale);
        }
    }
}
