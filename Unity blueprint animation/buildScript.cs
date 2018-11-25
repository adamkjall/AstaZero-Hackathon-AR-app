using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildScript : MonoBehaviour
{


    public GameObject cube;
    public GameObject bed;
    public GameObject sofa;
    public GameObject tvTable;

    
  


    IEnumerator Start()
    {
        //grunden 
        StartCoroutine(BuildWallEast(0, 0, 0, 50, 5));//east
        StartCoroutine(BuildWallEast(0, 0, -59, 50, 5));
        StartCoroutine(BuildWallSouth(0, 0, 0, 60, 5));//south
        StartCoroutine(BuildWallSouth(49, 0, 0, 60, 5));

        //rum
        StartCoroutine(BuildWallSouth(19, 0, 0, 15, 5));
        StartCoroutine(BuildWallSouth(32, 0, 0, 15, 5));
        StartCoroutine(BuildWall(40, 0, -14, 50, 5));
        StartCoroutine(BuildWall(0, 0, -12, 9, 5));
        StartCoroutine(BuildWall2(18, 0, -59, -34, 5));
        StartCoroutine(BuildWallEast(13, 0, -35, 19, 5));

        //StartCoroutine(BuildWallTest(24, 0, 0, 1, 1));
        //StartCoroutine(BuildWallTest(24, 0, -59, 1, 1));

        yield return new WaitForSeconds(1.2f);
        SpawnBed();
        SpawnSofa();
        SpawnTv();





    }

    // Update is called once per frame
    void Update()
    {

    }


  

    IEnumerator BuildWallEast(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for (int x = startX; x < width; x++)
            {
                SpawnCube(x, y, startZ,root);

            }
            yield return new WaitForSeconds(0.2f);
        }
    }



    IEnumerator BuildWall(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for (int x = startX; x < width; x++)
            {
                SpawnCube(x, y, startZ,root);

            }
            yield return new WaitForSeconds(0.2f);
        }
    }


 


    IEnumerator BuildWallSouth(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for (int z = startZ; z < width; z++)
            {
                SpawnCube(startX, y, -z,root);

            }
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator BuildWall2(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for (int z = startZ; z < width; z++)
            {
                SpawnCube(startX, y, z,root);

            }
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator BuildWallTest(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);

        SpawnCubeTest(startX, startY, startZ, root);

            yield return new WaitForSeconds(0.05f);

    }


    void SpawnBed(){

        GameObject thebed = Instantiate(bed);
        thebed.transform.position = new Vector3(5, 0, -3);


    }


    void SpawnSofa()
    {

        GameObject thebed = Instantiate(sofa);
        thebed.transform.position = new Vector3(13, 2, -13);


    }

    void SpawnTv()
    {

        GameObject thebed = Instantiate(tvTable);
        thebed.transform.position = new Vector3(16, 4, -5);


    }



    void SpawnCube(float x, float y, float z , GameObject root = null)
    {
        GameObject theCube = Instantiate(cube);
        theCube.transform.position = new Vector3(x, y + 0.5f, z);
        //theCube.transform.localScale = new Vector3(10, 5, 1);
        theCube.name = x + " " + z; 
        if(root != null){
            theCube.transform.parent = root.transform;
        }
    }


 
}