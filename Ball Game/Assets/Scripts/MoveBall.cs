using System;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float Speed = 3;
    public float ShapeRecoverRate = 0.05f;

    private Rigidbody2D rb2D;

    private DateTime _nextChangeTime = DateTime.Now;
    private Vector3 _orientation = Vector3.right;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (_nextChangeTime < DateTime.Now) {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        rb2D.rotation = Mathf.Rad2Deg * Mathf.Atan2(rb2D.velocity.y, rb2D.velocity.x);
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, ShapeRecoverRate);
    }

    private void OnCollisionEnter2D(Collision2D col2D) {
        if (col2D.gameObject.CompareTag("Player")) {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            _nextChangeTime = DateTime.Now.AddMilliseconds(135);
        }
    }
}
