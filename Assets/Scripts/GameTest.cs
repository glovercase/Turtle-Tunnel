/*
This script simply helped us to test certain functionality of the game. 
It has a number of tests checking the core functions of the app. 
*/


public class GameTest
{

	public MainMenu menu = new MainMenu();
    private bool gamestate;
	public CoinBehaviour cb = new CoinBehaviour();

    public void startGame()
	{
    	
        menu.StartGame(1);
        gamestate = true;
    }


    public void endGame()
	{
    	menu.EndGame(100f);
    	gamestate = false;
    }

	//test speed increase
    public bool speedIncreased()
	{
    	startGame();
        if(menu.player.acceleration >= 0)
		{
            return true;
        }else
		{
            return false;
        }
    }

	//testing game starts
    public bool gameState()
	{
    	startGame();
        return gamestate;
    }

	//testing game ended
    public bool gameEnd()
	{
    	endGame();
        return gamestate;
    }
}
