using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float movePower = 10f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float jumpPower = 15f;
    Rigidbody2D rb = default;
    float h;
    bool nidan = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (checkground)
            {
                nidan = true;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            else if (nidan)
            {
                nidan = false;
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        // 力を加える
        rb.AddForce(Vector2.right * h * movePower, ForceMode2D.Force);
    }


    bool checkground = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkground = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        checkground = false;
    }
    public bool isreturn = false;
}
