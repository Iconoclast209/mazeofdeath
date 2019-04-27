using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField]
    float splashDelay = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<LevelManager>().LoadNextLevelAfterDelay(splashDelay);
    }

    
}
