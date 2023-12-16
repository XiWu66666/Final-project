using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50.0f;
   
    private Rigidbody rb;
    
    void Start()
    {
        int seed = System.DateTime.Now.Millisecond;
        Random.InitState(seed);
        float randomValue = Random.Range(-5.0f,5.0f);
        Debug.Log(randomValue);
        rb = GetComponent<Rigidbody>();
        rb.velocity= new Vector3(randomValue, 0.0f , speed);
    }

    /**private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        Vector3 reflection = Vector3.Reflect(rb.velocity, normal);
        rb.velocity= reflection * 1.5f;
    }**/
    // Update is called once per frame
    void Update()
    {
        
    }
}
