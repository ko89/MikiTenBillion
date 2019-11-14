using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TintTiles : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer[] sprites;

    [SerializeField]
    private ParticleSystem heartParticleSys;

    [SerializeField]
    private Color inactiveColor;

    [SerializeField]
    private Color activeColor;

    [SerializeField]
    private float updateSpeed = 2f;

    [SerializeField]
    private CounterCtrl counterCtrl;

    [SerializeField]
    private GameObject mikiSprite;

    private int activeTile;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTiles", updateSpeed, updateSpeed);
    }

    // Update is called once per frame
    void Update()
    {
            

        
        
    }

    void UpdateTiles()
    {
        activeTile = Random.Range(0, sprites.Length - 1);

        for (int i = 0; i < sprites.Length; i++)
        {
            if(i == activeTile)
            {
                sprites[i].color = activeColor;
                mikiSprite.transform.position = new Vector3(sprites[i].transform.position.x, sprites[i].transform.position.y, mikiSprite.transform.position.z);
            }
            else
            {
                sprites[i].color = inactiveColor;
            }

        }
    }

    public void ApplyRuleToCounter()
    {
        int particleCount = 0;
        switch(activeTile)
        {
            case 0:
                // Add 314
                Debug.Log("Add 314314!");
                counterCtrl.CountUp(314314);
                particleCount = 31;
                break;
            case 1:
                // Multiply by 2
                Debug.Log("Multiply by 2");
                counterCtrl.CountUp(counterCtrl.Counter);
                particleCount = Mathf.FloorToInt(Mathf.Clamp(counterCtrl.Counter, 0, 100));
                break;
            case 2:
                // Subtract 314
                Debug.Log("Subtract 314314!");
                counterCtrl.CountDown(314314);
                break;
            case 3:
                // Divide by 2
                Debug.Log("Remove half!");
                counterCtrl.CountDown(counterCtrl.Counter / 2);
                break;
            case 4:
                // Add 999
                Debug.Log("Add 999999!");
                counterCtrl.CountUp(999999);
                particleCount = 100;
                break;
            case 5:
                // Subtract 999
                Debug.Log("Subtract 999999!");
                counterCtrl.CountDown(999999);
                break;
            case 6:
                // Multiply by 1.5
                Debug.Log("Add half!");
                counterCtrl.CountUp(counterCtrl.Counter / 2);
                particleCount = Mathf.FloorToInt(Mathf.Clamp(counterCtrl.Counter, 0, 100));
                break;
            case 7:
                // Multiply by 0.75
                Debug.Log("Remove quarter");
                counterCtrl.CountDown(counterCtrl.Counter / 4);
                break;
            case 8:
                // Reset Counter
                Debug.Log("Counter Reset!");
                counterCtrl.ResetCounter();
                break;
            default:
                break;

        }
        if(particleCount > 0)
        {
            heartParticleSys.Emit(particleCount);
        }
        

    }
}
