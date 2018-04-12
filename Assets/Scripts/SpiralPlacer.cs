/*
This script holds variables and methods used in creating a spiral obstacle in the pipe.
It is a subclass of PipeItemGenerator and overrides its generateItems method.
*/

using UnityEngine;

public class SpiralPlacer : PipeItemGenerator
{

    //Instance variables
    public PipeItem[] itemPrefabs;

    //Overrides the generate Item method. It makes a spiral of obstacles in game
    public override void GenerateItems(Pipe pipe)
    {
        float start = (Random.Range(0, pipe.pipeSegmentCount) + 0.5f);
        float direction = Random.value < 0.5f ? 1f : -1f;

        float angleStep = pipe.CurveAngle / pipe.CurveSegmentCount;
        for (int i = 0; i < pipe.CurveSegmentCount; i++)
        {
            PipeItem item = Instantiate<PipeItem>(
                itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
            float pipeRotation =
                (start + i * direction) * 360f / pipe.pipeSegmentCount;
            item.Position(pipe, i * angleStep, pipeRotation);
        }
    }
}