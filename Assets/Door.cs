using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float UpPower = 10f;
    Rigidbody2D rb = default;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// êGÇ¡ÇΩÇÁÉhÉAÇ™äJÇ≠
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(Vector2.up * UpPower, ForceMode2D.Impulse);

            if (collision.gameObject.CompareTag("tenjou"))
            {
                rb.AddForce(Vector2.up * 0, ForceMode2D.Impulse);
            }
        }
    }
}
