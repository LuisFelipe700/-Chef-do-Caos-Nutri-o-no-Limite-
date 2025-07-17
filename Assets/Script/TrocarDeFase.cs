using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarDeFase : MonoBehaviour
{
    [SerializeField] private string nomeDaCena = "Fase2"; // Nome da próxima fase

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se foi o personagem que tocou
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }
}

