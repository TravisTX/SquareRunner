﻿using Assets.Scripts.ChunkGenerators;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour
{
    private Object worldChunkPrefab;

    private GameObject newestChunk = null;
    private float chunkWidth = 50;
    private List<IChunkGenerator> chunkGenerators = new List<IChunkGenerator>();
    private bool bumpyAdded = false;

    // Use this for initialization
    void Start()
    {
        GameManager.Instance.WorldGenerator = this;
        worldChunkPrefab = Resources.Load("WorldChunkPrefab");
        Reset();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.distanceTraveled > 10 && !bumpyAdded)
        {
            bumpyAdded = true;
            chunkGenerators.Add(new BumpyGrassChunkGenerator());
        }

        if (newestChunk == null)
        {
            GenerateWorldChunk(-50, true);
        }
        if (Camera.main.transform.position.x > newestChunk.transform.position.x)
        {
            var chunkRight = newestChunk.transform.position.x + chunkWidth;
            GenerateWorldChunk(chunkRight, true);
        }
    }

    public void Reset()
    {
        newestChunk = null;
        chunkGenerators.Clear();
        chunkGenerators.Add(new FlatGrassChunkGenerator());
        GenerateWorldChunk(-50, false);
        GenerateWorldChunk(0, false);
    }

    private void GenerateWorldChunk(float positionX, bool buffered)
    {
        Debug.Log("new chunk");
        var chunk = (GameObject)Instantiate(worldChunkPrefab, new Vector3(positionX, 0, 0), new Quaternion(0, 0, 0, 0));

        IChunkGenerator gen = chunkGenerators[Random.Range(0, chunkGenerators.Count)];
        //IChunkGenerator gen = new BumpyGrassChunkGenerator();
        gen.Generate(chunk, chunkWidth, buffered);


        //for (int i = 0; i < chunkWidth; i++)
        //{
        //    var tile = (GameObject)Instantiate(groundPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        //    tile.transform.parent = chunk.transform;
        //    tile.transform.localPosition = new Vector3(1 * i, -1, 0);
        //}

        newestChunk = chunk;
    }

    //Bounds getBounds(GameObject objeto)
    //{
    //    Bounds bounds;
    //    Renderer childRender;
    //    bounds = getRenderBounds(objeto);
    //    if (bounds.extents.x == 0)
    //    {
    //        bounds = new Bounds(objeto.transform.position, Vector3.zero);
    //        foreach (Transform child in objeto.transform)
    //        {
    //            childRender = child.GetComponent<Renderer>();
    //            if (childRender)
    //            {
    //                bounds.Encapsulate(childRender.bounds);
    //            }
    //            else
    //            {
    //                bounds.Encapsulate(getBounds(child.gameObject));
    //            }
    //        }
    //    }
    //    return bounds;
    //}

    //Bounds getRenderBounds(GameObject objeto)
    //{
    //    Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
    //    Renderer render = objeto.GetComponent<Renderer>();
    //    if (render != null)
    //    {
    //        return render.bounds;
    //    }
    //    return bounds;
    //}

    public void StartChildCoroutine(IEnumerator coroutineMethod)
    {
        StartCoroutine(coroutineMethod);
    }


}
