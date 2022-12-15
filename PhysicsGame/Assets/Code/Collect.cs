using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{

    private int Apples = 0;
    [SerializeField] private Text ApplesText;
    public AudioSource collectSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            Apples++;
            ApplesText.text = "Apples Collected: " + Apples;
            collectSound.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //..
    }

    // Update is called once per frame
    void Update()
    {
        //..
    }
}
