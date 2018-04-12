/*
This script holds an abstract class for generating items in the pipe
*/

using UnityEngine;

public abstract class PipeItemGenerator : MonoBehaviour
{

    public abstract void GenerateItems(Pipe pipe);
}