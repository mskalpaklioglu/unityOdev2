using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform oyuncu;
    public float bosluk = 4f;

    void LateUpdate()
    {
        Vector3 poz = transform.position;
        float fark = oyuncu.position.x - poz.x;

        if (fark > bosluk) poz.x = oyuncu.position.x - bosluk;
        if (fark < -bosluk) poz.x = oyuncu.position.x + bosluk;

        poz.y = 0;
        poz.z = -10;
        transform.position = poz;
    }
}
