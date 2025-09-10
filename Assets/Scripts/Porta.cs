using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    [SerializeField] GameObject porta;
    [SerializeField] Transform Apriporta;
    [SerializeField] Transform Chiudiporta;
    bool GiocatorePorta;
    bool Statoporta;
    void Update()
    {
        if (GiocatorePorta && Input.GetKeyDown(KeyCode.E))
        {
            if (Statoporta) ChiudiPorta();
            else ApriPorta();
        }
    }

    public void ApriPorta()
    {
        porta.transform.SetPositionAndRotation(Apriporta.position, Apriporta.rotation);
        Statoporta = true;
    }

    public void ChiudiPorta()
    {
        porta.transform.SetPositionAndRotation(Chiudiporta.position, Chiudiporta.rotation);
        Statoporta = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiocatorePorta = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiocatorePorta = false;
        }
    }
}
