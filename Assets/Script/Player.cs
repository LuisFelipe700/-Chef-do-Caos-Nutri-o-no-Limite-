using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private float forcaPulo = 5f;
    [SerializeField] private float moveH;
    [SerializeField] private bool noPiso = true;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       // Andar();
        Ataque();
        Pular();
    }

    private void FixedUpdate()
    {
        Andar();
    }

    private void Andar()
    {
        moveH = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveH * Time.deltaTime * velocidade, 0, 0);
        AnimaAndar();
    }

    private void AnimaAndar()
    {
        if (moveH > 0)
        {
            sprite.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (moveH < 0)
        {
            sprite.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    private void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && noPiso)
        {
            rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            noPiso = false;
            animator.SetBool("Piso", false);
            animator.SetTrigger("Pulo");
        }

        if (rb.linearVelocity.y < 0)
        {
            animator.SetFloat("ValorPulo", rb.linearVelocity.y);
        }
    }
    private void Ataque()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // StartCoroutine("LancarObjeto");
            animator.SetTrigger("Atacar");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            noPiso = true;
            animator.SetBool("Piso", true);
            
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            animator.SetTrigger("Hit");
            StartCoroutine(Destruir());
        }
        if (collision.gameObject.CompareTag("Ponto"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Sumir");
            Destroy(collision.gameObject, 0.1f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            noPiso = true;
            animator.SetBool("Piso", true);
            animator.SetFloat("ValorPulo", 0);
        }
    }

    

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("EstaVivo", false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
        
    }

}

