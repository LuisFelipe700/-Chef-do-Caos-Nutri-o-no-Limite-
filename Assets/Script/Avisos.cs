using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Importante para usar corrotinas

public class MensagemPorContato : MonoBehaviour
{
    [SerializeField] private string textoMensagem = "Você passou de fase!";
    [SerializeField] private GameObject painelMensagem;
    [SerializeField] private TextMeshProUGUI textoUI;

    private void Start()
    {
        if (painelMensagem != null)
            painelMensagem.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (painelMensagem != null && textoUI != null)
            {
                textoUI.text = textoMensagem;
                painelMensagem.SetActive(true);
                StartCoroutine(EsconderMensagemDepoisDeTempo(3f)); // Chama a corrotina
            }
        }
    }

    private IEnumerator EsconderMensagemDepoisDeTempo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        painelMensagem.SetActive(false);
    }
}
