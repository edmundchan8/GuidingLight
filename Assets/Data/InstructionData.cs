using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class InstructionData : ScriptableObject 
{
	public Sprite[] m_SpriteArray;

	public Sprite LoadSprite(int element)
	{
		return m_SpriteArray[element];
	}
}
