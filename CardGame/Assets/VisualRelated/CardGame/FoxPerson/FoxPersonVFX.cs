using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Plan 
Main: Heal two player character
1. YEllow circle from the bottom of the card?, and some effects growing out
Passive:take random enemy(1) hp, distribute it to one of the teammate(more aggressive)
1.
Note:
- need to add first row enemy into the enemy list
*/
public class FoxPersonVFX : VFXBase
{
    
    [Header("Detect")]
    public List<GameObject> enemy = new List<GameObject>();
    public List<GameObject> gdPt = new List<GameObject>();
    [Header("OBJ")]
    public GameObject foxGroundPt; //plz create a ground pt for all cards
    [SerializeField]private GameObject foxMagicCircle;
    [SerializeField]private GameObject otherMagicCircle;
    [SerializeField]private GameObject enemyMagicCircle;
    public GameObject healPt; //the ball prefab
    private GameObject theEnemy; //passive
    private GameObject target; 
    [SerializeField] private GameObject effectCircle;
    Animator ec;
    // public GameObject theCharacter; //passive

    [Header("Values")]
    [SerializeField]private int effectPos = 0; //0
    [SerializeField]private float force; //up Dip force
    [SerializeField]private float shootSpeed;

    int r1, r2;  
    bool move = false; 
    
    void Start()
    { 
        ec = effectCircle.GetComponent<Animator>();
    }
    // public void DetectEnemy(GameObject enemy1, GameObject enemy2){ //get first row enemy
    //     firstEnemy = enemy1;
    //     secondEnemy = enemy2;
    // }
    void Update()
    {
        //Dev shit
        
//---------------------------------
        switch(currentState){
            case AbilityState.MAIN:  //Main
                ec.SetTrigger("Main");
            break;
            case AbilityState.PASSIVE: 
                ec.SetTrigger("Passive");
            break;
        }
         if(this.gameObject.GetComponent<PlayerSkill>().isOnAttack1||this.gameObject.GetComponent<PlayerSkill>().isOnAttack2){
            ec.SetBool("Main", true);
            ec.SetBool("Passive", false);
        }else if(this.gameObject.GetComponent<PlayerSkill>().isOnPassive1||this.gameObject.GetComponent<PlayerSkill>().isOnPassive2){
            ec.SetBool("Passive", true);
            ec.SetBool("Main", false);
        }
    }
    
    public IEnumerator Attack(GameObject player){
        yield return new WaitForSeconds(0);
        if(currentState == AbilityState.MAIN){
            //DetectPlayerGdPt();
            MagicCircleCreate(foxMagicCircle, foxGroundPt,5.5f);
            //Debug.Log("hi");//issue: why so many instanciated
            yield return new WaitForSeconds(.5f);
            MagicCircleCreate(otherMagicCircle, gdPt[0],4.5f);
            MagicCircleCreate(otherMagicCircle, gdPt[1],4.5f);
            yield return new WaitForSeconds(1f);
            ResetAttack(player);
        }else if(currentState == AbilityState.PASSIVE){
            DetectEnemyGdPt();
            RandomPlayer(1);
            MagicCircleCreate(foxMagicCircle, foxGroundPt,3f);
            yield return new WaitForSeconds(.5f);
            MagicCircleCreate(enemyMagicCircle, gdPt[0],2f);
            yield return new WaitForSeconds(.5f);
            GameObject h = Instantiate(healPt, theEnemy.transform.position, Quaternion.identity);
            var sc = h.GetComponent<HealPt>();
            sc._shootSpeed = shootSpeed;
            sc._force = force;
            sc.target = target;
             yield return new WaitForSeconds(0.5f);
            ResetAttack(player);

        }
    }
    public void MagicCircleCreate(GameObject prefab, GameObject target, float deathTime){
        GameObject s = Instantiate(prefab, target.transform.position, Quaternion.identity);
        var sc = s.GetComponent<MagicCircle>();
        sc._deathTime = deathTime;
    }
    void DetectEnemyGdPt(){ //get random 1 enemy groundpt
        //if(enemy.Count>0){ //put it in a way that it reassign new enemy's efect
        int r = Random.Range(0,enemy.Count);
        gdPt.Add(enemy[r].transform.GetChild(effectPos).gameObject);
        theEnemy = enemy[r];
       // }
    }
    
    void DetectPlayerGdPt(){ //get random two player character gdpt
        if(playerCharacter.Count>0){ //put it in a way that it reassign new enemy's efect
            List<int> number = new List<int>();
            for(int i = 0; i<=playerCharacter.Count-1;i++){
                number.Add(i);
            }
            int r1 = Random.Range(0,number.Count);
            for(int i = 0; i<=number.Count;i++){
                if(number[i] == r1){
                    number.Remove(number[i]);
                    break;
                }
            }
            int randomPos = Random.Range(0,number.Count);
            int r2 = number[randomPos];
            gdPt.Add(playerCharacter[r1].transform.GetChild(effectPos).gameObject);
            gdPt.Add(playerCharacter[r2].transform.GetChild(effectPos).gameObject);
        }
    }
    public override void ResetAttack(GameObject player){
        Debug.Log("reset time");
        gdPt.Clear();
        gdPt.TrimExcess();
        enemy.Clear();
        enemy.TrimExcess();
        player.GetComponent<PlayerBase>().isAttacking = false;
        //playerCharacter
    }
}
