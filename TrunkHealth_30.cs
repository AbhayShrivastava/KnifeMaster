using System.Collections;

using UnityEngine;



public class TrunkHealth_30 : MonoBehaviour {

    public int health = 5;
    public AudioClip breakClip;
    public AudioClip startClip;

   
  
    void Start()
    {

        if (tag == "TAG_5")
        {
            int index = Random.Range(5, transform.childCount);

            for (int i = index; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }


        }

        GameController_30.instance.KNIVES_HIT ="0";
        GameController_30.instance.KNIVES_HIT = XOREncryption.encryptDecrypt(GameController_30.instance.KNIVES_HIT);
        GetComponent<AudioSource>().PlayOneShot(startClip);
        GameController_30.instance.KnifesToHit = new Bettr_Encryption.Encrypt(health);
        GameController_30.instance.KNIVES_HIT = XOREncryption.encryptDecrypt(GameController_30.instance.KNIVES_HIT);
        GameController_30.instance.KNIVES_HIT = (int.Parse(GameController_30.instance.KNIVES_HIT) + health).ToString();
        GameController_30.instance.KNIVES_HIT = XOREncryption.encryptDecrypt(GameController_30.instance.KNIVES_HIT);

        
      

    }



    // Decrease health
    public void Damage(int value)
    {
        health -= value;
        GameController_30.instance.KnifesToHit = new Bettr_Encryption.Encrypt(int.Parse(GameController_30.instance.KnifesToHit.ToString())-value);
        GameController_30.instance.KNIVES_HIT = XOREncryption.encryptDecrypt(GameController_30.instance.KNIVES_HIT);
        GameController_30.instance.KNIVES_HIT = (int.Parse(GameController_30.instance.KNIVES_HIT) -value).ToString();
        GameController_30.instance.KNIVES_HIT = XOREncryption.encryptDecrypt(GameController_30.instance.KNIVES_HIT);



        if (health == 0) // If there is no health
        {
            

            // Deactive Trunk collider
            GetComponent<CircleCollider2D>().enabled = false;

            // Trunk fragmentation
            // Fragmention 1
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            //abhay
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(400, 900, 0);
            
            

            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(100, 100, 100);
            transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
            transform.GetChild(0).parent = null;
            // Fragmention 2
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;


            //abhay
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(-400, 900, 0);
         
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-100, 100, 100);
            transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
            transform.GetChild(0).parent = null;
            // Fragmention 3
            transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
            //abhay
            transform.GetChild(0).GetComponent<Rigidbody>().AddForce(0, 900, 0);
            transform.GetChild(0).GetComponent<Rigidbody>().AddTorque(-200, 100, -100);
          transform.GetChild(0).gameObject.AddComponent<BoxCollider>();
            transform.GetChild(0).parent = null;

            while (transform.childCount > 0)
            {
                // Knives apart from Trunk
                if (transform.GetChild(0).GetComponent<Rigidbody2D>() != null)
                {
                    transform.GetChild(0).GetComponent<Rigidbody2D>().isKinematic = false;

                    transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400f, 400f), Random.Range(400f, 600f)));                                         //abhay
                    transform.GetChild(0).GetComponent<Rigidbody2D>().AddTorque(Random.Range(-400, 400));
                    //abhay
                    transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale = 1.5f;
                }
                //abhay
                if (transform.GetChild(0).GetComponentInChildren<BoxCollider2D>() != null)
                    Destroy(transform.GetChild(0).GetComponentInChildren<BoxCollider2D>());
                if (transform.GetChild(0).GetComponentInChildren<PolygonCollider2D>() != null)
                    Destroy(transform.GetChild(0).GetComponentInChildren<PolygonCollider2D>());



                transform.GetChild(0).gameObject.AddComponent<BoxCollider2D>();
              



                transform.GetChild(0).parent = null;
            }

            GetComponent<AudioSource>().PlayOneShot(breakClip);
            GameController_30.instance.IsLevelChanging = true;
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        // Go to next level after 2 seconds
        yield return new WaitForSeconds(1.3f);
        GameController_30.instance.Stages++;
        GameController_30.instance.GameLevels++;
        GameController_30.instance.spawned=true;
        if (GameController_30.instance.Stages != GameController_30.GameState_30.AnimationEnd)
        {
            GameController_30.instance.IsLevelChanging = false;
        }
        Destroy(gameObject);
        

    }
   
}
