using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisibleBlock : MonoBehaviour
{   
    TilemapRenderer visibleBlock;

    float time = 0f;
    float delayTime = 5f;
    bool isVisible;
    // Start is called before the first frame update
    void Start()
    {
        visibleBlock = GetComponent<TilemapRenderer> ();
    }
    void Update()
    {
        time += 1f * Time.deltaTime;
        if (isVisible == false && time >= delayTime)
        {
            visibleBlock.enabled = false;
            isVisible = true;
            time = 0f;
        }
        else if(isVisible == true && time >= delayTime)
        {
            time = 0f;
        }

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {   
        if(other.gameObject.tag == "Player")
        {
            visibleBlock.enabled = true;
            isVisible = false;
        }
    }
}
