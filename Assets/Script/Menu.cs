using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour

    {
    // Nome da cena para qual voc� quer ir
    public string Jogo;

    // Fun��o que ser� chamada pelo bot�o
    public void MudarCena1()
    {
        SceneManager.LoadScene(Jogo);
    }
}

