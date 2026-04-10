using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spike"))
        {
            Die();
        }
        if(other.CompareTag("DeathZone"))
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
