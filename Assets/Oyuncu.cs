using UnityEngine;
using UnityEngine.InputSystem;

public class Oyuncu : MonoBehaviour
{
    public float yurumeHizi = 3f;
    public float kosmaHizi = 7f;
    public float ziplamaGucu = 8f;

    Rigidbody2D rb;
    Collider2D col;
    SpriteRenderer sr;
    bool yerdeMi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 baslangic = new Vector2(col.bounds.center.x, col.bounds.min.y - 0.05f);
        RaycastHit2D isin = Physics2D.Raycast(baslangic, Vector2.down, 0.1f);
        yerdeMi = isin.collider != null;

        float hiz = yurumeHizi;
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            hiz = kosmaHizi;
        }

        float x = 0;
        if (Keyboard.current.dKey.isPressed) x = 1;
        if (Keyboard.current.aKey.isPressed) x = -1;

        if (x > 0) sr.flipX = false;
        if (x < 0) sr.flipX = true;

        rb.linearVelocity = new Vector2(x * hiz, rb.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && yerdeMi)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, ziplamaGucu);
        }
    }
}
