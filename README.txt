=================================================================
Projet PPE 1534 QuadTowers, 2015-2016
=================================================================


Le projet est disponible sur Github à l'adresse :
https://github.com/quadtowers/soutenance

Le dossier QuadTowers contient les fichiers sources et executables, ainsi que certaines bibliothèques dynamiques de fonctions (.dll) nécessaires à l'utilisation du code sur Visual Studio 2013.

Ces documents sont détaillés ci-dessous :

=================================================================

- bin : dossier contenant les fichiers binaires, executables, crées lors de la compilation du projet.

-- Debug : dossier contenant les fichiers binaires, executables, crées lors de la compilation du projet en mode Debug

--- Emgu.CV.dll
--- Emgu.CV.UI.dll
--- Emgu.CV.UI.xml
--- Emgu.CV.xml
--- Emgu.Util.dll
--- Emgu.Util.xml

Ces bibliothèques dynamiques Emgu sont des fichiers nécessaires à la bonne execution du code car elles permettent aux bibliothèques et fonctions OpenCV d'être utilisées sous C#.



--- Microsoft.Kinect.dll
--- Microsoft.Kinect.xml

Ces bibliothèques dynamiques Microsoft Kinect contiennent les fonctions liées à la Kinect afin de faire de l'enregistrement et de la détection avec. Elles doivent être issues de la version 1.8 du SDK Kinect de Microsoft.



--- opencv_core231.dll
--- opencv_highgui231.dll
--- opencv_imgproc231.dll

OpenCV est une bibliothèque de fonctions cross-platforme qui permet le traitement d'images en temps réel. Nous l'utilisons pour afficher les enregistrements Kinect et travailler dessus (graphes de profondeurs, blob de détection, etc...)



--- QuadTowers.exe :
Fichier executable de l'interface développeur du projet.
Il lance la fenêtre WPF décrite par le fichier Window1.xaml.

--- QuadTowers.exe.config
--- QuadTowers.pdb
--- QuadTowers.vshost.exe
--- QuadTowers.vshost.exe.confi

Fichiers crées par Visual Studio 2013 à la compilation du projet.



--- system.windows.controls.datavisualization.toolkit.dll

Bibliothèque de fonctions permettant le contrôle des graphes.

--- WPFToolkit.dll

Bibliothèque de fonctions rassemblant des fonctions WPF.

--- WriteableBitmapEx.Wpf.dll

Bibliothèque étendue de fonctions permettant la manipulation et l'édition d'images.

--- ZedGraph.dll

Bibliothèque de classes, user controls et fonctions permettant de dessiner des lignes, barres de progressions et autres graphiques.



=================================================================

- Images : dossier contenant les images utilisées dans le code
-- Status.png : image importée du tutoriel de base


=================================================================

- References : dossier contenant les fichiers .dll nécessaire à l'utilisation du code sur Visual Studio 2013, et à copier sur le PC au préalable

--- Emgu.CV.UI.dll
--- Emgu.CV.UI.xml
--- Emgu.CV.xml
--- Emgu.Util.dll
--- Emgu.Util.xml

Ces bibliothèques dynamiques Emgu sont des fichiers nécessaires à la bonne execution du code car elles permettent aux bibliothèques et fonctions OpenCV d'être utilisées sous C#.



--- Microsoft.Kinect.dll
--- Microsoft.Kinect.xml

Ces bibliothèques dynamiques Microsoft Kinect contiennent les fonctions liées à la Kinect afin de faire de l'enregistrement et de la détection avec. Elles doivent être issues de la version 1.8 du SDK Kinect de Microsoft.




--- opencv_core231.dll
--- opencv_highgui231.dll
--- opencv_imgproc231.dll

OpenCV est une bibliothèque de fonctions cross-platforme qui permet le traitement d'images en temps réel. Nous l'utilisons pour afficher les enregistrements Kinect et travailler dessus (graphes de profondeurs, blob de détection, etc...)



--- system.windows.controls.datavisualization.toolkit.dll

Bibliothèque de fonctions permettant le contrôle des graphes.

--- WPFToolkit.dll

Bibliothèque de fonctions rassemblant des fonctions WPF.

--- WriteableBitmapEx.Wpf.dll

Bibliothèque étendue de fonctions permettant la manipulation et l'édition d'images.

--- ZedGraph.dll

Bibliothèque de classes, user controls et fonctions permettant de dessiner des lignes, barres de progressions et autres graphiques.



=================================================================

- affichage.xaml
Fichier contenant un User Control WPF avec un simple canvas.

- affichage.xaml.cs
Code lié au User Control WPF avec un canvas, il contient une fonction afficherTerrain permettant de situer sur le canvas des rectangles représentant la liste de points d'une instance terrain reçue en argument. Ces rectangles respectent la taille et l'emplacement enregistrés dans chaque point, en les représentants proportionellement au terrain.

- App.config
- App.xaml
- App.xaml.cs

Fichiers de configuration du projet d'application Windows, ils permettent notamment de distinguer la fenêtre de départ au lancement du logiciel.

- dataKinect.cs

Structure dans laquelle sont enregistrés les centres et aires de chaque objet détecté par la Kinect, ainsi que le nombre d'objets détectés. Cette structure sert de transition entre la Kinect et tout le reste du code.
 
- drawpoint.cs

Classe héritant de Shape qui permet la création d'un Shape personnalisé de la taille du pion qu'il doit représenter.

- ImageHelpers.cs

Code provenant du tutorial de base, aidant à la fabrication de graphes de profondeurs dans MainWindows.xaml.

- INSTALL.txt

Fichier expliquant les étapes nécessaires pour utiliser mais aussi modifier le code QuadTowers.

- MainWindow.xaml
- MainWindow.xaml.cs

Fichiers crées en important et modifiant un tutoriel en ligne. Cette fenêtre WPF permet finalement d'afficher ce que la Kinect enregistrait, d'en faire un graphe de profondeur et d'en différencier les formes, qu'on fait encadrer en rouge.

- Pion.cs

Classe définissant un pion lambda, son nom, son historique de déplacement, au travers d'une liste de PointF, et sa position.

- point.cs

Class intermédiaire représentant un pion de par son nom et ses dernières positions.

- points_view.xaml

Fichier User Control WPF contenant un listview à trois colonnes : Nom, Avant, Après.

- points_view.xaml.cs

Code associé au User Control WPF afin d'afficher les pions d'une liste de points quelconque.

- QuadTowers.csproj
- QuadTowers.csproj.user

Code regroupant tout notre projet sous C#.

- README.txt

Le document présent qui permet d'expliquer tous les documents contenus dans le dossier QuadTowers.

- terrain.cs

Classe représentant le terrain du plateau sur lequel se base le projet, afin de facilier les calculs. Cette classe analyse chaque nouvelle structure dataKinect retournée après la capture et la rajoute aux points déjà repérés.

- Window1.xaml

Fichier contenant une fenêtre WPF, c'est la fenêtre lancée au démarrage et contenant les User Controls affichage et points_view.

- Window1.xaml.cs

Code lié à la fenêtre WPF, il permet de choisir le début et la fin d'une capture d'écran avec la Kinect et d'en afficher les enregistrements dans les User Controls présnets.




