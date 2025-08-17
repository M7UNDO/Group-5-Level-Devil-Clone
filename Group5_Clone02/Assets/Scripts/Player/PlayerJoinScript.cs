using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerJoinScript : MonoBehaviour
{
    public Transform SpawnPoint1, SpawnPoint2;
    public GameObject Player1, Player2;
    public PlayerInput player1, player2;
    //public bool canSetPlayerJump = false;
    //public bool canSetPlayerSpeed = false;
    //public float jumpPower;
    //public float moveSpeed;

    void Awake()
    {
        //Instantiate(Player1, SpawnPoint1.position, SpawnPoint1.rotation);
        //Instantiate(Player2, SpawnPoint2.position, SpawnPoint2.rotation);
        player1 = PlayerInput.Instantiate(Player1, controlScheme: "WASD", pairWithDevice: Keyboard.current);
        player1.transform.position = SpawnPoint1.position;
       
        player2 = PlayerInput.Instantiate(Player2, controlScheme: "Arrows", pairWithDevice: Keyboard.current);
        player2.transform.position = SpawnPoint2.position;

       /* if (canSetPlayerJump)
        {
            
            player1.gameObject.GetComponent<PlayerMovement>().jumpPower = jumpPower;
            player2.gameObject.GetComponent<PlayerMovement>().jumpPower = jumpPower;
        }
        /*
        if (canSetPlayerSpeed)
        {
            player1.gameObject.GetComponent<PlayerMovement>().moveSpeed = moveSpeed;
            player2.gameObject.GetComponent<PlayerMovement>().moveSpeed = moveSpeed;
        }
        */
    }

}
