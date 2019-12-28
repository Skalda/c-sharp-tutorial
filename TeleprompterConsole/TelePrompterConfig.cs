using static System.Math;

namespace TeleprompterConsole
{
    internal class TelePrompterConfig
    {
        public int DelayInMiliseconds { get; private set; } = 200;

        public void UpdateDelay(int increment)
        {
            var newDelay = Min(DelayInMiliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            DelayInMiliseconds = newDelay;
        }
        
        public bool Done { get; private set; }

        public void SetDone()
        {
            Done = true;
        }
    }
}