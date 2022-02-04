using DerivcoTest.Exceptions;
using DerivcoTest.Interfaces;

namespace DerivcoTest
{
    public class HighCardGame
    {
        private IHighCardStrategy Strategy;
        public HighCardGame() { }

        public void SetStraegy(IHighCardStrategy stragegy)
        {
            this.Strategy = stragegy;
        }
        
        public string Play()
        {
            try
            {
                var result = this.Strategy.Play();
                switch (result)
                {
                    case 1:
                        return "RESULT: Player 1 Win - Player 2 Lose";
                        break;
                    case -1:
                        return "RESULT: Player 1 Lose - Player 2 Win";
                        break;
                    case 0:
                        return "RESULT: Tie";
                        break;
                    default:
                        return null;
                        break;
                }
            }
            catch(NoMoreCardsException)
            {
                return "RESULT: Tie";
            }
            
        }
    }
}
