using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayers : MonoBehaviour
{
    int index;
    public List<GameObject> players = new List<GameObject>();
    PlayerInputManager MultiplayerManager;

    private void Start()
    {
        MultiplayerManager = GetComponent<PlayerInputManager>();
        index = 0;
        MultiplayerManager.playerPrefab = players[index];

        //PlayerInput.Instantiate(prefab: playerOnePrefab, playerIndex: 0, controlScheme: "Controller", pairWithDevice: Gamepad.current, splitScreenIndex: 0);
        //PlayerInput.Instantiate(prefab: playerTwoPrefab, playerIndex: 1, controlScheme: "Player01", pairWithDevice: Keyboard.current, splitScreenIndex: 1);
    }

    public void spawnNextPlayer(PlayerInput input) 
    {
        index++;
        if (index >= players.Count) 
        { 
            index = 0; 
        }
    }
}
