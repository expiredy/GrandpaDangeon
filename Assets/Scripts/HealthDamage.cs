using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamage : MonoBehaviour
{
    [SerializeField] public LayerMask bulletLayerMask;
    private float totalHealth = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.totalHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.layer == 7);
        if (collision.gameObject.layer == 7)
        {
            this.totalHealth -= 25f;
        }
    }
}
