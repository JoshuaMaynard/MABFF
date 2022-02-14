using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Initial coding by Joseph Arends
public class PlayerControls : MonoBehaviour
{
    /// <summary>
    /// These are the controls for:
    /// the player attacking with guns and mutations,
    /// the player switching between guns and mutations
    /// the player changing with varying values
    /// </summary>
    /// 
    
    public float currentInfectionLevel;
    public float maxInfectionLevel;

    public float currentHealth;
    public float maxHealth;

    public Image healthBar;
    public Image infectionBar;

    public float luck;

    public GameObject[] anArrayOfGuns;

    // Melee attacks are classified as mutations
    public GameObject[] anArrayOfMutations;

    // All other mutations are classified as passives
    public GameObject[] anArrayOfPassives;
    public List<GameObject> aListOfPassives = new List<GameObject>();

    public GameObject[] anArrayOfUtilities;

    public int gunChoice;
    public int mutationChoice;

    public bool isInvincible;
    [SerializeField]
    private float invincibilityDurationSeconds;

    [SerializeField]
    private float invincibilityDeltaTime;

    private GameObject MutationSelection;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        MutationSelection = GameObject.Find("Mutation List");
        gunChoice = 0;
        mutationChoice = 0;

        ChangeGun(gunChoice);
        ChangeMutation(mutationChoice);
        UpdateInfectionBar();
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        // This swaps mutations in game in a forward fashion
        if (Input.GetKeyDown(KeyCode.E))
        {
            mutationChoice++;

            if (mutationChoice >= anArrayOfMutations.Length)
            {
                mutationChoice = 0;
            }
            ChangeMutation(mutationChoice);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            gunChoice++;

            if (gunChoice >= anArrayOfGuns.Length)
            {
                gunChoice = 0;
            }
            ChangeGun(gunChoice);
        }
    }

    public void ChangeMutation(int choice)
    {
        for (int i = 0; i < anArrayOfMutations.Length; i++)
        {
            if (i == choice)
                anArrayOfMutations[i].gameObject.SetActive(true);
            else
                anArrayOfMutations[i].gameObject.SetActive(false);
        }
    }

    public void ChangeGun(int choice)
    {
        for (int i = 0; i < anArrayOfGuns.Length; i++)
        {
            if (i == choice)
                anArrayOfGuns[i].gameObject.SetActive(true);
            else
                anArrayOfGuns[i].gameObject.SetActive(false);
        }
    }

    public void ChangeInfection(float infection)
    {
        currentInfectionLevel += infection;
        if (currentInfectionLevel >= maxInfectionLevel)
        {
            LevelUp();
        }
        UpdateInfectionBar();
    }

    public void LevelUp()
    {
        Debug.Log("Level up");
        currentInfectionLevel = currentInfectionLevel - maxInfectionLevel;
        maxInfectionLevel = maxInfectionLevel + maxInfectionLevel / 1.5f;
        maxInfectionLevel = Mathf.Round(maxInfectionLevel);

        
        int choice = Random.Range(0, MutationSelection.GetComponent<MutationSelection>().aListOfTierOnePassives.Count);
        Debug.Log(choice);
        aListOfPassives.Add(MutationSelection.GetComponent<MutationSelection>().aListOfTierOnePassives[choice]);
        MutationSelection.GetComponent<MutationSelection>().aListOfTierOnePassives.RemoveAt(choice);
        int last = aListOfPassives.Count - 1;
        Debug.Log(last);
        aListOfPassives[last].GetComponent<PassiveEffect>().ApplyPassive();
        //maxHealth += 25;
        UpdateHealthBar();
        //anim.SetBool(aListOfPassives[0].GetComponent<PassiveEffect>().boolName, true);

    }

    

    public void UpdateInfectionBar()
    {
        infectionBar.fillAmount = Mathf.Clamp(currentInfectionLevel / maxInfectionLevel, 0, 1f);
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            GetComponent<Rigidbody2D>().AddForce(transform.up * 500 + transform.right * 500);
            UpdateHealthBar();
            StartCoroutine(BecomeTemporarilyInvincible());
        }
        

    }

    private IEnumerator BecomeTemporarilyInvincible()
    {

        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            // TODO: add any logic we want here
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        isInvincible = false;
    }

    public void UpdateHealthBar()
    {
        Debug.Log("changed");
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1f);
    }
}
