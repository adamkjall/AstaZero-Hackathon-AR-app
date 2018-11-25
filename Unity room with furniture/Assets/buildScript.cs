﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildScript : MonoBehaviour {

    Vector3 wall = new Vector3(19, 0, 0);

    public GameObject cube;
    public GameObject floorCube;
    public GameObject windowCube;
    public GameObject bathtub;
    public GameObject bed;
    public GameObject toilet;
    public GameObject toiletSink;

    private float moveSpeed = 15f;
    private float rotateSpeed = 180f;
    private GameObject rootObej;
    private float delay = 0.1f;
    private int scale = 5;

    // Use this for initialization
    void Start () {
        
        TestSpawnCubeX(0, 0, 0, 265, 40); //bottom outer wall
        TestSpawnCubeX(335, 0, 0, 115, 40); //bottom outer wall
        TestSpawnCubeX(0, 0, 600, 450, 40); //top outer wall
        TestSpawnCubeX(260, 0, 345, 95, 40); //kitchen bottom wall
        TestSpawnCubeX(345, 0, 110, 105, 40); //closet top wall
        TestSpawnCubeX(0, 0, 155, 85, 40); //bathroom top wall
        

        TestSpawnCubeZ(0, 0, 0, 600, 40); //left outer wall
        TestSpawnCubeZ(450, 0, 0, 600, 40); //right outer wall
        TestSpawnCubeZ(155, 0, 0, 155, 40); //bathroom right wall
        TestSpawnCubeZ(260, 0, 0, 145, 40); //closet wall
        TestSpawnCubeZ(345, 0, 0, 20, 40); //closet little shit wall
        TestSpawnCubeZ(345, 0, 90, 20, 40); //closet top little shit wall
        TestSpawnCubeZ(260, 0, 345, 255, 40); //kitchen left wall

        createFloor(0, 0, 0, 450, 600);

        createWindow(40, 20, 600, 65, 20, 3);
        createWindow(180, 20, 600, 65, 20, 3);
        createWindow(355, 20, 600, 65, 20, 3);

        spawnBathtub();
        spawnToilet();
        spawnBed();
        spawnToiletSink();


        /*
        StartCoroutine(buildWallX(0,0,0,50,5));
        StartCoroutine(buildWallX(0, 0, 59, 50, 5));
        StartCoroutine(buildWallX(13, 0, -35, 19, 5));
        StartCoroutine(buildWallX(40, 0, 14, 50, 5));
        StartCoroutine(buildWallX(0, 0, 14, 9, 5));
        */

        /*
        StartCoroutine(buildWallZ(0, 0, 0, 60, 5));
        StartCoroutine(buildWallZ(49, 0, 0, 60, 5));
        StartCoroutine(buildWallZ(19, 0, 0, 15, 5));
        StartCoroutine(buildWallZ(32, 0, 0, 15, 5));
        StartCoroutine(buildWallZ(18, 0, -59, -34, 5));
        */


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(transform.position, transform.up, -(Time.deltaTime * rotateSpeed));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }

    public IEnumerator buildWallX(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for(int x = startX; x < width; x++)
            {
                SpawnCube(startX, startY, startZ, x, y, startZ, root);
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator buildWallZ(int startX, int startY, int startZ, int width, int height)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for (int z = startZ; z < width; z++)
            {
                SpawnCube(startX, startY, startZ, startX, y, z, root);
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator buildRotateWall(int startX, int startY, int startZ, int width, int height, int degrees)
    {
        var root = new GameObject("root " + startX + " " + startZ);
        for (int y = startY; y < height; y++)
        {
            for (int x = startX; x < width; x++)
            {
                //SpawnCube(x, y, startZ, root);
            }
            yield return new WaitForSeconds(0.2f);
        }
            root.transform.Rotate(Vector3.up, degrees);
    }

    void SpawnCube(float startX, float startY, float startZ, float x, float y, float z, GameObject root = null)
    {
        GameObject theCube = Instantiate(cube);

        theCube.transform.position = new Vector3(x, y + 0.5f, z);

        theCube.name = x + " " + z;
        if (root != null)
        {
            theCube.transform.parent = root.transform;
        }
    }

    void TestSpawnCubeX(float startX, float startY, float startZ, float width, float height)
    {
        GameObject theCube = Instantiate(cube);

        theCube.transform.position = new Vector3(startX, startY, startZ);
        theCube.transform.localScale = new Vector3(width, height, 1);
        theCube.transform.position = new Vector3(startX + (width/2), startY + (height/2), startZ);

        theCube.name = startX + " " + startZ;
    }

    void TestSpawnCubeZ(float startX, float startY, float startZ, float width, float height)
    {
        GameObject theCube = Instantiate(cube);

        theCube.transform.position = new Vector3(startX, startY, startZ);
        theCube.transform.localScale = new Vector3(1, height, width);
        theCube.transform.position = new Vector3(startX, startY + (height/2), startZ + (width/2));

        theCube.name = startX + " " + startZ;
    }

    void createFloor(float startX, float startY, float startZ, float widthX, float widthZ)
    {
        GameObject theCube = Instantiate(floorCube);

        theCube.transform.position = new Vector3(startX, startY, startZ);
        theCube.transform.localScale = new Vector3(widthX, 1, widthZ);
        theCube.transform.position = new Vector3(startX + (widthX/2), startY, startZ + (widthZ / 2));

        theCube.name = "floooooooor";
    }

    void createWindow(float startX, float startY, float startZ, float widthX, float heightY, float widthZ)
    {
        GameObject theCube = Instantiate(windowCube);

        theCube.transform.position = new Vector3(startX, startY, startZ);
        theCube.transform.localScale = new Vector3(widthX, heightY, widthZ);
        theCube.transform.position = new Vector3(startX + (widthX / 2), startY + (heightY/2), startZ);

        theCube.name = "window" + startX + " " + startZ;
    }

    void spawnBathtub()
    {
        GameObject bathtuuub = Instantiate(bathtub);

        bathtuuub.transform.position = new Vector3(20, 10, 68);
        bathtuuub.transform.Rotate(Vector3.up * -90);
        bathtuuub.name = "ett gött badkar";
        bathtuuub.transform.localScale = new Vector3(2412, 1300, 1500);
    }

    void spawnToilet()
    {
        GameObject toalett = Instantiate(toilet);

        toalett.transform.position = new Vector3(140, 20, 10);
        toalett.name = "bajslådan";
        toalett.transform.localScale = new Vector3(2412, 1300, 1500);
    }

    void spawnToiletSink()
    {
        GameObject toasink = Instantiate(toiletSink);

        toasink.transform.position = new Vector3(100, 20, 10);
        toasink.name = "handfat";
        toasink.transform.localScale = new Vector3(1700, 1300, 1500);
    }

    void spawnBed()
    {
        GameObject bedd = Instantiate(bed);

        bedd.transform.position = new Vector3(142, 32, 537);
        bedd.transform.Rotate(Vector3.up * -180);
        bedd.name = "sängen";
        bedd.transform.localScale = new Vector3(1200, 1300, 1500);
    }



    /* BACKUP
     * void SpawnCube(float startX, float startY, float startZ, float x, float y, float z, GameObject root = null)
    {
        GameObject theCube = Instantiate(cube);
        theCube.transform.position = new Vector3(x, y + 0.5f, z);
        theCube.name = x + " " + z;
        if (root != null)
        {
            theCube.transform.parent = root.transform;
        }
    }
    */

}

