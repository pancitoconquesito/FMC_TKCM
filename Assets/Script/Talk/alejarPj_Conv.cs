using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alejarPj_Conv : MonoBehaviour
{
    private float mi_x;
    void Start()
    {
        mi_x = transform.position.x;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.transform.position.x < mi_x)
            {
                LeanTween.moveX(collision.gameObject, collision.transform.position.x-0.1f,0.07f);
            }
            else
            {
                LeanTween.moveX(collision.gameObject, collision.transform.position.x + 0.1f, 0.07f);
            }
        }
    }
}
