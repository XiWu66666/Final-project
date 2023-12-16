using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    public float leftBound = -5.0f;
    public float rightBound = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float newXpos = transform.position.x + moveHorizontal * speed * Time.deltaTime;
        newXpos = Mathf.Clamp(newXpos, leftBound, rightBound);
        transform.position = new Vector3(newXpos, transform.position.y, transform.position.z);

    }
}
