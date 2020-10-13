using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform spawnPos;
    //public GameObject fireball;
    public bool stopspawning = false;
    public float spawnTime;
    public float spawnDelay;
    Timer timer = null;



    Spell spell;

    public List<Spell> spellList = new List<Spell>();

    Animator animator;
    [SerializeField] AnimationClip animation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("Shoot", spawnTime, spawnDelay);

        spell = (Spell)Resources.Load("Spells/" + gameObject.name, typeof(Spell));
        List<Spell> spellDataBase = GameObject.Find("RPGManager").GetComponent<RPGManager>().spellList;
        for (int i = 0; i < spellDataBase.Count; i++)
        {
            spellList.Add(spellDataBase[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer != null)
        {
            timer.Tick(Time.deltaTime);
        }

    }
    public void SpawnObject()
    {
        if (spell.spellPrefab == null)
        {
            Debug.LogWarning("Spell prefab is null");
        }
        else
        {
            GameObject spellObject = Instantiate(spell.spellPrefab, spawnPos.position , spawnPos.rotation); 
            spellObject.AddComponent<Rigidbody>();
            spellObject.GetComponent<Rigidbody>().useGravity = false;
            spellObject.GetComponent<Rigidbody>().velocity = spellObject.transform.forward * spell.ProjectileSpeed;
            spellObject.name = spell.spellName;
            spellObject.transform.parent = GameObject.Find("RPGManager").transform;

            Destroy(spellObject, 2);
        }
        if (stopspawning)
        {
            CancelInvoke("Shoot");
        }
        animator.SetBool("isShooting", false);

        timer = null;
    }

    public void Shoot()
    {
        if (timer == null)
        {
            timer = new Timer(animation.length - 0.5f, SpawnObject);
            animator.SetBool("isShooting", true);
        }
    }
}
