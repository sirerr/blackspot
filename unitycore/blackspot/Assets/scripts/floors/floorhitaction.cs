using UnityEngine;
using System.Collections;

public class floorhitaction : MonoBehaviour {

  
    public Material currentmat;
    public int ballhits = 0;
    public int ballhitlimit = 5;
    private MeshRenderer meshren;
    private GMstatics gmstaticref;
    public float alphaValue = 63.75f;
    public GameObject previousobj;

    public virtual void Awake()
    {
        meshren = GetComponent<MeshRenderer>();
        currentmat = meshren.material;
        Color colorA = currentmat.color;
        colorA.a = 0;
        currentmat.color = colorA;
   //     gmstaticref = GameObject.FindGameObjectWithTag("gmanager").GetComponent<GMstatics>();
    }

    public virtual void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("ball"))
        {
            switch (ballhits)
            {
                case 0:
                    changecolor();
                    ballhits++;
                    previousobj = col.gameObject;
                    break;
                case 1:
                    if (col.gameObject != previousobj)
                    {
                        changecolor();
                        ballhits++;
                        previousobj = col.gameObject;
                    }

                    break;
                case 5:
                    {
                        if (col.gameObject != previousobj)
                        {
                            changecolor();
                            Teleportable();
                            ballhits++;
                            previousobj = col.gameObject;
                        }
                        break;
                    }
                default:
                    if (col.gameObject != previousobj)
                    {
                        changecolor();
                        ballhits++;
                        previousobj = col.gameObject;
                    }
                    break;
            }
        }
    }

    //change the alpha value of the object each time it's called
    public virtual void changecolor()
    {
        Color colorA = currentmat.color;
        //alpha value is 63.75
        colorA.a += alphaValue/255;
        //currentmat is a instance of the current material of the object
        currentmat.color = colorA;
    }

    public virtual void Teleportable()
    {
     //   print("can teleport to");
        gameObject.layer = gmstaticref.teleportLayer;
    }

}
