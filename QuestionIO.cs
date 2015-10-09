using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ModelQuestion {
    public class QuestionIO {
        public const string TEXT_EXT = ".txt";
        public const string CSV_EXT = ".csv";

        public static Question[] LoadQuestion(string dir) {
            string[] files = Directory.GetFiles(dir);
            Dictionary<string, Question> dict = new Dictionary<string, Question>();
            Random rng = new Random();

            foreach (string filename in files) {
                string realname = Path.GetFileNameWithoutExtension(filename);
                string extname = Path.GetExtension(filename);

                Question q;
                if (dict.TryGetValue(realname, out q)) {
                    // done
                } else {
                    q = dict[realname] = new Question();
                }

                if (extname == TEXT_EXT) {
                    try {
                        string[] lines = File.ReadAllLines(filename);
                        q.Description = lines[0];
                        q.Correct = lines[1];
                        q.Choice = lines.Skip(1).OrderBy(l => rng.Next()).ToArray();

                        q.Name = realname;
                        q.TextFile = filename;
                    } catch (IndexOutOfRangeException e) {
                        Console.WriteLine(e.StackTrace);
                    }
                } else {
                    q.ImageFile = filename;
                }
            }

            return dict.Values.Where(q => q.ImageFile != null && q.TextFile != null && q.Choice.Length > 0).ToArray();
        }

        public static void StoreQuestion(QuestionModel model) {
            switch (Path.GetExtension(model.Path)) {
                case TEXT_EXT:
                    using (StreamWriter file = new StreamWriter(model.Path)) {
                        file.WriteLine("\t\tModelQuestion Test Result");
                        file.WriteLine(string.Format("Directory: {0}\t\tPath: {1}", model.Directory, model.Path));
                        file.WriteLine(string.Format("TimeBegin: {0}\t\tTimeEnd: {1}", model.TimeBegin, model.TimeEnd));
                        file.WriteLine();

                        foreach (Question q in model.Cases) {
                            file.WriteLine(string.Format("Name: {0}, Correct: {1}, Selected: {2}, Right: {3}", q.Name, q.Correct, q.Selected, (q.Selected == q.Correct ? "Yes" : "No")));
                        }
                        
                        int correct = model.Cases.Count(q => q.Selected == q.Correct);
                        file.WriteLine();
                        file.WriteLine("Summary:");
                        file.WriteLine("CaseCount: {0}, CorrectCount: {1}, CorrectRate: {2}", model.CaseCount, correct, (float)correct / model.CaseCount);
                    };
                    break;

                case CSV_EXT:
                    using (StreamWriter file = new StreamWriter(model.Path)) {
                        file.WriteLine("Name,Selected,Correct Right");
                        foreach (Question q in model.Cases) {
                            file.WriteLine(string.Format("{0},{1},{2},{3}", q.Name, q.Correct, q.Selected, (q.Selected == q.Correct ? "Yes" : "No")));
                        }
                    };
                    break;
            }
        }
    }
}
