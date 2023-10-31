using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    // Start is called before the first frame update

    private float _velocidade = 6.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);

        if ( transform.position.x < -9.0f)
        {
            transform.position = new Vector3(9.0f,Random.Range(-3.5f, 3.5f), 0 );


        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);

        if (other.tag == "Tiro")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }

        if ( other.tag == "Player")
        {
            Player player = GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }
        
        
        
        }

        Destroy(this.gameObject);

    }
}
