using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarDeFase : MonoBehaviour
{
    [SerializeField] private string nomeDaCena = "Fase2";

    // Método chamado quando o jogador encosta no objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TrocarCena();
        }
    }

    // Método público que pode ser chamado por um botão
    public void TrocarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}

