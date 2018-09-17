

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace BattleRoyaleSolutions.Client.PowerShellExecutor
{
    public static class PowerShellExecutor
    {
        public static Collection<PSObject> ExecuteCommand(string script)
        {
            Collection<PSObject> results;
            using (Runspace runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open();

                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript(script);

                    pipeline.Commands.Add("Out-String");

                    // execute the script
                    results = pipeline.Invoke();
                }
                // close the runspace
                runspace.Close();
            }

            return results;
        }
    }
}
