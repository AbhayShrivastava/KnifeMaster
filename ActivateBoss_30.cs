using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBoss_30 : MonoBehaviour {



  

    public void activateBoss() {

        GameController_30.instance.IsLevelChanging = true;
        GameController_30.instance.Stages = GameController_30.GameState_30.BossStage;
         

    }


    public void End()
    {
        GameController_30.instance.IsLevelChanging = false;
        GameController_30.instance.Stages = GameController_30.GameState_30.Stage2;


    }

    }
