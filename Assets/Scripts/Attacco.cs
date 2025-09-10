using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacco : MonoBehaviour
{
    [SerializeField] float danno = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider Other)
    {
        print("Ahia " + Other.name);
        if (Other.gameObject.GetComponentInParent<VitaGenerale>())
        {
            Other.gameObject.GetComponentInParent<VitaGenerale>().CambiaVita(danno);
        }
    }
}
