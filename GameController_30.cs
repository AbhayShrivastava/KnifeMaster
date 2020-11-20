
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController_30 : MonoBehaviour 
{
    #region Public Variables
    //for GQ LEVELS

    public int Levels = 0;
    #region ForTesting Purposes
    public Button Nextbutton;
    public Button Startbutton;
    public Text LevelText;
    public SpawnController_30 SpawnScript;
    #endregion


    //for speed meter
    public Image SpeedMeter;
    public int hit;
    float timer = 1f;
    public bool PowerMode = false;
    bool poweron = false;
     public int power = 0;
    public Text BonusText;

    public bool IsLevelChanging = false;

    //forEncryption
    public string Score_Encrypt;
    public Bettr_Encryption.Encrypt score;

    //forRandomBackground change every time gamestarts
    public GameObject BgChange;
    public Sprite[] bgSPrite;

    //UI
    //score
    public Text ScoreText;
    //knives to be hit & lives
    public RectTransform ToHit;
    public RectTransform Lives;
    public Bettr_Encryption.Encrypt KnifesToHit;
    public string KNIVES_HIT;
    public Bettr_Encryption.Encrypt lives;
    public string LIVES;
   
    //for trunk
    public bool spawned = false;
    //forknife
    public bool KnifeSpawned=false;
    

    public static GameController_30 instance;
  
    //Gameover
    public GameObject gameOver;
	public bool isGameover = false;

    //enum for different  stages
    public GameState_30 Stages = GameState_30.Stage1;
    public int GameLevels = 1;
    public enum GameState_30
    {
      
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Animation,
        BossStage,
        AnimationEnd
    }
    #endregion

    

    //instance created
    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }
   

    private void Start()
    {

        SpawnScript.gameObject.SetActive(false);

        Physics2D.gravity = new Vector2(0, -40f);
        Application.targetFrameRate = 60;

        //BG spritechange  
        BgChange.GetComponent<SpriteRenderer>().sprite = bgSPrite[Random.Range(0, bgSPrite.Length - 1)];

        
        score = new Bettr_Encryption.Encrypt(0);
        Score_Encrypt = "0";
        Score_Encrypt = XOREncryption.encryptDecrypt(Score_Encrypt);



        LevelInformation();

    }




    void Update () 
    {
        LevelText.text = Levels.ToString();
        ScoreText.text = score.ToString();
       


        for (int i = 0; i < int.Parse(KnifesToHit.ToString()); i++)
        {
            ToHit.transform.GetChild(i).gameObject.SetActive(true);  
        }
        for (int j = int.Parse(KnifesToHit.ToString()); j < ToHit.transform.childCount-1; j++)
        {
            ToHit.transform.GetChild(j).gameObject.SetActive(false);
        }


        if (Levels == 0)
        {
             if (int.Parse(lives.ToString()) < 4)
                    Lives.GetChild(int.Parse(lives.ToString())).GetComponent<Image>().color = Color.red;
                if (int.Parse(lives.ToString()) == 4)
                    foreach (Transform t in Lives.transform)
                        t.GetComponent<Image>().color = Color.white; ;
          
        }
        else if (Levels > 0 && Levels < 4)
        {
            
                Lives.GetChild(Lives.childCount - 1).gameObject.SetActive(false);
                if (int.Parse(lives.ToString()) < 3)
                    Lives.GetChild(int.Parse(lives.ToString())).GetComponent<Image>().color = Color.red;
                if (int.Parse(lives.ToString()) == 3)
                    foreach (Transform t in Lives.transform)
                        t.GetComponent<Image>().color = Color.white;
            
        }
        else if (Levels == 4)
        {
                Lives.GetChild(Lives.childCount - 1).gameObject.SetActive(false);
                Lives.GetChild(Lives.childCount - 2).gameObject.SetActive(false);
                if (int.Parse(lives.ToString()) < 2)
                    Lives.GetChild(int.Parse(lives.ToString())).GetComponent<Image>().color = Color.red;
                if (int.Parse(lives.ToString()) == 2)
                    foreach (Transform t in Lives.transform)
                        t.GetComponent<Image>().color = Color.white; ;
            

        }
        


        if (int.Parse(lives.ToString()) == 0)
            GAMEOVER();

      

        if (hit  >0)
        {
            timer -= Time.deltaTime;

            if (SpeedMeter.fillAmount == 1)
            {
               
                PowerMode = true;
                poweron = true;


            }
            else
            {
                if(!PowerMode)
                SpeedMeter.fillAmount = hit * 0.2f;
            }
        }
        else
        {
            
            timer = 1f;
            if (!PowerMode&&!IsLevelChanging)
                SpeedMeter.fillAmount -= Time.deltaTime * 0.7f;
        }
      
        if(timer<0)
        {
            hit = 0;
            timer = 1f;
         
        }
        if(PowerMode)
        {
            BonusText.gameObject.SetActive(true);
           BonusText.text = (power + 2).ToString() + "X";
            StartCoroutine(PowerUp());
          
         

        }
        else
        {
            BonusText.gameObject.SetActive(false);
            StopCoroutine(PowerUp());
            
        }

        if (SpeedMeter.fillAmount == 0)
        {

            PowerMode = false;

            
               
            if(poweron)
            {

                power++;
                poweron = false;
            }

        }





    }
    
    #region PowerUP
    IEnumerator PowerUp()
    {
      

        yield return new WaitForSeconds(1f);
        if(!IsLevelChanging)
        SpeedMeter.fillAmount -= Time.deltaTime * 0.1f;
       
       
       


       
    }




    #endregion



    #region GQ
    void LevelInformation()
    {

        if(Levels==0)
        {
            //lives will be 4
            lives = new Bettr_Encryption.Encrypt(4);
            LIVES = "4";
            LIVES = XOREncryption.encryptDecrypt(LIVES);
        }
        else if (Levels==1)
        {
            //lives will be 3

            lives = new Bettr_Encryption.Encrypt(3);
            LIVES = "3";
            LIVES = XOREncryption.encryptDecrypt(LIVES);
        }
        else if(Levels==2)
        {
           //lives will be 3
            lives = new Bettr_Encryption.Encrypt(3);
            LIVES = "3";
            LIVES = XOREncryption.encryptDecrypt(LIVES);

        }
        else if(Levels==3)
        {
            //lives will be 3
            lives = new Bettr_Encryption.Encrypt(3);
            LIVES = "3";
            LIVES = XOREncryption.encryptDecrypt(LIVES);


        }
        else if(Levels==4)
        {
            //lives will be 2
            lives = new Bettr_Encryption.Encrypt(2);
            LIVES = "2";
            LIVES = XOREncryption.encryptDecrypt(LIVES);


        }




    }
    #endregion


    #region TestButtons

    public void StartButton()
    {
        SpawnScript.gameObject.SetActive(true);
        Startbutton.gameObject.SetActive(false);
        Nextbutton.gameObject.SetActive(false);
        LevelText.gameObject.SetActive(false);

        LevelInformation();

    }
    public void NextButton()
    {
        if(Levels<5)
        Levels++;

    }

    #endregion

    




    public void GAMEOVER()
    {
		isGameover = true;
        gameOver.SetActive(true);
      
    }

}
