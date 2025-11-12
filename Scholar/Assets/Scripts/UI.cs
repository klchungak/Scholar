using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text scoreText;
    int score; // Changed to lowercase for consistency
    
    void Start()
    {
       // scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void ResetScore() // Removed space from method name
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    
    public void IncreaseScore() // Removed space from method name
    {
        score++;
        scoreText.text = score.ToString();
    }
}
