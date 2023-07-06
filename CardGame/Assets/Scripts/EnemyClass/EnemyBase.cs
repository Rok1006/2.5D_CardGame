using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
public abstract class EnemyBase : MonoBehaviour
{

    public delegate void onMoveComplete();
    public event onMoveComplete moveComplete;

    public CardInfo cardInfo;
    public SpriteRenderer enemySprite;
    public int health;

    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI attack;
    public List<EnemyMovement> movementPattern;

    public Grid grid;
    private Vector3 position;
    public Vector3 Position { get { return position; } set { position = value; } }
    public abstract Task Move();
    public abstract Task Attack();
    public abstract List<Vector3> EvaluateDestination();

    public abstract void MoveComplete();

    

    
    

    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Config();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    void Config()
    {
        enemySprite.sprite = cardInfo.cardImage;
        health = Random.Range(cardInfo.minHp, cardInfo.maxHp + 1);
        enemyName.text = cardInfo.name.ToString();
        attack.text = this.health.ToString();
    }
}
