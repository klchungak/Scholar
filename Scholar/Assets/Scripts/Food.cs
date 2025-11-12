using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D foodArea;
    // Start is called before the first frame update
    void Start()
    {
     Randomposition();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);

        // Debug.Log(foodArea.bounds.min.x);
        //  Debug.Log(foodArea.bounds.max.x);
        // Debug.Log(foodArea.bounds.min.y);
        // Debug.Log(foodArea.bounds.max.y);
        // Random.Range( foodArea.bounds.min.x, foodArea.bounds.max.x);
        // Random.Range(foodArea.bounds.min.y, foodArea.bounds.max.y);

        Randomposition();
    }
        void Randomposition()
    {
        transform.position = new UnityEngine.Vector3(Random.Range(foodArea.bounds.min.x, foodArea.bounds.max.x), Random.Range(foodArea.bounds.min.y, foodArea.bounds.max.y), 0);
    }
    }


