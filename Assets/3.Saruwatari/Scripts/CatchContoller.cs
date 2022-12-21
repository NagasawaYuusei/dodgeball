using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchContoller : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" )
        {
            playerController.BallCatch();
        }
    }
}
