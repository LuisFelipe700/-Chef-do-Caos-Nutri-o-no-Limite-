using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Boss : MonoBehaviour
{
    private int dir = 1;
    [SerializeField] private float speed;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private AudioClip somMorte;
    void Start()
    {
        Patrulha();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);

    }
    void Patrulha()
    {
        if (dir == 1)
        {
            dir = -1;

        }
        else
        {
            dir = 1;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Direita"))
        {
            Patrulha();
            spriteRenderer.flipX = true;
        }
        else if (collision.gameObject.CompareTag("Esquerda"))
        {
            Patrulha();
            spriteRenderer.flipX = false;
        }
    }

}

internal class Audio
{
}