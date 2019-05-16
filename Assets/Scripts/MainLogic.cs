using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class MainLogic : MonoBehaviour
{
    public const float origin = 5;
    public float diffTime = 10, stayTime = 4;
    public GameObject gem;
    public List<HandRotation> HandRotations;
    public Text Gems, Score, Energy, Combo, ScoreFinal;
    public float speed = 0.1f;
    public int combo = 1;
    public PostProcessingProfile cc;
    public Canvas gameCanvas, endCanvas;

    private bool end = false;
    private Rigidbody rb;
    private int gems;
    private float time, score = 0, energy = 20;
    private GameObject clone;

    void Awake()
    {
        time = Time.time;
    }

    private void Start()
    {
        ColorGradingModel.Settings settings = cc.colorGrading.settings;
        print(settings.colorWheels.log.power.r);
        settings.colorWheels.log.power.r = 1f;
        cc.colorGrading.settings = settings;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!end)
        {
            score += 0.1f;
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, +90, 0);
            transform.rotation =
                Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            float now = Time.time;
            if (now - time > diffTime)
            {
                clone = Instantiate(gem, new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4)), Quaternion.identity);
                Destroy(clone, stayTime);
                time = now;
            }

            Energy.text = ((int) energy).ToString();
            Score.text = ((int) score).ToString();
            Gems.text = gems.ToString();
            if (combo > 1)
            {
                Combo.text = combo + "x";
            }
            else
            {
                Combo.text = "";
            }

            InputCheck();
        }
    }

    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (gems >= 5)
            {
                gems -= 5;
                StartCoroutine(GetNormal());
                diffTime /= 3;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (gems >= 3)
            {
                gems -= 3;
                SlowDown();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (gems >= 4)
            {
                gems -= 4;
                energy += 12;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Here");
            energy -= combo++;
            rb.velocity = new Vector3(0, 8f, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            energy -= 0.005f;
            transform.position += new Vector3(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            energy -= 0.005f;
            transform.position += new Vector3(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            energy -= 0.005f;
            transform.position += new Vector3(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            energy -= 0.005f;
            transform.position += new Vector3(-speed, 0f, 0f);
        }

        if (energy <= 0)
        {
            Debug.Log("End");
            end = true;
            foreach (HandRotation handRotation in HandRotations)
                handRotation.speed = 0f;
            gameCanvas.enabled = false;
            endCanvas.enabled = true;
            
            ScoreFinal.text = "Score: " + ((int) score).ToString();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Gem(Clone)")
        {
            gems++;
            Destroy(col.gameObject);
        }
        else
        {
            combo = 1;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Hand" || col.gameObject.name == "LittleHand")
        {
            Debug.Log("Hit");
            StartCoroutine(RedScreen());
            energy -= 5;
        }
    }

    private IEnumerator RedScreen()
    {
        ColorGradingModel.Settings settings = cc.colorGrading.settings;
        for (int i = 0; i < 10; i++)
        {
            settings.colorWheels.log.power.r++;
            cc.colorGrading.settings = settings;
            yield return new WaitForSeconds(0.007f);
        }
        
        for (int i = 0; i < 10; i++)
        {
            settings.colorWheels.log.power.r--;
            cc.colorGrading.settings = settings;
            yield return new WaitForSeconds(0.007f);
        }
    }

    void SlowDown()
    {
        diffTime *= 2;
        stayTime *= 2;
        foreach (HandRotation handRotation in HandRotations)
        {
            handRotation.speed /= 2;
            handRotation.mult = 0.5f;
        }

        StartCoroutine(GetFast());
    }

    private IEnumerator GetFast()
    {
        yield return new WaitForSeconds(7);
        diffTime /= 2;
        stayTime /= 2;
        foreach (HandRotation handRotation in HandRotations)
        {
            handRotation.speed *= 2;
            handRotation.mult = 1f;
        }
    }
    
    private IEnumerator GetNormal()
    {
        yield return new WaitForSeconds(7);
        diffTime = origin;
    }
}