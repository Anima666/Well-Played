using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveheroes : MonoBehaviour {


     Vector3 start_pos;
     bool may_pos = true;


    private Ray ray;
    public Camera _camera;
    private RaycastHit hit;
    bool check_press = false;

    private Vector3 mousePosition;
    GameObject btn;
    void Start ()
    {
        GameObject next_btn = GameObject.FindGameObjectWithTag("next_card");
        start_pos = new Vector3( transform.position.x, transform.position.y,transform.position.z);
        btn = next_btn.GetComponent<choice_hero>().btn_next;

    }
    Collider2D col;
    void OnTriggerEnter2D(Collider2D other)
    {
        col = other;
        if (may_pos == true)
        {
            col.GetComponent<SpriteRenderer>().sprite = GetComponent<Image>().sprite;
            col.transform.localScale = transform.localScale;
            may_pos = false;
            transform.position = col.transform.position;
            check_press = false;
            btn.SetActive(true);

        }


        }
   
    
    void OnMouseDown()
    {
        if (check_press == false)
        {
            check_press = true;
            if (may_pos == false)
            {
                col.GetComponent<SpriteRenderer>().sprite = null;
                may_pos = true;
                btn.SetActive(false);
            }
        }
        else
        {
            check_press = false;
        }
    }
    void Update()
    {
        if (may_pos == true)
        {
            if (check_press == true)
            {
                mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.y + 10));
                transform.position = mousePosition;
            }
            if (check_press == false)
            {
                transform.position = start_pos;
            }
        }
     }
        
    }

