using System;
using UnityEngine;

namespace GDK.SaveLoadService
{
    [Serializable]
    public class TestData
    {
        [Serializable]
        public enum MyEnum
        {
            None,
            One,
            Two
        }
        
        public Vector2 Vector;
        public string String;
        public MyEnum Enum;

        public override string ToString()
        {
            return $"Vector = {Vector.ToString()}, String = {String}, Enum = {Enum}";
        }
    }
}