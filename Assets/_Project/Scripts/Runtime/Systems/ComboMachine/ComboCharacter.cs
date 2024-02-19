using UnityEngine;

public class ComboCharacter : MonoBehaviour
{

    private StateMachine meleeStateMachine;

    [SerializeField] public Collider2D hitbox;
    [SerializeField] public GameObject Hiteffect;

    public Rigidbody2D playerRb;
    public Animator animator;
    public float speed;
    public float jumpForce;
    public bool isLeft;

    // Start is called before the first frame update
    void Start()
    {
        meleeStateMachine = GetComponent<StateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UserInput.Instance.Attack_Input_Pressed && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
        {
            meleeStateMachine.SetNextState(new GroundEntryState());
        }


        if (UserInput.Instance.MoveInput.x != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        playerRb.velocity = new Vector2(UserInput.Instance.MoveInput.x * speed, playerRb.velocity.y);

        if (UserInput.Instance.Jump_Input_Pressed)
        {
            playerRb.AddForce(new(0, jumpForce));
        }

        if ( isLeft && UserInput.Instance.MoveInput.x > 0)
        {
            Flip();
        }

        if (!isLeft && UserInput.Instance.MoveInput.x < 0)
        {
            Flip();
        }


    }

    private void Flip()
    {
        isLeft = !isLeft;
        float scaleX = transform.localScale.x;
        scaleX *= -1f;
        transform.localScale = new(scaleX, transform.localScale.y, transform.localScale.z);
    }
}
