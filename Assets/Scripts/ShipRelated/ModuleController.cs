using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleController : MonoBehaviour
{
    [HideInInspector]
    private playerController playControl;
    public Sprite disabled;
    public GameObject[] modulePrefabs;
    //Length of twice the triangle radius
    public float triangleUnit;
    private List<ExtendedHitbox> currentModules;


    private List<List<Vector2>> lastLayer = new List<List<Vector2>>();
    private List<List<Vector2>> thisLayer = new List<List<Vector2>>();

    private int currentLayer = 0;
    private int currentTile = 0;
    private int currentDirection = 0;

    int num = 0;

    private void Start()
    {
        playControl = GetComponent<playerController>();
        currentModules = new List<ExtendedHitbox>();
        List<ExtendedHitbox> shipHitboxes = new List<ExtendedHitbox>(GetComponents<ExtendedHitbox>());
        foreach(ExtendedHitbox gpu in shipHitboxes)
        {
            currentModules.Add(gpu);
            gpu.center = this;
        }

        lastLayer.Add(new List<Vector2>());
        lastLayer[0].Add(Vector2.right * (triangleUnit / 2f));
        lastLayer.Add(new List<Vector2>());
        lastLayer[1].Add(Vector2.right * (triangleUnit / 2f));
        lastLayer.Add(new List<Vector2>());
        lastLayer[2].Add(Vector2.left * (triangleUnit / 2f));
        lastLayer.Add(new List<Vector2>());
        lastLayer[3].Add(Vector2.left * (triangleUnit / 2f));
        lastLayer.Add(new List<Vector2>());
        lastLayer.Add(new List<Vector2>());


        thisLayer = new List<List<Vector2>>();
        for (int i = 0; i < 6; ++i)
        {
            thisLayer.Add(new List<Vector2>());
        }
    }

    private Vector2 GetAxisRight(Vector2 direction)
    {
        return Quaternion.Euler(0, 0, -60) * direction;
    }

    private Vector2 GetAxisLeft(Vector2 direction)
    {
        return Quaternion.Euler(0, 0, 60) * direction;
    }

    private GameObject CreateNextModule(int type)
    {
        Vector2 direction = Vector2.zero;

        switch (currentDirection)
        {
            case 0:
                direction = Quaternion.Euler(0, 0, -30) * Vector2.up;
                break;
            case 1:
                direction = Quaternion.Euler(0, 0, 30) * Vector2.down;
                break;
            case 2:
                direction = Quaternion.Euler(0, 0, -30) * Vector2.down;
                break;
            case 3:
                direction = Quaternion.Euler(0, 0, 30) * Vector2.up;
                break;
            case 4:
                direction = Vector2.right;
                break;
            case 5:
                direction = Vector2.left;
                break;

        }

        direction *= triangleUnit;

        Vector2 position = Vector2.zero;
        float rotation = 0;

        if (currentLayer == 1 && currentDirection > 3)
        {
            if (currentDirection == 4)
            {
                direction = Quaternion.Euler(0, 0, 30) * Vector2.down * triangleUnit;
                Vector2 temp1 = Vector2.right * (triangleUnit / 2f);

                position = temp1 + direction + GetAxisLeft(direction) + GetAxisLeft(GetAxisLeft(direction));
                rotation = 90f;
            }

            if (currentDirection == 5)
            {
                direction = Quaternion.Euler(0, 0, -30) * Vector2.down * triangleUnit;
                Vector2 temp1 = Vector2.left * (triangleUnit / 2f);

                position = temp1 + direction + GetAxisRight(direction) + GetAxisRight(GetAxisRight(direction));

                rotation = -90f;
            }
        }
        else
        {
            if (currentLayer % 2 == 0)
            {
                position = lastLayer[currentDirection][currentTile] + direction;
            }
            else
            {
                if (currentTile < lastLayer[currentDirection].Count)
                {
                    position = lastLayer[currentDirection][currentTile] + GetAxisLeft(direction);
                }
                else
                {
                    position = lastLayer[currentDirection][currentTile - 1] + GetAxisRight(direction);
                }
            }
            if (currentDirection < 4)
            {
                if (currentLayer % 2 == 0)
                {
                    rotation = -30f;
                }
                else
                {
                    rotation = 30f;
                }

                if (currentDirection >= 2)
                {
                    rotation -= 60f;
                }
            }
            else
            {
                if (currentLayer % 2 == 0)
                {
                    rotation = 90f;
                }
                else
                {
                    rotation = -90f;
                }
                if(currentDirection == 4)
                {
                    rotation += 180f;
                }
            }

        }

        thisLayer[currentDirection].Add(position);

        ++currentDirection;
        while(currentDirection <= 5 && (currentTile > lastLayer[currentDirection].Count || (currentLayer % 2 == 0 && currentTile > lastLayer[currentDirection].Count - 1)))
        {
            //Skip direction 4 and 5 on the last tile
            ++currentDirection;
        }

        if(currentDirection > 5)
        {
            currentDirection = 0;
            ++currentTile;
            if(currentTile > lastLayer[currentDirection].Count || (currentLayer % 2 == 0 && currentTile > lastLayer[currentDirection].Count - 1))
            {
                currentTile = 0;
                lastLayer.Clear();
                foreach (List<Vector2> layer in thisLayer)
                {
                    List<Vector2> elements = new List<Vector2>();
                    foreach (Vector2 element in layer)
                    {
                        elements.Add(element);
                    }
                    lastLayer.Add(elements);
                }
                thisLayer = new List<List<Vector2>>();
                for (int i = 0; i < 6; ++i)
                {
                    thisLayer.Add(new List<Vector2>());
                }
                if (currentLayer == 0)
                {
                    lastLayer.Add(new List<Vector2>());
                    lastLayer.Add(new List<Vector2>());
                }
                ++currentLayer;
            }
        }

        GameObject toReturn = Instantiate(modulePrefabs[type], transform.position + new Vector3(position.x, position.y), Quaternion.Euler(0, 0, rotation), transform);
        StartCoroutine(TurnOffAfterDelay(toReturn.transform));
        return toReturn;
    }

    private IEnumerator TurnOffAfterDelay(Transform t)
    {
        yield return new WaitForSeconds(60f);
        t.GetChild(0).gameObject.SetActive(false);
        t.GetComponent<SpriteRenderer>().sprite = disabled;
    }

    public void Impact(Collider2D col)
    {
        if(col.tag == "PowerUp")
        {
            if(col.GetComponent<PowerUp>().CanGrab())
            {
                col.GetComponent<PowerUp>().Grab();
                AddPowerUp(col.GetComponent<PowerUp>().GetPowerUpType());
                Destroy(col.gameObject);
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
        else if(col.tag != "playerProjectile")
        {
            playControl.TakeDamage(col);
        }
    }

    public void AddPowerUp(int x)
    {
        //Generate with offset and set as a child to this object
        GameObject generatedModule = CreateNextModule(x);

        generatedModule.GetComponent<ExtendedHitbox>().center = this;
        currentModules.Add(generatedModule.GetComponent<ExtendedHitbox>());
        num++;
    }

    public int countPowerUps()
    {
        return num;
    }
}
