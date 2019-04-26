using System.Diagnostics;
using System.IO;
using System.Linq;

namespace grcg
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator(BuildingData.Load(), ChallengeData.Load());
            var challengePost = generator.Generate();
            File.WriteAllText(@".\ForumPost.txt", challengePost);
            OpenFile();
        }

        private static void OpenFile()
        {
            var pi = new ProcessStartInfo(@".\ForumPost.txt")
            {
                Arguments = Path.GetFileName(@".\ForumPost.txt"),
                UseShellExecute = true,
                WorkingDirectory = Path.GetDirectoryName(@".\"),
                Verb = "OPEN"
            };

            Process.Start(pi);
        }
    }
}
