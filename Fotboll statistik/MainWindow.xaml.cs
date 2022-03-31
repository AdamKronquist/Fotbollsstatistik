using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiteDB;

namespace Fotboll_statistik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadDatabaseHistoryFromStart();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;

            //Öppna databasen och filen.
            using (var db = new LiteDatabase("Historik.db"))
            {
                //Skapa collection.
                var db_result = db.GetCollection<MatchInfo>("Result");

                //Kollar hur många resultat det finns i databasen.
                int matchNr = GetNumberOfMatches(db_result);

                //Resultatet som angivits.
                MatchInfo result = new MatchInfo(date, matchNr, comboJonny.Text, Convert.ToInt32(txtJonny.Text), comboAdam.Text, Convert.ToInt32(txtAdam.Text));

                //Lägger in resultatet i databasen.
                db_result.Insert(result);

                //Hämtar det senaste resultatet från databasen.
                var latestResult = db_result.Find(x => x.MatchNr == db_result.Count()).ToList();

                AddLatestResultToList(latestResult);
                UpdateWinnigList(CheckWins("W", db_result), CheckWins("L", db_result), CheckWins("D", db_result));
                UpdateGoalList(GetGoals("Jonny", db_result), GetGoals("Adam", db_result), matchNr);
            }
        }

        private void AddLatestResultToList(dynamic latestResult)
        {
            //Lägger in det senaste resultat från databasen i listan.
            lstResults.Items.Insert(0, new Results
            {
                Datum = $"{latestResult[0].Date:d MMM-yyyy}",
                Match = latestResult[0].MatchNr,
                Jonny = $"{latestResult[0].JonnyTeam} {latestResult[0].JonnyScore}".ToString(),
                Adam = $"{latestResult[0].AdamTeam} {latestResult[0].AdamScore}".ToString()
            });
        }

        private void UpdateWinnigList(int winsJonny, int losesJonny, int draw)
        {
            lstWinnigs.Items.Clear();
            lstWinnigs.Items.Add(new Winnings
            {
                Spelare = "Jonny",
                Vinster = winsJonny,
                Förluster = losesJonny,
                Oavgjorda = draw,
                Vinstprocent = (winsJonny * 100) / (winsJonny + losesJonny + draw),
                Vinstdifferens = winsJonny - losesJonny
            });

            lstWinnigs.Items.Add(new Winnings
            {
                Spelare = "Adam",
                Vinster = losesJonny,
                Förluster = winsJonny,
                Oavgjorda = draw,
                Vinstprocent = (losesJonny * 100) / (winsJonny + losesJonny + draw),
                Vinstdifferens = losesJonny - winsJonny
            });
        }

        private void UpdateGoalList(int goalsJonny, int goalsAdam, int antalMatcher)
        {
            lstGoals.Items.Clear();
            lstGoals.Items.Add(new Goals
            {
                Spelare = "Jonny",
                Mål = goalsJonny,
                Måldifferens = goalsJonny-goalsAdam,
                Genomsnitt = Math.Round((double)goalsJonny /antalMatcher,2),
            });

            lstGoals.Items.Add(new Goals
            {
                Spelare = "Adam",
                Mål = goalsAdam,
                Måldifferens = goalsAdam-goalsJonny,
                Genomsnitt = Math.Round((double)goalsAdam/antalMatcher,2)
            });
        }

        private void UpdateResultList(dynamic results)
        {
            lstResults.Items.Clear();

            //Lägger in alla resultat från databasen i listan.
            foreach (var item in results)
            {
                lstResults.Items.Insert(0, new Results
                {
                    Datum = $"{item.Date:d MMM-yyyy}",
                    Match = item.MatchNr,
                    Jonny = $"{item.JonnyTeam} {item.JonnyScore}".ToString(),
                    Adam = $"{item.AdamTeam} {item.AdamScore}".ToString()
                });
            }
        }

        private void LoadDatabaseHistoryFromStart()
        {
            //Öppna databasen och filen.
            using (var db = new LiteDatabase("Historik.db"))
            {
                //Skapa collection.
                var db_result = db.GetCollection<MatchInfo>("Result");

                //Hämta all data från databasen.
                var results = GetWholeDataBase(db_result);

                //Kollar hur många resultat det finns i databasen.
                int matchNr = GetNumberOfMatches(db_result);

                LoadHistoryFromDatabase(results, CheckWins("W", db_result), CheckWins("L", db_result), CheckWins("D", db_result), GetGoals("Jonny", db_result), GetGoals("Adam", db_result), matchNr);
            }
        }

        private int GetGoals(string playerName, ILiteCollection<MatchInfo> db_result)
        {
            if(playerName == "Jonny")
            {
                return db_result.FindAll().Select(x => x.JonnyScore).Sum();
            }
            else
            {
                return db_result.FindAll().Select(x => x.AdamScore).Sum();
            }
        }

        private int GetNumberOfMatches(ILiteCollection<MatchInfo> db_result)
        {
            return db_result.FindAll().Count() + 1;
        }

        private object GetWholeDataBase(ILiteCollection<MatchInfo> db_result)
        {
            return db_result.FindAll().ToList();
        }

        private int CheckWins(string W_L_D, ILiteCollection<MatchInfo> db_result)
        {
            if (W_L_D == "W")
            {
                return db_result.FindAll().Where(x => x.JonnyScore > x.AdamScore).Count();
            }
            else if(W_L_D == "L")
            {
                return db_result.FindAll().Where(x => x.JonnyScore < x.AdamScore).Count();
            }
            else
            {
                return db_result.FindAll().Where(x => x.JonnyScore == x.AdamScore).Count();
            }
        }

        private void LoadHistoryFromDatabase(dynamic results, int winsJonny, int losesJonny, int draw, int goalsJonny, int goalsAdam, int antalMatcher)
        {
            if(results.Count > 0)
            {
                UpdateResultList(results);
                UpdateWinnigList(winsJonny, losesJonny, draw);
                UpdateGoalList(goalsJonny, goalsAdam, antalMatcher);
            }
        }

    }
}
