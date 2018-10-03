using System;
using System.IO;
using System.Timers;

namespace ASRR.Core
{
    /// <summary>
    /// Zegar sluzacy do zapisywania danych
    /// </summary>
    public class ClockViewModel : BaseViewModel
    {
        #region Constructor
        
        public ClockViewModel()
        {
            timer = new Timer()
            {
                Interval = 1.0
            };
            
            timer.Elapsed += Timer_Elapsed;            
        }


        #endregion

        #region Private Members
        
        /// <summary>
        /// Zegar
        /// </summary>
        Timer timer;

        /// <summary>
        /// Zmienna pomocnicza do zapisywania plikow
        /// </summary>
        private int i = 0;

        /// <summary>
        /// Ciag znakow do zapisu
        /// </summary>
        private string description;

        /// <summary>
        /// Sciezka do zapisu pliku
        /// </summary>
        private string filePath;

        #endregion

        #region Public Properties

        /// <summary>
        /// Czas obecny przekonwertowany do string
        /// </summary>
        public string Time { get { return DateTime.Now.ToString("T"); } }

        #endregion

        #region Public Methods

        /// <summary>
        /// dolaczanie do tekstu kolejnych wystapien pojazdow
        /// </summary>
        /// <param name="text"></param>
        public void DataToSave(string text)
        {
            description += text;
        }

        /// <summary>
        /// Inicjalizacja zbierania danych do pliku
        /// </summary>
        public void StartCollectData()
        {            
            PathAndFile();
            timer.Start();
        }
        
        /// <summary>
        /// Zatrzymanie zbierania danych
        /// </summary>
        public void StopCollectData()
        {
            timer.Stop();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// zapisywanie do pliku danych
        /// </summary>
        /// <param name="text">tekst do zapisania</param>      
        private async void WriteToFile(string text)
        {
            if (text != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    await writer.WriteAsync(text);
                }
            }
        }

        /// <summary>
        /// Ustawienie sciezki i stworzenie pliku
        /// </summary>
        private void PathAndFile()
        {
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" +
                          DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year +
                          " Godz " + DateTime.Now.Hour + "-" + DateTime.Now.Minute +
                          " - Wlot " + DI.sideMenuVM.SelectedInlet + " - LiczbaPasow " + (DI.laneDirectionPickerVM.NumberOfLanes + 1) + ".asrr";

            //stworzenie pliku
            File.Create(filePath).Close();
            File.SetAttributes(filePath, FileAttributes.Normal);

            //ustawienia skrzyzowania
            string config = "+CONFIG+" + Environment.NewLine +
                            "+INLET+*" + DI.sideMenuVM.SelectedInlet + "*" + Environment.NewLine +
                            //"+TRAFFICLIGHT+*" + InletInfo.IsTrafficLight + "*" + Environment.NewLine +
                            "+NUMBEROFLANES+*" + (DI.laneDirectionPickerVM.NumberOfLanes + 1) + "*" + Environment.NewLine +
                            "+LANE1+*" + DI.laneDirectionPickerVM.CurrentDirectionLane1 + "*" + Environment.NewLine +
                            "+LANE2+*" + DI.laneDirectionPickerVM.CurrentDirectionLane2 + "*" + Environment.NewLine +
                            "+LANE3+*" + DI.laneDirectionPickerVM.CurrentDirectionLane3 + "*" + Environment.NewLine +
                            "+LANE4+*" + DI.laneDirectionPickerVM.CurrentDirectionLane4 + "*" + Environment.NewLine +
                            "+ENDCONFIG+" + Environment.NewLine +
                            "+START+" + Environment.NewLine;

            //poczatkowy tekst zapisany do pliku
            string startText = "Czas Przyjazdu;Czas Odjazdu;Typ Pojazdu;Pas;Wybrany kierunek" + Environment.NewLine;

            //dopisanie do configu poczatkowego tekstu
            config += startText;

            //zapisywanie do pliku
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(config);
            }
        }

        #endregion

        #region Event Methods

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            i++;
            OnPropertyChanged("Time");
            
            if (i > 10)
            {
                WriteToFile(description);             
                description = null;
                i = 0;
            }
        }

        #endregion

    }
}
