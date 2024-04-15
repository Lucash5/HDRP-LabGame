using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    //Pelaajan nopeus
    //public UnityEngine.UI.Text Text;
    public bool alive = true;
    public float speed = 350;
    public float jumpForce = 350;


    Rigidbody rb;
    Vector3 playerInput; // pelaajan syötteen tallennukseen

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        playerInput = transform.forward * Input.GetAxis("Vertical") * speed;
        playerInput += transform.right * Input.GetAxis("Horizontal") * speed;
        playerInput.y = rb.velocity.y;


        if (rb.velocity.y > -0.05f && rb.velocity.y < 0.05f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }


        
    }

    private void FixedUpdate()
    {
        rb.velocity = playerInput;
    }


}
