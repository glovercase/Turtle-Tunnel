/*
This script holds variables and methods used to generate items in the tunnel
It randomly decides where to place the item based on a certain range. 
*/

using UnityEngine;

public class RandomPlacer : PipeItemGenerator
{

    //Instance variable
    public PipeItem[] itemPrefabs;

    //This method generates the items in the pipe. It takes into account the angle and rotation of the pipe
    public override void GenerateItems(Pipe pipe)
    {
        float angleStep = pipe.CurveAngle / pipe.CurveSegmentCount;
        for (int i = 0; i < pipe.CurveSegmentCount; i++)
        {
            PipeItem item = Instantiate<PipeItem>(
                itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
            float pipeRotation =
                (Random.Range(0, pipe.pipeSegmentCount) + 0.5f) *
                360f / pipe.pipeSegmentCount;
            item.Position(pipe, i * angleStep, pipeRotation);
        }
    }
}