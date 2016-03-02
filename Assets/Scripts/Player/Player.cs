using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ShellShock
{
    public class Player : MonoBehaviour
    {
        public Weapon mEquippedWeapon;
        public Weapon[] weaponList;
        public int mPlayerNumber;


        public int PlayerNumber
        {
            get
            {
                return mPlayerNumber;
            }
        }

        public Slider HPSlider;
        public Slider ammoSlider;

        int mHealth;
        int mMaxHealth;

        int mSheildDamageReduction;

        public float waitTime;
        float mMaxSheildTime;
        float mRemainingSheidTime;
        Vector2 mReticlePosition;
        public ParticleSystem minigunParticleSystem;
        public GameObject playerHUD;

        public int playerScore;

        public Vector2 ReticlePosition
        {
            get
            {
                return mReticlePosition;
            }
        }

        public Pistol playerPistol;
        public GameObject[] playerSpawnPoints;
        public bool isPlayerDead = false;
        public float timeToRespawn = 3f;
        public float timeSpentDead = 0f;
        public int killingBulletID;
        public Text playerScoreText;



        void Awake()
        {
            playerSpawnPoints = GameObject.FindGameObjectsWithTag("RESPAWNPOINT");
        }
        void Start()
        {
            mReticlePosition = mEquippedWeapon.transform.position;
            mEquippedWeapon.transform.position = transform.position;
            mEquippedWeapon.transform.parent = transform;
            ammoSlider.maxValue = 1;
            ammoSlider.value = 1;

            mMaxHealth = 100;
            mHealth = mMaxHealth;
            playerScore = 0;
            playerScoreText.text = playerScore.ToString();
        }

        void Update()
        {
            playerScoreText.text = playerScore.ToString();


            if (isPlayerDead == true)
            {
                timeSpentDead += Time.deltaTime;
                if (timeSpentDead >= timeToRespawn)
                {
                    EnableAndShowPlayer();
                    isPlayerDead = false;
                    timeSpentDead = 0f;
                }
            }

            //if L3 is held, the HUD will appear
            //if (Input.GetButton("Player_" + mPlayerNumber + "_Back"))
            //{
            //    playerHUD.SetActive(true);
            //}
            //else
            //{
            //    playerHUD.SetActive(false);
            //}

            waitTime -= Time.deltaTime;
            if (mEquippedWeapon)
            {
                if (GetComponent<ShellShock.Aiming>().AimDirection.magnitude > 0.9)
                {   //if the fire button is pressed, fire the gun.
                    if (Input.GetButton("Player_" + mPlayerNumber + "_Fire1") && !isPlayerDead)
                    {
                        if (mEquippedWeapon.RemainingAmmo >= 0)
                        {
                            ammoSlider.value = (float)mEquippedWeapon.RemainingAmmo / (float)mEquippedWeapon.MaximumAmmo;
                        }
                        //emit the bullet casing particle system
                        minigunParticleSystem.Emit(1);

                        if (!mEquippedWeapon.Shoot(GetComponent<ShellShock.Aiming>().CorrectedAimDirection, mPlayerNumber))
                        {
                            mEquippedWeapon = null;
                        }
                    }
                }
            }
        }

        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "Projectile")
            {
                mHealth -= coll.gameObject.GetComponent<ShellShock.Projectile>().Damage;
                HPSlider.value = (float)mHealth / (float)mMaxHealth;
                if (mHealth <= mMaxHealth / 2)
                {
                    if (mHealth <= mMaxHealth / 4)
                    {
                        HPSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.red;//TODO:Make this not super hacky (possibly with a script on the slider that holds references)
                    }
                    else
                    {
                        HPSlider.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = Color.yellow;//TODO:Make this not super hacky (possibly with a script on the slider that holds references)
                    }
                }
                //if the player's health is 0, the player game object will be disabled.
                if (HPSlider.value == 0)
                {
                    //  gameObject.SetActive(false);
                    DisableAndHidePlayer();
                    Debug.Log("Player_" + mPlayerNumber + "  has died");
                    killingBulletID = coll.gameObject.GetComponent<ShellShock.Projectile>().OwnerID;
                    IncreaseKillersScore();
                    ResetPlayerProperties();
                    SetPlayerSpawnPosition();
                    StartRespawnTimer();


                }

                Debug.Log("Player_" + mPlayerNumber + " took damage from Player_" + coll.gameObject.GetComponent<ShellShock.Projectile>().OwnerID + "'s projectile");
                Destroy(coll.gameObject);
            }
        }

        public void IncreaseKillersScore()
        {
            Player[] players = FindObjectsOfType(typeof(Player)) as Player[];
            foreach (Player player in players)
            {
                if (player.mPlayerNumber == killingBulletID && killingBulletID != mPlayerNumber)
                {
                    player.playerScore++;
                }
                if (player.mPlayerNumber == killingBulletID && killingBulletID == mPlayerNumber)
                {
                    playerScore--;
                }
            }
        }

        public void ResetPlayerProperties()
        {
            //reset player's health
            mHealth = mMaxHealth;
            HPSlider.value = 1;
            ammoSlider.value = 1;
            //equip the player with a fully loaded pistol.
            mEquippedWeapon = playerPistol;
            mEquippedWeapon.RemainingAmmo = mEquippedWeapon.MaximumAmmo;

        }
        public void SetPlayerSpawnPosition()
        {
            //sets the player's position to a random spawn point.
            gameObject.transform.position = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length)].transform.position;
        }
        public void StartRespawnTimer()
        {
            isPlayerDead = true;
        }
        public void DisableAndHidePlayer()
        {
            gameObject.GetComponent<ShellShock.Movement>().enabled = false;
            gameObject.GetComponent<ShellShock.MovementISO>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<ShellShock.Aiming>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<ShellShock.PlayerActions>().enabled = false;
            //disabling Reticle Game object
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

        }
        public void EnableAndShowPlayer()
        {
            gameObject.GetComponent<ShellShock.Movement>().enabled = true;
            gameObject.GetComponent<ShellShock.MovementISO>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<ShellShock.Aiming>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<ShellShock.PlayerActions>().enabled = true;
            //enabling Reticle Game object
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }


        public void ChangeWeapon(int weaponNumber)
        {

            Instantiate(mEquippedWeapon, new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z), Quaternion.identity);
            //create a clone of the previous weapon just under the player
            //Destroy(InstantiatedWeapon, 3.0f);
            mEquippedWeapon = weaponList[weaponNumber];
            mEquippedWeapon.transform.position = transform.position;
            weaponList[weaponNumber].transform.SetParent(transform);
        }
    }
}
