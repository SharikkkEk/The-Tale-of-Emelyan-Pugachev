using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float MaxSpeed = 10f;
    private Rigidbody2D _rb;
    private float _xMovement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (GameStateMachine.state == GameStates.walking)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        _xMovement = Input.GetAxisRaw("Horizontal") * MaxSpeed;
        if (_xMovement != 0) 
        {
            Flip();
            _rb.velocity = new Vector2(_xMovement, 0); 
        } 
        else
        {
            _rb.velocity = new Vector2(0, 0);
        }
    }

    private void Flip()
    {
        transform.localScale = _xMovement switch
        {
            > 0 => new Vector3(2, 2, 1),
            < 0 => new Vector3(-2, 2, 1),
            _ => transform.localScale
        };
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Npc" && Input.GetKeyDown("space"))
        {

        }
    }
}
