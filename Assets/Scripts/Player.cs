using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Array of spriets
    public Sprite[] spriets;
    private int spriteIndex;
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private void Awake()
    {
        // Search for spriteRenderer for the same object this script is running on
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteIndex = 0;
    }

    // Called on the first frame of the object's existence
    private void Start()
    {  
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Called every frame, usually handles inputs
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;   
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // If you just began touching(tapping) the screen
            if (touch.phase == TouchPhase.Began)
            {  

            }
        }

        direction.y += gravity * 1.5f * Time.deltaTime;
        transform.position += direction * Time.deltaTime; // Time.deltaTime makes the game frame rate consistent, meaning framerate don't matter

    }
    private void AnimateSprite()
    {
        spriteIndex ++;

        if (spriteIndex >= spriets.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = spriets[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
}
