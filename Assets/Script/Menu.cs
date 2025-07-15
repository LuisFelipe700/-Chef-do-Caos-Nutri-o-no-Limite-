using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour

    {
    // Nome da cena para qual você quer ir
    public string Jogo;

    // Função que será chamada pelo botão
    public void MudarCena1()
    {
        SceneManager.LoadScene(Jogo);
    }
}

