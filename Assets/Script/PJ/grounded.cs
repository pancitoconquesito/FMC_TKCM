using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{


    [Header("-- Grounded --")]

    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float largeRay;
    [SerializeField] private string tagCompare;
    [SerializeField] private LayerMask layer;
    private float offset_X;
    private float offset_Y;

    private void Start()
    {
        //offset_X = (boxCollider.bounds.size.x / 2) * 0.7f;
        offset_X = (boxCollider.bounds.size.x / 2);
        offset_Y = (boxCollider.bounds.size.y / 2)+0.0001f;
        
    }
    private bool privateIsGrounded = false;
    public bool isGrounded()
    {
        privateIsGrounded = lanzarRayo(0, offset_Y)
        || lanzarRayo(offset_X, offset_Y)
        || lanzarRayo(-offset_X, offset_Y);
        return privateIsGrounded;
    }
    private bool lanzarRayo(float offetX, float offsetY)
    {
        Vector2 newPosition = new Vector2(transform.position.x + offetX, transform.position.y - offsetY);
        RaycastHit2D hit = Physics2D.Raycast(newPosition, Vector2.down, largeRay, layer);
        if (hit.collider != null && (hit.collider.CompareTag(tagCompare) || !hit.collider.CompareTag("tru"))  )
        {
            Debug.DrawRay(newPosition, Vector2.down * largeRay, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(newPosition, Vector2.down * largeRay, Color.red);
        }
        return false;
    }
}
