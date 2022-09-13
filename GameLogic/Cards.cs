public class Card
{
	private char m_CardValue;
	private bool m_IsVisible;

	public Card()
	{
		this.m_CardValue = ' ';
		this.m_IsVisible = false;
	}

	public Card(char i_CardLetter)
	{
		this.m_CardValue = i_CardLetter;
		this.m_IsVisible = false;
	}

	public void TurnCardVisible()
	{
		this.m_IsVisible = true;
	}

	public void TurnCardInvisible()
	{
		this.m_IsVisible = false;
	}

	public char GetValue()
	{
		return this.m_CardValue;
	}

	public bool GetIsVisible()
	{
		return this.m_IsVisible;
	}
}