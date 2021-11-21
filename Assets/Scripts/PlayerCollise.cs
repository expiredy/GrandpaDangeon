using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollise : MonoBehaviour
{
    public float defaultHp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        defaultHp -= 10;
        removeOnNullHp();
    }

    private void removeOnNullHp()
    {
        if (defaultHp < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        defaultHp -= 0.1f;
        removeOnNullHp();
    }
}
