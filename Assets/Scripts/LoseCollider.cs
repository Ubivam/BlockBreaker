using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.Lose();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
