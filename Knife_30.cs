using System.Collections;

using UnityEngine;


using UnityEngine.SceneManagement;

public class Knife_30 : MonoBehaviour {

    public float speed = 20f;
    public AudioClip hitSound;
    public AudioClip fail;
    Rigidbody2D knifeRigid;
    bool moving = false;


    public GameObject particle;

    public GameObject CutFruit;

    private bool scriptEnabled = true;

	// Use this for initialization
	void Start () 
    {
        // Identify Rigidbody
        knifeRigid = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            knifeRigid.MovePosition(knifeRigid.position + Vector2.up * speed * Time.deltaTime);
            
        }
        // Knife start moving after click
		if (Input.touchCount>0 || Input.GetKeyDown(KeyCode.Space) && !GameController_30.instance.isGameover)
        {
            moving = true;

        }
          

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("TAG_2"))
        {
            
           GameController_30.instance.KnifeSpawned = true;
            Destroy(gameObject);
        }


        if(scriptEnabled)
        {
          
          

              if (collider.gameObject.tag == "TAG_1"||collider.gameObject.tag=="TAG_5")
            {
                GameController_30.instance.hit++; ;
            
                    // Stop knife moving, rotate with Trunk and play hit sound
                    moving = false;
                    transform.parent = collider.transform;
                    GetComponent<PolygonCollider2D>().enabled = false;
                    knifeRigid.bodyType = RigidbodyType2D.Kinematic;
              
                    transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
                
                GetComponent<AudioSource>().PlayOneShot(hitSound);
                     GameController_30.instance.KnifeSpawned = true;

                
                    collider.GetComponent<Animator>().SetTrigger("Hit");
                    collider.GetComponent<TrunkHealth_30>().Damage(1);
                 
                Instantiate(particle, transform.position + transform.up * 0.25f, Quaternion.identity);
                if (GameController_30.instance.PowerMode)
                {

                    GameController_30.instance.score += new Bettr_Encryption.Encrypt(10*(GameController_30.instance.power+2));
                    GameController_30.instance.Score_Encrypt = XOREncryption.encryptDecrypt(GameController_30.instance.Score_Encrypt);
                    GameController_30.instance.Score_Encrypt = (int.Parse(GameController_30.instance.Score_Encrypt) + 10 * GameController_30.instance.power + 1).ToString();
                    GameController_30.instance.Score_Encrypt = XOREncryption.encryptDecrypt(GameController_30.instance.Score_Encrypt);
                 

                }
                else
                {
                    GameController_30.instance.score += new Bettr_Encryption.Encrypt(10);
                    GameController_30.instance.Score_Encrypt = XOREncryption.encryptDecrypt(GameController_30.instance.Score_Encrypt);
                    GameController_30.instance.Score_Encrypt = (int.Parse(GameController_30.instance.Score_Encrypt) + 10).ToString();
                    GameController_30.instance.Score_Encrypt = XOREncryption.encryptDecrypt(GameController_30.instance.Score_Encrypt);
                }
                

                scriptEnabled = false;
                GetComponent<Knife_30>().enabled = false;


            }






            else
            {

                if (collider.tag == "TAG_3")
                {
                    GameController_30.instance.hit++; ;

                    moving = true;
                    Destroy(collider.gameObject);
                   GameObject FruitCut= Instantiate(CutFruit, collider.transform.position, Quaternion.identity);
                    
                    
                        GameController_30.instance.score += new Bettr_Encryption.Encrypt(10);
                        GameController_30.instance.Score_Encrypt = XOREncryption.encryptDecrypt(GameController_30.instance.Score_Encrypt);
                        GameController_30.instance.Score_Encrypt = (int.Parse(GameController_30.instance.Score_Encrypt) + 10).ToString();
                        GameController_30.instance.Score_Encrypt = XOREncryption.encryptDecrypt(GameController_30.instance.Score_Encrypt);
                        Destroy(FruitCut, 1f);

                    
                }

                else
                {
                    GameObject.FindObjectOfType<ImageEffect_30>().ApplyEffect();
                    GameController_30.instance.hit = 0;
                    // If hit to another knives
                    moving = false;
                    knifeRigid.bodyType = RigidbodyType2D.Dynamic;
                    GetComponent<AudioSource>().PlayOneShot(fail, 1f);

                    knifeRigid.AddTorque(500f);

                    scriptEnabled = false;
                    GetComponent<Knife_30>().enabled = false;


                        GameController_30.instance.lives = new Bettr_Encryption.Encrypt(int.Parse(GameController_30.instance.lives.ToString()) - 1);
                        GameController_30.instance.LIVES = XOREncryption.encryptDecrypt(GameController_30.instance.LIVES);
                        GameController_30.instance.LIVES = (int.Parse(GameController_30.instance.LIVES) - 1).ToString();
                        GameController_30.instance.LIVES = XOREncryption.encryptDecrypt(GameController_30.instance.LIVES);
                    



                }
            }
            
            
              

        }
    }

   
}
