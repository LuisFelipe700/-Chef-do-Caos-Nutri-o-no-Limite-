using UnityEngine;
using UnityEngine.UI;

public class MensagemPorContato : MonoBehaviour
{
    [SerializeField] private string textoMensagem = "Você passou de fase!";
    [SerializeField] private GameObject painelMensagem; // Referência ao painel da UI
    [SerializeField] private Text textoUI; // Texto onde a mensagem será exibida

    private void Start()
    {
        if (painelMensagem != null)
            painelMensagem.SetActive(false); // Começa invisível
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (painelMensagem != null && textoUI != null)
            {
                textoUI.text = textoMensagem;
                painelMensagem.SetActive(true);
            }
        }
    }
}
