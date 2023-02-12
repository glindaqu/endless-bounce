using UnityEngine;
using UnityEngine.UI;

public class Bounce : MonoBehaviour
{
    //speed of boll
    public float speed = 500;

    //word timer
    private float totalTime = 0;

    //player
    [SerializeField] public GameObject player;

    //timer text
    [SerializeField] public Text tTime;
    //game over component
    [SerializeField] public Text over;

    //game over txt animation
    [SerializeField] public Animator textAnim;
    //game over btn animation
    [SerializeField] public Animator buttonAnim;

    //coins text
    [SerializeField] public Text coins;
    //coins text
    [SerializeField] public Text bestScore;
    //restart button
    [SerializeField] public Button restart;
    //menu button
    [SerializeField] public Button menu;

    //rb2d
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bestScore.text = "BEST: " + PlayerPrefs.GetInt("score");
    }

    private void Start()
    {
        Invoke(nameof(setRandomVector), 1f);
        moneyUpdate();
    }

    //check collision between boll and walls
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("dead"))
        {
            this.gameObject.SetActive(false);
            coins.gameObject.SetActive(false);
            tTime.gameObject.SetActive(false);
            bestScore.gameObject.SetActive(false);
            player.SetActive(false);


            restart.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);

            textAnim.GetComponent<Animator>().SetTrigger("IsDead");
            buttonAnim.GetComponent<Animator>().SetTrigger("IsDead");
            menu.GetComponent<Animator>().SetTrigger("IsDead");

            int money = (int)totalTime;

            if ((int)totalTime > PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("score", (int)totalTime);
            }

            over.text = $"GAME OVER\nyou got {money} coins";
            moneyUpdate(money);
        }
    }

    private void setRandomVector()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1, 1);
        force.y = -1;

        this.rb.AddForce(force.normalized * speed);
    }

    //update money, when it needs
    private void moneyUpdate(int money = 0)
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + money);
        coins.text = "COINS: " + PlayerPrefs.GetInt("money").ToString();
    }

    private void Update()
    {
        totalTime += Time.deltaTime;
        tTime.text = "TIME: " + ((int)totalTime).ToString();

        bestScore.text = (int)totalTime > PlayerPrefs.GetInt("score") ? "BEST: " + ((int)totalTime).ToString() 
            : "BEST: " + PlayerPrefs.GetInt("score").ToString();
    }
}
