using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // This function will be triggered when the enemy collides with the player
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the GameOver scene after the collision
            SceneManager.LoadScene("GameOver"); 
        }
    }
}