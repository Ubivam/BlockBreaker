using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int maxHits;
    public GameObject smoke;
    public AudioClip crack;
    public Sprite[] hitSprites;
    private LevelManager levelManager;
    private int timesHit;
    public static int numberOfBricks = 0;
    private bool isBreakable;

    public static void resetNumberOfBricks()
    {
        numberOfBricks = 0;
    }
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
            numberOfBricks++;
        timesHit = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
            HandleHits();
    }
    private void HandleHits()
    {
        if ((++timesHit) >= maxHits)
        {
            numberOfBricks--;
            levelManager.BrickDestroyed();
            puffSmoke();
            Destroy(gameObject);
        }
        else
            LoadSprite();
    }
    private void puffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity);
        ParticleSystem.MainModule settings = smokePuff.GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(gameObject.GetComponent<SpriteRenderer>().color);

    }
    private void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        { 
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite load error");
        }
    }
}
