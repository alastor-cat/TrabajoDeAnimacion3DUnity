using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVerification : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerStay(Collider other){
        playerController.isJump = true;
    }

    private void OnTriggerExit(Collider other){
        playerController.isJump = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
