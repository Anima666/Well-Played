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

    void Start ()
    {
       start_pos= new Vector3( transform.position.x, transform.position.y,transform.position.z);

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
          //  GetComponent<SpriteRenderer>().color = Color.gray;
            transform.position = col.transform.position;
            check_press = false;
        }
        
            //other.gameObject = gameObject;
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
            }
        }
        else
        {
            check_press = false;
        }
    }
    void Update()
    {
        // transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
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

