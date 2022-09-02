using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>ç∂âEà⁄ìÆÇ∑ÇÈóÕ</summary>
    [SerializeField] float m_movePower = 10f;
    /// <summary>ÉWÉÉÉìÉvÇ∑ÇÈóÕ</summary>
    [SerializeField] float m_jumpPower = 15f;
    Rigidbody2D m_rb = default;
    float m_h;
    bool nidan = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (checkground)
            {
                nidan = true;
                m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            }
            else if (nidan)
            {
                nidan = false;
                m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        // óÕÇâ¡Ç¶ÇÈ
        m_rb.AddForce(Vector2.right * m_h * m_movePower, ForceMode2D.Force);
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
