using Emgu.CV;
using Emgu.CV.Structure;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms.DataVisualization.Charting;

using System.Globalization;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace KinectWPFOpenCV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Déclarations Kinect & Capteur de profondeur
        KinectSensor sensor;
        WriteableBitmap depthBitmap;
        WriteableBitmap colorBitmap;
        DepthImagePixel[] depthPixels;
        byte[] colorPixels;

        Boolean CaptDone=false;
        Boolean CaptDone2=false;
        //imageTest    // Testdimobj
        int o;
        public struct dataKinect
        {
            public MCvBox2D box_obj;
            public System.Drawing.PointF[] tab_center; //tab avec centre de chaque obj
            public SizeF[] tab_area; // aires de chaque objet + dimensions
            public int nb_obj; // nb d'objets
        } dataKinect donnees;
      

        //Déclaration compteur
        int blobCount = 0;

        //Déclaration des variables de la fenêtre d'affichage
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
            this.MouseDown += MainWindow_MouseDown;

            //INITIALIZATION STRUCT
            donnees.nb_obj = 0;
            donnees.tab_area = new SizeF[25];
          
            donnees.tab_center = new System.Drawing.PointF[25];

            for(o=0;o<25;o++)
            {
                donnees.tab_area[o] = new SizeF(-1, -1);
                donnees.tab_center[o] = new System.Drawing.Point(-1, -1);

            }

        }

        // Chargement de la (des) fenêtre(s) d'affichage
        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            //Tout potentiel Sensor en état 'connecté' et un Sensor
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            //Si une Kinect est connectée
            if (null != this.sensor)
            {
                //Initialisation et démarrage des capteurs de Vidéo et de Profondeur
                this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                this.colorPixels = new byte[this.sensor.ColorStream.FramePixelDataLength];
                this.depthPixels = new DepthImagePixel[this.sensor.DepthStream.FramePixelDataLength];
                //Initialisation de la Bitmap
                this.colorBitmap = new WriteableBitmap(this.sensor.ColorStream.FrameWidth, this.sensor.ColorStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);
                this.depthBitmap = new WriteableBitmap(this.sensor.DepthStream.FrameWidth, this.sensor.DepthStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);
                this.colorImg.Source = this.colorBitmap;

                // Correspond à un EventHandler appelé pour réafficher la vidéo & la profondeur à chaque fois que l'image est raffraichie
                this.sensor.AllFramesReady += this.sensor_AllFramesReady;

                //Test des exceptions E/S (=IOException)
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            //Si aucun sensor n'est connecté : affiche 'pas de Kinect trouvé'
            if (null == this.sensor)
            {
                this.outputViewbox.Visibility = System.Windows.Visibility.Collapsed;
                this.txtError.Visibility = System.Windows.Visibility.Visible;
                this.txtInfo.Text = "No Kinect Found";

            }

        }

        //Démarrage des captations Vidéo & Profondeur
        private void sensor_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {

            BitmapSource depthBmp = null;
            blobCount = 0;

            using (ColorImageFrame colorFrame = e.OpenColorImageFrame()) //Récupère l'image de l'objet
            {
                using (DepthImageFrame depthFrame = e.OpenDepthImageFrame()) //Récupère la profondeur de l'image
                {
                    if (depthFrame != null) //Si la profondeur != null
                    {

                        blobCount = 0;

                        //Enregistrement de la profondeur dans la bitmap (Depth entre une valeur min et une valeur max : sliderMin(/Max).Value)
                        depthBmp = depthFrame.SliceDepthImage((int)sliderMin.Value, (int)sliderMax.Value); //SliceDepthImage : Bitmap (Cf ImageHelpers.cs)

                        //Image : définie par <Color, Depth>. openCVImg crée à partir de la bitmap (depthBmp)
                        Image<Bgr, Byte> openCVImg = new Image<Bgr, byte>(depthBmp.ToBitmap());
                        //On récupère l'image openCVImg en gris (soucis de gestion de contraste askip :p)
                        Image<Gray, byte> gray_image = openCVImg.Convert<Gray, byte>();

                        using (MemStorage stor = new MemStorage()) //MemStorage() : fonction de stockage dynamique des données (Organisation : liste de blocks mémoires)
                        {
                            //Find contours with no holes try CV_RETR_EXTERNAL to find holes & Sauvergarde des contours trouvés
                            Contour<System.Drawing.Point> contours = gray_image.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL, stor);

                            //Pour tous les contours non nuls de i=0 à i='dernier contours enregistré'
                            for (int i = 0; contours != null; contours = contours.HNext)
                            {
                                i++;

                                //Si l'aire du contours i est entre sliderMinSize.Value^2 & sliderMaxSize.Value^2 
                                if ((contours.Area > Math.Pow(sliderMinSize.Value, 2)) && (contours.Area < Math.Pow(sliderMaxSize.Value, 2))) // Math.Pow : Retourne var1^var2 (=(sliderMinSize.Value)^2, p.ex)
                                {
                                    //Box de repérage : box = contour de l'aire min du rectangle traçable autour de l'objet
                                    MCvBox2D box = contours.GetMinAreaRect(); //MCvBox2D : ?

                                    //Trace une box rouge autour de l'objet détecté
                                    openCVImg.Draw(box, new Bgr(System.Drawing.Color.Red), 2);

                                    blobCount++; //blobCount : compteur d'objets différenciés

                                    while(CaptDone==true)
                                    {
                                        //assoscier image de lobjet à picture box  -> imageTest  
                                        donnees.tab_center[donnees.nb_obj]=box.center;
                                        donnees.tab_area[donnees.nb_obj] = box.size; //size contient la largeur et la longueur
                                        donnees.box_obj = contours.GetMinAreaRect();
                                     

                                        // Testdimobj
                                        CaptDone = false;
                                    }
                                    if(CaptDone2==true)
                                    {
                                        donnees.nb_obj++;
                                        CaptDone2 = false;
                                    }

                                }
                            }
                        }


                        this.outImg.Source = ImageHelpers.ToBitmapSource(openCVImg); //Image dans la Bitmap                       
                        txtBlobCount.Text = blobCount.ToString(); // Affichage du nombres d'objets repérés dans la fenêtre d'affichage
                    }

                 

                }

                //Création Bitmap de la video
                if (colorFrame != null) //Video != null
                {

                    colorFrame.CopyPixelDataTo(this.colorPixels);
                    this.colorBitmap.WritePixels(new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight), this.colorPixels, this.colorBitmap.PixelWidth * sizeof(int), 0);

                }


            }
        }

        #region Window Stuff

        //Mouvement d'entrainement d'une fenêtre par la sourie
        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove(); //Cf DragMove() WPF sur google :p
        }

        //Arrêt de la kinect
        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }

        //Bouton de fermeture de la fenêtre
        private void CloseBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CaptDone = true;
            CaptDone2 = false;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CaptDone = false;
            CaptDone2 = true;

            MessageBox.Show(donnees.nb_obj.ToString());
        }

 
    }
}
