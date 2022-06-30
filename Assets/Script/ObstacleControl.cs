using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    private int hitCount;

    void Start()
    {
        hitCount = 5;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Agent"))
        {
            if (hitCount != 0)
            {
                hitCount--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
