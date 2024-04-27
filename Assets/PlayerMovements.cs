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
    public KeyCode foot;
    public KeyCode anchor;

    private bool isFacingRight;
    private bool isFacingUp;

    //"Animations" simples de combat
    public Sprite fistLeft;
    public Sprite fistRight;
    public Sprite fistFront;
    public Sprite fistBack;
    public Sprite footLeft;
    public Sprite footRight;
    public Sprite footFront;
    public Sprite footBack;

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

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }

        anim.SetBool("goRight", change.x > 0);
        anim.SetBool("goLeft", change.x < 0);
        anim.SetBool("goBack", change.y > 0);
        anim.SetBool("goFront", change.y < 0);

        if (change.x > 0)
        {
            isFacingRight = true;
        }
        if (change.x < 0)
        {
            isFacingRight = false;
        }
        if (change.y > 0)
        {
            isFacingUp = true;
        }
        if (change.y < 0)
        {
            isFacingUp = false;
        }

        //Attaque : coup de poing
        if (Input.GetKeyDown(fist) && (isFacingRight))
        {
            Debug.Log("j'adore la prog");
            fistAttack(0);
        }
        if (Input.GetKeyDown(fist) && (isFacingRight))
        {
            Debug.Log("j'adore la prog");
            fistAttack(1);
        }
        if (Input.GetKeyDown(fist) && (isFacingRight))
        {
            Debug.Log("j'adore la prog");
            fistAttack(2);
        }
        if (Input.GetKeyDown(fist) && (isFacingRight))
        {
            Debug.Log("j'adore la prog");
            fistAttack(3);
        }

        //Attaque : coup de pied
        if (Input.GetKeyDown(foot))
        {
            footAttack();
        }

        //Attaque : ancre-arbalète (power-up)
        if (Input.GetKeyDown(anchor))
        {
            anchorAttack();
        }
    }

    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    //Attaques possibles par le joueur
    public void fistAttack(int id)
    {
        switch (id)
        {
            case 0:
                anim.SetTrigger("R_fistAttack");
                break;             
            case 1:                
                anim.SetTrigger("L_fistAttack");
                break;             
            case 2:                
                anim.SetTrigger("F_fistAttack");
                break;             
            case 3:                
                anim.SetTrigger("B_fistAttack");
                break;
        }
        damageFromPlayer = UnityEngine.Random.Range(5, 35);
        Debug.Log("Fist attack : " + damageFromPlayer);
    }
    public void footAttack()
    {
        damageFromPlayer = UnityEngine.Random.Range(10, 50);
        Debug.Log("Foot attack : " + damageFromPlayer);
    }
    public void anchorAttack()
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

    }
}
