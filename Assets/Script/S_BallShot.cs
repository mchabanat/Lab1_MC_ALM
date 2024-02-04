using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class S_BallShot : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 click;
    Vector2 self;

    bool isClicked = false;

    GameObject line = null;

    public float force = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Freeze the ball in the beginning
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        shot();
    }


    void shot()
    {
        //On click, save coordinates of the mouse and when the mouse is released, calculate the direction and force of the ball
        if (Input.GetMouseButtonDown(0) && !isClicked)
        {
            click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isClicked = true;
            self = transform.position;
        }

        if (isClicked)
        {

            Vector2 current = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (line != null)
            {
                clearLine(line);
            }
            line = drawLine(click, current, Color.red);

            if (Input.GetMouseButtonUp(0))
            {
                Vector2 release = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                click -= self;
                release -= self;
                Vector2 direction = click - release;
                rb.constraints = RigidbodyConstraints2D.None;
                rb.AddForce(direction * force, ForceMode2D.Impulse);
                Debug.Log(direction * force);
                isClicked = false;
                if (line != null)
                {
                    clearLine(line);
                }
            }
        }
    }

    GameObject drawLine(Vector2 start, Vector2 end, Color color)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        color = DefineColor(start, end);
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        return myLine;
    }

    void clearLine(GameObject line)
    {
        Destroy(line);
        line = null;
    }

    Color DefineColor(Vector2 start, Vector2 end)
    {
        float maxDistance = 10f; 
        float distance = Vector2.Distance(start, end);
        float t = Mathf.Clamp01(distance / maxDistance); 
        Color color = Color.Lerp(Color.white, Color.red, t);
        return color;
    }

}
