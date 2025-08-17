using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Rigidbody rigidbody;
    Vector3 direzione;
    [SerializeField] float jumpforce = 7f;
    bool isgrouended = true;
    Animator animator;
    [SerializeField] float stamina = 10f;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float shiftSpeed = 10f;
    //[SerializeField] GameObject pistola, fucile, minigun;
    [SerializeField] float HP = 100;
    //bool HasPistol = false, HasRiffle = false, HasMinigun = false;
    //[SerializeField] Image ui, imagepistol, imageriffle, imageminigun, cursor;
    //[SerializeField] AudioSource audiosource;
    //[SerializeField] AudioClip jump;
    [SerializeField] GameObject damageUi;
    public bool dead;
    /*public enum Armi
    {
        None,
        Pistola,
        Fucile,
        Minigun
    }

    Armi armi = Armi.None;*/

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");
        direzione = new Vector3(movehorizontal, 0.0f, movevertical);
        direzione = transform.TransformDirection(direzione);
        if (direzione.x != 0 || direzione.z != 0)
        {
            animator.SetBool("Run", true);
            /*if (!audiosource.isPlaying && isgrouended)
            {
                audiosource.Play();
            }

        }*/

            if (direzione.x == 0 && direzione.z == 0)
            {
                animator.SetBool("Run", false);
                //audiosource.Stop();
            }
            if (Input.GetKeyDown(KeyCode.Space) && isgrouended)
            {
                rigidbody.AddForce(new Vector3(0, jumpforce, 0), ForceMode.Impulse);
                isgrouended = false;
                //audiosource.Stop();
                //AudioSource.PlayClipAtPoint(jump, transform.position);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (stamina > 0)
                {
                    stamina -= Time.deltaTime;
                    speed = shiftSpeed;
                }
                else
                {
                    speed = movementSpeed;
                }
            }
            else
            {
                stamina += Time.deltaTime;
                speed = movementSpeed;
            }
            if (stamina > 5f)
            {
                stamina = 5f;
            }
            else if (stamina < 0)
            {
                stamina = 0;
            }

            /*if(Input.GetKeyDown(KeyCode.Alpha1) && HasPistol == true)
            {
                photonView.RPC("ChooseWeapon", RpcTarget.All, Armi.Pistola);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && HasRiffle == true)
            {
                photonView.RPC("ChooseWeapon", RpcTarget.All, Armi.Fucile);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && HasMinigun == true)
            {
                photonView.RPC("ChooseWeapon", RpcTarget.All, Armi.Minigun);
            }*/
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + direzione * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        isgrouended = true;
    }

    void OnTriggerEnter(Collider collider)
    {

    }

    void CambiaVita(float Quantita)
    {
        HP += Quantita;
        damageUi.SetActive(true);
        Invoke("RemoveDamageUi", 0.1f);

        if (HP >= 100)
        {
            HP = 100;
        }

            

        if (HP <= 0)
        {
            HP = 0;
            animator.SetBool("Die", true);
            transform.Find("Main Camera").GetComponent<ThirdPersonCamera>().isSpectator = true;
            this.enabled = false;
            dead = true;
        }

    }

    void RemoveDamageUi()
    {
        damageUi.SetActive(false);
    }
}
