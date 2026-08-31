using UnityEngine;
using UnityEngine.SceneManagement;

public class ETLRBootstrap:MonoBehaviour {
    void Awake(){if(GameState.I==null)new GameObject("GameState").AddComponent<GameState>();}
    void Start(){if(SceneManager.GetActiveScene().name=="Boot")SceneManager.LoadScene("Game");}
}
