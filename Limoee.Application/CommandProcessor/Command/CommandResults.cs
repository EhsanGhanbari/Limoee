using System.Collections.Generic;
using System.Linq;

namespace Limoee.Application.CommandProcessor.Command
{
    public class CommandResults : ICommandResults
    {
        private readonly List<ICommandResult> _results = new List<ICommandResult>();

        public void AddResult(ICommandResult result)
        {
            this._results.Add(result);
        }

        public ICommandResult[] Results
        {
            get
            {
                return this._results.ToArray();
            }
        }

        public bool Success
        {
            get
            {
                return this._results.All<ICommandResult>(result => result.Success);
            }
        }
    }
}