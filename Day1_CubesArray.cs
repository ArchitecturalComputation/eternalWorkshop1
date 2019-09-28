using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesArray : MonoBehaviour
{

    public GameObject cube;
    public int size;

    // Start is called before the first frame update
    void Start()
    {
        size = 10;
        // array1D();
        //array2D();
        //var giveMeSomeCubes = array3D(size);

        StartCoroutine(cubeCreator(size));

        var giveMeOneCube = array3D(1);
        giveMeOneCube[0, 0, 0].transform.position = new Vector3(-10, -10, -10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void array1D()
    {
        for (int i = 0; i < size; i++)
        {
            Vector3 position = new Vector3(i, 0.0f, 0.0f);
            GameObject inCube = Instantiate(cube, position, Quaternion.identity);

            var scale = inCube.transform.localScale;
            var newScale = scale * 0.95f;

            inCube.transform.localScale = newScale;

            Debug.Log(position);

        }
    }

    public void array2D()
    {
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                var randomNum = Random.value ;
                Debug.Log(randomNum);
                if (randomNum> 0.5f)
                {

                Vector3 position = new Vector3(i, 0.0f, j);
                GameObject inCube = Instantiate(cube, position, Quaternion.identity);

                var scale = inCube.transform.localScale;
                var newScale = scale * 0.95f;

                inCube.transform.localScale = newScale;

                }

            }
    }

    public GameObject[,,] array3D(int mySize)
    {
        Color lerpedColor = new Color();
        GameObject[,,] allCubes = new GameObject[mySize, mySize, mySize];

        for (int i = 0; i < mySize; i++)
            for (int j = 0; j < mySize; j++)
                for (int k = 0; k < mySize; k++)
                {
                    var randomNum = Random.value;
                    Debug.Log(randomNum);
                    //calculate value
                    float calcValue = (i + j + k) / (mySize * 3.0f);
                    lerpedColor = Color.Lerp(Color.magenta, Color.green, calcValue);
                    //calculate position
                    Vector3 position = new Vector3(i, k, j);
                    //instatiate cube
                    GameObject inCube = Instantiate(cube, position, Quaternion.identity);
                    allCubes[i, j, k] = inCube;
                    //assiging calculated color
                    inCube.GetComponent<MeshRenderer>().material.color = lerpedColor;
                    var scale = inCube.transform.localScale;
                    var newScale = scale * 0.95f;
                    inCube.transform.localScale = newScale;
                }
        return allCubes;
    }

    IEnumerator cubeCreator(int mySize)
    {
        Color lerpedColor = new Color();
        GameObject[,,] allCubes = new GameObject[mySize, mySize, mySize];

        for (int i = 0; i < mySize; i++)
        {
            for (int j = 0; j < mySize; j++)
            { 
                for (int k = 0; k < mySize; k++)
                {
                    //calculate value
                    float calcValue = (i + j + k) / (mySize * 3.0f);
                    lerpedColor = Color.Lerp(Color.magenta, Color.green, calcValue);
                    //calculate position
                    Vector3 position = new Vector3(i, k, j);
                    //instatiate cube
                    GameObject inCube = Instantiate(cube, position, Quaternion.identity);
                    //assiging calculated color
                    inCube.GetComponent<MeshRenderer>().material.color = lerpedColor;
                    var scale = inCube.transform.localScale;
                    var newScale = scale * 0.95f;
                    inCube.transform.localScale = newScale;
                    yield return new WaitForSeconds(0.05f);                    
                }
            }
        }

    }
}
