using System;
using MessagePack;
using UnityEngine;

namespace Pets.Entities
{
    public class Test : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log(new Character(12, "ふが", new[] {
                new Ability(1, "ぴよ"),
                new Ability(3, "ほげ")
            }).ToString());
        }
    }
}