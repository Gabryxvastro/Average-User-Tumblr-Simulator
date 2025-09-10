using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitaGenerale : MonoBehaviour
{
    [SerializeField] float HPmax = 100;
    [SerializeField] float HP;
    [SerializeField] bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        HP = HPmax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiaVita(float Quantita)
    {
        HP += Quantita;

        if (HP >= 100)
        {
            HP = 100;
        }



        if (HP <= 0)
        {
            HP = 0;
            this.enabled = false;
            dead = true;
        }
    }
}
