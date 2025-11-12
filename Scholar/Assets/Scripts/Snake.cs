using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public UI UI;
    public GameAudio gameAudio;
    Vector3 direction;
    public float speed;
    public Transform bodyPrefab;
    public List<Transform> bodies = new List<Transform>();
    
    // Start is called before the first frame update
   void Start()
{
    Time.timeScale = speed;
    
    // Try to find UI if not assigned
    if (UI == null)
    {
        UI = FindObjectOfType<UI>();
    }
    
    // Try to find GameAudio if not assigned
    if (gameAudio == null)
    {
        gameAudio = FindObjectOfType<GameAudio>();
    }
    
    ResetStage();
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector3.down)
        {
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S) && direction != Vector3.up)
        {
            direction = Vector3.down;
        }
        
        if (Input.GetKeyDown(KeyCode.A) && direction != Vector3.right)
        {
            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D) && direction != Vector3.left)
        {
            direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;
        }
        
        transform.position += direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("food"))
        {
            Grow();
            
            // Null check for UI
            if (UI != null)
            {
                UI.IncreaseScore();
            }
            else
            {
                Debug.LogWarning("UI reference is null! Assign UI in Inspector.");
            }
            
            // Null check for GameAudio
            if (gameAudio != null)
            {
                gameAudio.PlayEatSound();
            }
        }

        // FIX 2: Check for both "obstacle" AND "body" tags
        if (collision.CompareTag("obstacle") || collision.CompareTag("body"))
        {
            Debug.Log("Game Over");
            ResetStage();
            
            // Null check for GameAudio
            if (gameAudio != null)
            {
                gameAudio.ReplayBackgroundMusic();
            }
        }
    }

    void Grow()
    {
        // FIX 1: Better body spawning with tag assignment
        Transform newSegment = Instantiate(bodyPrefab);
        
        // Set the tag to "body" so it triggers game over
        newSegment.tag = "body";
        
        // Position at the end of the snake
        Vector3 spawnPosition = (bodies.Count > 0) ? bodies[bodies.Count - 1].position : transform.position;
        newSegment.position = spawnPosition;
        
        bodies.Add(newSegment);
        
        // Optional: Temporary collision disable to prevent instant death
        Collider2D newCollider = newSegment.GetComponent<Collider2D>();
        if (newCollider != null)
        {
            newCollider.enabled = false;
            StartCoroutine(EnableColliderAfterDelay(newCollider, 0.3f));
        }
    }

    IEnumerator EnableColliderAfterDelay(Collider2D collider, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (collider != null)
        {
            collider.enabled = true;
        }
    }

    void ResetStage()
    {
        transform.position = Vector3.zero;
        direction = Vector3.zero;

        // Destroy all body segments except head
        for (int i = bodies.Count - 1; i >= 0; i--)
        {
            if (bodies[i] != transform && bodies[i] != null)
            {
                Destroy(bodies[i].gameObject);
            }
        }
        
        bodies.Clear();
        bodies.Add(transform);

        // FIX 1: Null check for UI
        if (UI != null)
        {
            UI.ResetScore();
        }
        else
        {
            Debug.LogWarning("UI reference is null! Assign UI in Inspector.");
        }
    }
}