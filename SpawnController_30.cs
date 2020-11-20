
using UnityEngine;

public class SpawnController_30 : MonoBehaviour {

    public GameObject [] knife;

    public GameObject[] Trunk;

    public GameObject [] BonusTrunk;

    int R;

    public GameObject StartBoss;

    public GameObject EndBoss;


    private Animation StartBossAnim;
    private Animation EndBossAnim;



    public AudioSource BossStart;
    public AudioSource BossEnd;
 

   
    

   

    // Use this for initialization
    void Start () 
    {
      

        StartBossAnim = StartBoss.GetComponent<Animation>();
        EndBossAnim = EndBoss.GetComponent<Animation>();


        R = Random.Range(0, knife.Length-1);
        
        CreateTrunk();
        CreateKnife();
    }

    // Update is called once per frame

    private void Update()
    {

        if (GameController_30.instance.isGameover)
            return;

        if (GameController_30.instance.spawned)
        {
            CreateTrunk();
            
        }
        if (GameController_30.instance.KnifeSpawned && int.Parse(GameController_30.instance.lives.ToString())>0 && int.Parse(GameController_30.instance.KnifesToHit.ToString())>0)
        {

            CreateKnife();
        }

      


    }



    public void CreateKnife()
    {
        // Create knife if Trunk is alive!
        //if (GameObject.FindGameObjectWithTag("TAG_1").GetComponent<TrunkHealth>().health>0)
        //{
        
        
        //abhay

        //changes
       
            Instantiate(knife[R], transform.position, Quaternion.identity);
            GameController_30.instance.KnifeSpawned = false;
        
        //}
    }

    public void CreateTrunk()
    {
        if (GameController_30.instance.Stages == GameController_30.GameState_30.Stage1)
        {

          
              

            //Create trunk 
            Instantiate(Trunk[0], new Vector2(0, 2), Quaternion.identity);
            GameController_30.instance.spawned = false;
        }
        else if (GameController_30.instance.Stages == GameController_30.GameState_30.Stage2)
        {
            if (GameController_30.instance.GameLevels>5)
            {
                GameController_30.instance.IsLevelChanging = false;
                EndBossAnim.Stop();
                GameObject GO = Instantiate(Trunk[4], new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
                GO.tag = "TAG_5";

            }
            else
            {

                Instantiate(Trunk[1], new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
            }
        }
        else if (GameController_30.instance.Stages == GameController_30.GameState_30.Stage3)
        {
            if (GameController_30.instance.GameLevels > 5)
            {
                GameObject GO = Instantiate(Trunk[4], new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
                GO.tag = "TAG_5";

            }
            else
            {

                Instantiate(Trunk[2],new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
            }
        }
        else if(GameController_30.instance.Stages==GameController_30.GameState_30.Stage4)
        {
            if (GameController_30.instance.GameLevels > 5)
            {
                GameObject GO = Instantiate(Trunk[4], new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
                GO.tag = "TAG_5";

            }
            else
            {

                Instantiate(Trunk[3], new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
            }
        }
        else if(GameController_30.instance.Stages==GameController_30.GameState_30.Animation)
        {
            if (!BossStart.isPlaying)
                BossStart.Play();
            if(!StartBossAnim.isPlaying)
            StartBossAnim.Play();
            GameController_30.instance.IsLevelChanging = true;
            
        }
        else if(GameController_30.instance.Stages==GameController_30.GameState_30.BossStage)
        {
           


            StartBossAnim.Stop();


            GameController_30.instance.IsLevelChanging = false;
                GameObject Go = Instantiate(BonusTrunk[Random.Range(0, BonusTrunk.Length - 1)], new Vector2(0, 2), Quaternion.identity);
                GameController_30.instance.spawned = false;
         
                Go.tag = "TAG_5";
           

            
        }
        else if(GameController_30.instance.Stages==GameController_30.GameState_30.AnimationEnd)
        {
            
            if(!EndBossAnim.isPlaying)
            EndBossAnim.Play();
            if (!BossEnd.isPlaying)
                BossEnd.Play();
            //Lives in each  different LEVELS
            switch(GameController_30.instance.Levels)
            {
                //fill all knives in level :0
                case 0:
                    GameController_30.instance.lives = new Bettr_Encryption.Encrypt(4);
                    break;
                    //Fill 2 Knives in  level :1
                case 1:
                    if (int.Parse(GameController_30.instance.lives.ToString()) == 1)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(2);
                    else if (int.Parse(GameController_30.instance.lives.ToString()) == 2)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(1);
                    else if (int.Parse(GameController_30.instance.lives.ToString()) == 3)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(0);
                    break;
                //Fill 1 Knives in  level :2
                case 2:
                    if (int.Parse(GameController_30.instance.lives.ToString()) == 1)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(1);
                    else if (int.Parse(GameController_30.instance.lives.ToString()) == 2)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(1);
                    else if (int.Parse(GameController_30.instance.lives.ToString()) == 3)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(0);

                    break;
                case 3:
                    //Fill 1 Knives in  level :3
                    if (int.Parse(GameController_30.instance.lives.ToString()) == 1)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(1);
                    else if (int.Parse(GameController_30.instance.lives.ToString()) == 2)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(1);
                    else if (int.Parse(GameController_30.instance.lives.ToString()) == 3)
                        GameController_30.instance.lives += new Bettr_Encryption.Encrypt(0);
                    break;

            }
           

        }
        
        

    }
    


}
