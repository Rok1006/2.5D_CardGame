using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VFXBase : MonoBehaviour
{
    
    protected List<GameObject> enemy = new List<GameObject>();
    protected List<GameObject> gdPt = new List<GameObject>();
    public List<GameObject> target = new List<GameObject>();

    public enum AbilityState { MAIN, PASSIVE };
    public AbilityState currentState = AbilityState.MAIN;
    public static List<GameObject> playerCharacter = new List<GameObject>();
    public GameObject host;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This class should contain all the helper method that you need for VFX stuff
    
    
    
    public static List<GameObject> RandomPlayer(int amount)
    {
        //returns certain amount of player gameobject
        var temp = new List<GameObject>();
        for(int i = 0; i < playerCharacter.Count; i++)
        {
            temp.Add(playerCharacter[i]);
        }
        var list = new List<GameObject>();
        if (playerCharacter.Count > 0)
        { //put it in a way that it reassign new enemy's efect
            for(int i = 0; i < amount; i++)
            {
                var random = Random.Range(0, playerCharacter.Count);
                list.Add(temp[Random.Range(0,random)]);
                temp.RemoveAt(random);

            }
        }

        return list;

    }

    public static List<GameObject> DetectPlayerGroundPoint(int amount)
    {
        List<GameObject> list = new List<GameObject>();
        var temp = RandomPlayer(amount);
        if(playerCharacter.Count > 0)
        {
            for(int i = 0; i < amount; i++)
            {
                
            }
        }
        return null;
    }

    public virtual void ResetAttack(GameObject player)
    {

    }
    public abstract IEnumerator Attack(GameObject player);
    
}
