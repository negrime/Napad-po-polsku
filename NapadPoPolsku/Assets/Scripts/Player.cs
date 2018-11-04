using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;
    public GameObject bullet;
    private Vector2 movementInput;
    private Rigidbody2D rb;

  public  Vector2 curDir = new Vector2(0.0f, 0.1f);
    Transform transformObj;
    

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        transformObj = this.transform;
    }

	void Update ()
    {
        MouseRotate();
        Shoot();
         	
	}

    private void FixedUpdate()
    {
        Movement();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
        }
    }





    private void MouseRotate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objPos = transformObj.position;

        Vector2 direction = mousePos - objPos;
        direction.Normalize();
        curDir = Vector2.Lerp(curDir, direction, Time.deltaTime * rotateSpeed);
        transformObj.up = curDir;
    }
    private void Movement()
    {
        movementInput = new Vector2(Input.GetAxis("Horizontal"), (Input.GetAxis("Vertical")));
        rb.velocity = speed * movementInput;
    }
}

