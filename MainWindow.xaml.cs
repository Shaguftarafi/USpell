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
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace MyFYP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> growingList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        string path = "D:\\GUIS\\WpfApplication3\\wordfrequency.txt";




        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Show();
        }


        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                textbox.Text = filename;

                System.IO.StreamReader sr = new System.IO.StreamReader(dlg.FileName);

                textbox.Text = System.IO.File.ReadAllText(filename);
                sr.Close();

            }
        }
        //Specl
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string a = searchbox.Text;
            SpellChecker shapexObject = new SpellChecker();
            char[] codeForInput = shapexObject.shapex(a);
            string LexiconWord;
            List<string> list = new List<string>(); //List is a name of Collection to contain possible correct words
            StreamReader file = new StreamReader(path);
            while ((LexiconWord = file.ReadLine()) != null)
            {
                char[] LexiconWordCode = shapexObject.shapex(LexiconWord);
                if (codeForInput[0] == LexiconWordCode[0] && codeForInput[1] == LexiconWordCode[1]
                   && codeForInput[2] == LexiconWordCode[2] && codeForInput[3] == LexiconWordCode[3]
                   && codeForInput[4] == LexiconWordCode[4])// && codeForInput[5] == LexiconWordCode[5]
                {
                    listbox1.Items.Add(LexiconWord);
                    //listBox8.Items.Add(LexiconWord);
                    //listBox7.Items.Add(LexiconWord);
                    list.Add(LexiconWord);
                }

            }// end while-loop
            string[] array1 = list.ToArray();
            allCorrectWords(array1); // allCorrectWords() is a function to store and sort
        }// end shapex button-function

        // **************************** End Shapex *********************************//
        // **************************** End Shapex *********************************//
        // **************************** End Shapex *********************************//



        // allCorrectWords() is a function to store and sort
        public void allCorrectWords(string[] abc)
        {
            //listbox.Items.Clear();
            // growingList has been declared as a public data object list
            for (int zz = 0; zz < abc.Length; zz++)
            {
                if (growingList.Contains(abc[zz])) ;
                else growingList.Add(abc[zz]);
            }
            string[] array = growingList.ToArray();     // array is a string array to contain all possible words
            int a = array.Length;
            string[,] _2D_array = new string[a, 2];    // _2D_array is a 2-D array to contain all possible words with their frequencies
            for (int i = 0; i < a; i++)
                _2D_array[i, 0] = array[i];             // copy all content of "array" to 2-D array at "column 0"
            string[] line = new string[2];              // it will contain splitted line of each word and its frequency  
            string LexiconWord;
            List<string> words_n_frequency = new List<string>(); // it will have a "two times length" than frequency-word-List
            StreamReader frequencyFile = new StreamReader(path);
            while ((LexiconWord = frequencyFile.ReadLine()) != null)
            {
                line = LexiconWord.Split('\t');
                words_n_frequency.Add(line[0]);
                words_n_frequency.Add(line[1]);
            }
            int b = (words_n_frequency.Count) / 2;
            string[,] _2D_words_n_frequency = new string[b, 2];

            // words_n_frequency_array.Length = 10,000

            string[] words_n_frequency_array = words_n_frequency.ToArray();
            int z = 1;
            for (int j = 0; j < words_n_frequency_array.Length; j += 2)
            {
                if (j == 0)
                {
                    _2D_words_n_frequency[j, 0] = words_n_frequency_array[j];
                    _2D_words_n_frequency[j, 1] = words_n_frequency_array[j + 1];
                }
                else
                {
                    _2D_words_n_frequency[j - z, 0] = words_n_frequency_array[j];
                    _2D_words_n_frequency[j - z, 1] = words_n_frequency_array[j + 1];
                    z++;
                }
            } // now "_2D_words_n_frequency[,]" has words in "column-0" and their frequencies in "column-1"

            for (int m = 0; m < a; m++) // a is length of "_2D_array"
            {
                for (int k = 0; k < b; k++) // a is half of length of "_2D_words_n_frequency[,]"
                {
                    if (_2D_array[m, 0] == _2D_words_n_frequency[k, 0])
                    {
                        _2D_array[m, 1] = _2D_words_n_frequency[k, 1];
                        break;
                    }
                }
            } // now "_2D_array[,]" has words in "column-0" and their frequencies in "column-1"
            // now sorting starts

            for (int i = 0; i < a - 1; i++)
            {
                for (int j = i + 1; j < a; j++)
                    if (Convert.ToInt64(_2D_array[j, 1]) > Convert.ToInt64(_2D_array[i, 1]))
                    {
                        string[,] tmp = new string[1, 2];
                        tmp[0, 0] = _2D_array[i, 0];
                        tmp[0, 1] = _2D_array[i, 1];
                        _2D_array[i, 0] = _2D_array[j, 0];
                        _2D_array[i, 1] = _2D_array[j, 1];
                        _2D_array[j, 0] = tmp[0, 0];
                        _2D_array[j, 1] = tmp[0, 1];
                    }
            }
            for (int i = 0; (i < 5 && i < a && _2D_array[i, 1] != null); i++)
                listbox1.Items.Add(_2D_array[i, 0]);


        }



        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {



            Process[] processlist = Process.GetProcesses(".");

            foreach (Process p in processlist)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    TreeViewItem item = new TreeViewItem();
                    // item.MouseDoubleClick += new MouseButtonEventHandler(item_MouseDoubleClick);
                    item.Tag = p;
                    item.Header = p.MainWindowTitle.ToString();
                    listbox1.Items.Add(item);

                    // Icon ico = Icon.ExtractAssociatedIcon(p.MainModule.FileName);
                }

            }
        }


        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        } //End of allCorrectWords()
    }

}

