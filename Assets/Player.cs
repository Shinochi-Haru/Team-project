using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>ç∂âEà⁄ìÆÇ∑ÇÈóÕ</summary>
    [SerializeField] float movePower = 10f;
    /// <summary>ÉWÉÉÉìÉvÇ∑ÇÈóÕ</summary>
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
        // óÕÇâ¡Ç¶ÇÈ
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
