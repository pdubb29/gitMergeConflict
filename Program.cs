using System;
using static System.Console;
namespace gitMergeConflict
{
		class Program
		{
			static void Main(string[] args)
			{
				if(!CheckArguments(args))
				{
					return;
				}
				Tool.ExecuteGitCommands();

			}

		private static bool CheckArguments(string[] args)
		{
			if(args.Length > 0)
			{
				PrintUsage();
				return false;
			}
			return true;
		}

		private static void PrintUsage()
		{
			WriteLine("#############################");
			WriteLine("## GitMergeConflict #########");
			WriteLine("#############################");
			WriteLine("gmc");
		}
	}
}
