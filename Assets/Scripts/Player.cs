using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float veloc ;

     
    // Start is called before the first frame update

    
    [SerializeField]
    private float _podeDisparar;

    [SerializeField]
    public bool _possoDarDisparoTriplo = false;

    public GameObject _DisparoTriploPrefab;
    public GameObject _pfLaser;
    private float _tempoDeDisparo;
    public int vidas = 3;

    void Start()
    {
        Debug.Log("Método Start de "+this.name) ;
        veloc = 3.0f ;
        transform.position = new Vector3(0,0,0);  
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetKeyDown(KeyCode.Space)){

            Instantiate(_pfLaser,transform.position + new Vector3 (1.127f,-0.31f,0),Quaternion.identity);

            Disparo();
        }

        // Movimento Horizontal X
       float entradaHorizontal = Input.GetAxis("Horizontal");
                     transform.Translate(Vector3.right * veloc * Time.deltaTime * entradaHorizontal );



        if ( transform.position.x > 7.84f) {
            transform.position = new Vector3(7.84f,transform.position.y,0);
        }

        if ( transform.position.x < -7.84f){
             transform.position = new Vector3(-7.84f,transform.position.y,0);
        }


        // Movimento vertical Y

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * veloc * Time.deltaTime * entradaVertical );


        if ( transform.position.y > 5.71f){
            transform.position = new Vector3(transform.position.x,-5.71f,0);
        }
         if ( transform.position.y < -5.71f){
            transform.position = new Vector3(transform.position.x,5.71f,0);
         }
    }

    private void Disparo()
    {


        Debug.Log("oi");
         


        if (Time.time > _podeDisparar)
          {

           
            if (_possoDarDisparoTriplo == true)
            {
                Instantiate(_DisparoTriploPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_pfLaser, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
            }
             _podeDisparar = Time.time + _tempoDeDisparo ;
          }
    }
    public IEnumerator DisparoTriploRotina(){
        yield return new WaitForSeconds(7.0f);
        _possoDarDisparoTriplo = false;

    }

    public void DanoAoPlayer()
    {
        // vidas = vidas - 1;
        vidas--;

        if ( vidas < 1 )
        {
            Destroy(this.gameObject);
        }
    }
}