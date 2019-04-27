using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPush : MonoBehaviour
{
    private Trash trash;

    private void Awake()
    {
        trash = GetComponent<Trash>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        Vector2 contactPoint = collision.GetContact(0).point;
        Vector2 direction = new Vector2(transform.position.x, transform.position.y) - contactPoint;
        trash.enabled = false;
        StartCoroutine(MoveTowards(direction));
    }

    IEnumerator MoveTowards(Vector2 direction)
    {
        for(int i = 0; i < 50; i++)
        {
            transform.Translate(new Vector3(direction.x, direction.y, 0) * Time.deltaTime);
            yield return null;
        }
        trash.SetStartPos(transform.position);
        trash.enabled = true;
    }
}
