using System;
using System.Collections.Generic;

public class Player
{
	private string m_Name;
	private int m_Score;
	private bool m_IsMyTurn;
	private readonly List<Card> m_CardsCounting;
	
	public Player(string i_Name)
	{
		this.m_Name = i_Name;
		this.m_Score = 0;
		this.m_IsMyTurn = false;
		m_CardsCounting = new List<Card>();
	}
	public List<Card> getCardsCounting()
	{
		return m_CardsCounting;
	}

	public void AddToPlayerMemory(Card i_Card)
	{
		m_CardsCounting.Add(i_Card);
	}
	public void SetScore()
	{
		this.m_Score = 0;
	}

	public string GetName()
	{
		return this.m_Name;
	}

	public bool IsMyTurn()
	{
		return this.m_IsMyTurn;
	}

	public int GetScore()
	{
		return this.m_Score;
	}

	public void IncrementScore()
	{
		this.m_Score++;
	}

	public void SetTurn()
	{
		this.m_IsMyTurn = true;
	}

	public void EndTurn()
	{
		this.m_IsMyTurn = false;
	}
}

