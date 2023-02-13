using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f;

    public float jumpForce = 300.0f;
    public bool isJumping = false;    

    public Image dialogueSign;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();

        playerJump();
    }

    public void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("floor")) {
            isJumping = false;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC")) {
            dialogueSign.gameObject.SetActive(true);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC")) {
            dialogueSign.gameObject.SetActive(false);
        }
    }

    private void playerMovement() {
         // left
        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.back * speed * Time.deltaTime; 
        }
        // right
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        // forward
        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        // back
        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void playerJump() {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false) {
            this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            isJumping = true;
        }
    }
}
