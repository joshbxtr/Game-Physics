using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Can be accessed in inspector
    [SerializeField] private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        //..
    }

    // Update is called once per frame
    // Camera follows player
    private void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
