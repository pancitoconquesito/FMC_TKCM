using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPared : MonoBehaviour
{
    //[SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float largeRay;
    [SerializeField] private string tagCompare;
    private float offset_X;
    private float offset_Y;
    void Start()
    {
        offset_Y = 0;
        offset_X = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //checkIsPared();
    }
    public bool checkIsPared()
    {
        return lanzarRayo(offset_X, offset_Y);
    }
    private bool lanzarRayo(float offetX, float offsetY)
    {
        Vector2 newPosition = new Vector2(transform.position.x + offetX, transform.position.y - offsetY);
        RaycastHit2D hit = Physics2D.Raycast(newPosition, Vector2.up, largeRay);
        if (hit.collider != null && hit.collider.CompareTag(tagCompare))
        {
            Debug.DrawRay(newPosition, Vector2.up * largeRay, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(newPosition, Vector2.up * largeRay, Color.red);
        }
        return false;
    }
}
