using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realizarDanio : MonoBehaviour
{
    [SerializeField] private dataDanio m_dataDanio;
    void OnTriggerStay2D(Collider2D collision)
    {
        //ContactPoint2D[] allPoints = new ContactPoint2D[collision.shapeCount];
        //collision.GetContacts(allPoints);
        //m_dataDanio.posicionDanio = allPoints[0].point;

        IDamageable damageable = collision.GetComponent<IDamageable>();
        damageable?.RecibirDanio_I(m_dataDanio);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ContactPoint2D[] allPoints = new ContactPoint2D[1];
        collision.GetContacts(allPoints);
        Vector2 aaa = new Vector2(allPoints[0].point.x, allPoints[0].point.y);
        m_dataDanio.posicionDanio = aaa;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Instantiate(sphere, aaa, Quaternion.identity);

        print("collision name :"+collision.name);
    }*/

}
