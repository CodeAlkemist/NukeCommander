namespace CodeAlkemy
{
    public class Command
    {
        public string _cmd;
        public string[] _args;
        public Command(string cmd, string[] args)
        {
            this._cmd = cmd;
            this._args = args;
        }

        public void Shift()
        {
            string[] argsTmp = this._args;
            for (int i = 1; i < argsTmp.Length; i++)
            {
                this._args[i] = argsTmp[i];
            }
        }
    }
}