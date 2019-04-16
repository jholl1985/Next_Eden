//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public class Machi_Drone : MonoBehaviour, IEnemies
//{

//    public LayerMask aggroLayerMask;
//    public float currentHealth;
//    public float maxHealth;
//    public int ID { get; set; }
//    public int Experience { get; set; }
//    public DropTable DropTable { get; set; }
//    public Spawner Spawner { get; set; }
//    public PickupItem pickupItem;

//    //private Player player;
//    private UnityEngine.AI.NavMeshAgent navAgent;
//    private CharacterStats characterStats;
//    private Collider[] withinAggroColliders;
    

//    void Start()
//    {
//        DropTable = new DropTable();
//        //DropTable.loot = new List<LootDrop>
//        //{
//        //    new LootDrop("Gun", 10),
//        //    new LootDrop("Rifle", 20),
//        //    new LootDrop("Sniper", 40),
//        //};
//        ID = 0;
//        Experience = 25;
//        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
//        //characterStats = new CharacterStats(6, 10, 2);
//        currentHealth = maxHealth;
//    }

//   void FixedUpdate()
//    {

//    }
//}
