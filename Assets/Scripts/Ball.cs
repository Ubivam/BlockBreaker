using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    public PhysicsMaterial2D ballRepair;

    private PhysicsMaterial2D oldMat;

    private Rigidbody2D rigi;

    private Vector3 paddleToBallVector;

    private int numberOfCollisions;

    private bool reapir;

    private bool hasStarted = false;

    private void Awake()
    {
        numberOfCollisions = 0;
        rigi = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            if (Input.GetMouseButtonUp(0))
            {
                rigi.velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
            else
            {
                this.transform.position = paddle.transform.position + paddleToBallVector;
            }
        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            if (collision.gameObject.tag != "Breakable" && collision.gameObject.tag != "Unbreakable")
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
            numberOfCollisions++;
            rigi.velocity += tweak;
            RepairVelocity();
        }
    }
    private void RepairVelocity()
    {
        if (numberOfCollisions % 34 == 0)
        {
            Debug.Log("Bouncyness 0.1");
            oldMat = gameObject.GetComponent<CircleCollider2D>().sharedMaterial;
            gameObject.GetComponent<CircleCollider2D>().sharedMaterial = ballRepair;
            reapir = true;
            return;
        }
        if (reapir)
        {
            gameObject.GetComponent<CircleCollider2D>().sharedMaterial = oldMat;
            reapir = false;
        }
    }
}
