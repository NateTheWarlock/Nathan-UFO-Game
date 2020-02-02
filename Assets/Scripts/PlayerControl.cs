using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        SetCountText ();

        
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("AntiPickUp"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }

        if (count == 10)
        {
            transform.position = new Vector2(100.0f, 0.0f);
        }
    }
    void SetCountText()
        {
            countText.text = "Bit Score: " + count.ToString();
        if (count >= 18)
        {
            winText.text = "You Survived! By:Nathan Samuelson";
        }

        }
    

}
