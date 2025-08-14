using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarDeFase : MonoBehaviour
{
    [SerializeField] private string nomeDaCena = "Fase2";

    // M�todo chamado quando o jogador encosta no objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TrocarCena();
        }
    }

    // M�todo p�blico que pode ser chamado por um bot�o
    public void TrocarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}

