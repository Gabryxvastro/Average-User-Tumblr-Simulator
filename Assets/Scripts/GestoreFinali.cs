using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreFinali : MonoBehaviour
{
    public List <string> Elencofinali;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string Finale in Elencofinali)
        {
            if(PlayerPrefs.HasKey(Finale))
            {
                int Valore = PlayerPrefs.GetInt(Finale);
                Debug.Log("Il finale " + Finale + " ha valore " + Valore);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
