using System;
using System.Diagnostics;

namespace gitMergeConflict
{
	class Tool
	{

		public static void ExecuteGitCommands()
		{
			var currentBranch = GetCurrentBranch();

			ExecuteGitCommand("checkout master");
			ExecuteGitCommand("pull");
			ExecuteGitCommand($"checkout {currentBranch}");
			ExecuteGitCommand("merge master");
			ExecuteGitCommand("mergetool");
		}

		private static void ExecuteGitCommand(string arguments)
		{
			var processStartInfo = new ProcessStartInfo()
			{
				FileName = "git",
				WorkingDirectory = Environment.CurrentDirectory,
				Arguments = arguments,
			};
			var process = Process.Start(processStartInfo);
			process.WaitForExit();
		}

		private static string GetCurrentBranch()
		{
			var processStartInfo = new ProcessStartInfo()
			{
				Arguments = "branch",
				FileName = "git",
				WorkingDirectory = Environment.CurrentDirectory,
				RedirectStandardOutput = true,
			};

			var branchProcess = Process.Start(processStartInfo);
			branchProcess.WaitForExit(TimeSpan.FromMilliseconds(1_500).Milliseconds);
			if(!branchProcess.HasExited || branchProcess.ExitCode == 128)
			{
				return string.Empty;
			}
			using (var streamReader = branchProcess.StandardOutput)
			{
				string line;

				while ((line = streamReader.ReadLine()) != null)
				{
					if (line.StartsWith('*'))
					{
						//we've got our branch name
						return line.Replace("* ", "");
					}
				}
			}
			return string.Empty; 
		}
	}
}