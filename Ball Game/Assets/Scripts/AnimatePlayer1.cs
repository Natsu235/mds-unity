using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class AnimatePlayer1 : MonoBehaviour
{
    [Tooltip("Vitesse max en unités par secondes")]
    public int MaxSpeed = 2;
    [Tooltip("Touche pour aller à gauche")]
    public UnityEngine.KeyCode LeftKey = KeyCode.Q;
    [Tooltip("Touche pour aller à droite")]
    public UnityEngine.KeyCode RightKey = KeyCode.D;
    [Tooltip("Touche pour aller en haut")]
    public UnityEngine.KeyCode UpKey = KeyCode.Z;
    [Tooltip("Touche pour aller en bas")]
    public UnityEngine.KeyCode DownKey = KeyCode.S;
    [Tooltip("Touche pour faire une roulade")]
    public UnityEngine.KeyCode RollKey = KeyCode.Space;

    // Scripts
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb2D;

    // Variables
    private Vector3 speed;

    // Constantes
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Roll = Animator.StringToHash("Roll");
    //private static readonly int GoingUp = Animator.StringToHash("GoingUp");

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var maxDistancePerFrame = MaxSpeed;
        Vector3 move = Vector3.zero;

        if (Input.GetKey(RightKey))
        {
            move += Vector3.right * maxDistancePerFrame;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(LeftKey))
        {
            move += Vector3.left * maxDistancePerFrame;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(UpKey))
        {
            move += Vector3.up * maxDistancePerFrame;
        }
        else if (Input.GetKey(DownKey))
        {
            move += Vector3.down * maxDistancePerFrame;
        }

        if (animator.GetBool(Roll)) animator.ResetTrigger(Roll);
        // Ici on utilise GetKeyDown, qui ne retourne true que la première frame où la touche est appuyée
        if (Input.GetKeyDown(RollKey))
        {
            animator.SetTrigger(Roll);
        }

        //animator.SetBool(GoingUp, Input.GetKey(KeyCode.UpArrow));

        animator.SetFloat(Speed, move.magnitude * 10f);
        rb2D.velocity = move;
    }
}
