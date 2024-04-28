using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    //Systeme de l'ancre-arbalete
    public PlayerInputActions playerControls;
    [SerializeField] private InputAction fire;
    public Vector2 PointerPosition { get; set; }

    //Proprietes de base
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;
    private Animator anim;

    //Proprietes de combat
    private int damageFromPlayer;
    public KeyCode fist;
    public KeyCode anchor;

    private int facedDirection;

    //"Animations" simples de combat
    public GameObject rightHitbox;
    public GameObject leftHitbox;
    public GameObject upHitbox;
    public GameObject downHitbox;

    public Sprite fistLeft;
    public Sprite fistRight;
    public Sprite fistFront;
    public Sprite fistBack;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Déplacements basiques (droite, gauche, haut, bas)
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        anim.SetBool("goRight", change.x > 0);
        anim.SetBool("goLeft", change.x < 0);
        anim.SetBool("goBack", change.y > 0);
        anim.SetBool("goFront", change.y < 0);

        if (change.x > 0)
        {
            facedDirection = 0;
        }
        else if (change.x < 0)
        {
            facedDirection = 1;
        }
        else if (change.y > 0)
        {
            facedDirection = 2;
        }
        else if (change.y < 0)
        {
            facedDirection = 3;
        }

        //Attaque : coup de poing
        if (Input.GetKeyDown(fist))
        {
            fistAttack(facedDirection);
        }

        /*Attaque : ancre-arbalète (power-up)
        if (Input.GetKeyDown(anchor))
        {
            anchorAttack();
        }*/

    }

    private void FixedUpdate()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
    }
    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }

    //Attaques possibles par le joueur
    public void fistAttack(int id)
    {
        switch (id)
        {
            case 0:
                anim.SetTrigger("R_fistAttack");
                rightHitbox.SetActive(true);
                break;             
            case 1:                
                anim.SetTrigger("L_fistAttack");
                leftHitbox.SetActive(true);
                break;             
            case 2:                
                anim.SetTrigger("B_fistAttack");
                upHitbox.SetActive(true);
                break;             
            case 3:                
                anim.SetTrigger("F_fistAttack");
                downHitbox.SetActive(true);
                break;
        }
        damageFromPlayer = UnityEngine.Random.Range(5, 35);
        Debug.Log("Fist attack : " + damageFromPlayer);
    }
    
    /*public void anchorAttack()
    {
        damageFromPlayer = UnityEngine.Random.Range(15, 75);
        Debug.Log("Anchor attack : " + damageFromPlayer);
    }

    //Systeme de l'ancre-arbalète
    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        fire.Disable();
    }
    private void Fire(InputAction.CallbackContext context)
    {

    }*/
}
