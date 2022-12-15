using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{

    public AudioSource trophySound;

    // Start is called before the first frame update
    private void Start()
    {
        trophySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //..
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            trophySound.Play();
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
