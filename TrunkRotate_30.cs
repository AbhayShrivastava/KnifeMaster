
using UnityEngine;
using System.Collections;

public class TrunkRotate_30 : MonoBehaviour
{

    float speed = 0f;
    public float maxspeed;
    int R;


    float timer;


    // Use this for initialization
    void Start()
    {
        if (GameController_30.instance.GameLevels >5)
        {
            R = Random.Range(1, 5);  
            timer = Random.Range(-4f, 4f);


            if (timer > 0)
                speed = maxspeed;
            else
                speed = maxspeed / 2;
        }

    }


    private void Update()
    {
       if (GameController_30.instance.GameLevels > 4)
        {
            if (R > 3)
            {
                //clockwise
                timer -= Time.deltaTime;

                transform.Rotate(new Vector3(0, 0, -speed));


                if (timer > 0)
                {

                    speed -= Mathf.Lerp(0, maxspeed, 0.3f * Time.deltaTime);


                }


                else
                {


                    if (speed < maxspeed)
                    {

                        speed += Mathf.Lerp(0, maxspeed, 0.3f * Time.deltaTime);
                    }
                    else
                    {

                        timer = Random.Range(3f, 6f);

                    }
                }



            }
            else
            {
                //anticlockwise
                timer -= Time.deltaTime;

                transform.Rotate(new Vector3(0, 0, speed));


                if (timer > 0)
                {


                    speed -= Mathf.Lerp(0, maxspeed, 0.3f * Time.deltaTime);



                }


                else
                {


                    if (speed < maxspeed)
                    {

                        speed += Mathf.Lerp(0, maxspeed, 0.3f * Time.deltaTime);
                    }
                    else
                    {

                        timer = Random.Range(3f, 6f);

                    }
                }

            }

        }


        else
        {
            transform.Rotate(new Vector3(0, 0, maxspeed));
        }
        }

    }












    

   



