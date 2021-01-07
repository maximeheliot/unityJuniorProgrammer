using UnityEngine;
using System.Collections;

public class SomeOtherGeneric : MonoBehaviour 
{
    void Start () 
    {
        SomeGeneric myClass = new SomeGeneric();

        //In order to use this method you must
        //tell the method what type to replace
        //'T' with.
        myClass.GenericMethod<int>(5);
    }
}