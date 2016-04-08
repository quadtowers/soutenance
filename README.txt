=================================================================
Projet PPE 1534 QuadTowers, 2015-2016
=================================================================


Le projet est disponible sur Github � l'adresse :
https://github.com/quadtowers/soutenance

Le dossier QuadTowers contient les fichiers sources et executables, ainsi que certaines biblioth�ques dynamiques de fonctions (.dll) n�cessaires � l'utilisation du code sur Visual Studio 2013.

Ces documents sont d�taill�s ci-dessous :

=================================================================

- bin : dossier contenant les fichiers binaires, executables, cr�es lors de la compilation du projet.

-- Debug : dossier contenant les fichiers binaires, executables, cr�es lors de la compilation du projet en mode Debug

--- Emgu.CV.dll
--- Emgu.CV.UI.dll
--- Emgu.CV.UI.xml
--- Emgu.CV.xml
--- Emgu.Util.dll
--- Emgu.Util.xml

Ces biblioth�ques dynamiques Emgu sont des fichiers n�cessaires � la bonne execution du code car elles permettent aux biblioth�ques et fonctions OpenCV d'�tre utilis�es sous C#.



--- Microsoft.Kinect.dll
--- Microsoft.Kinect.xml

Ces biblioth�ques dynamiques Microsoft Kinect contiennent les fonctions li�es � la Kinect afin de faire de l'enregistrement et de la d�tection avec. Elles doivent �tre issues de la version 1.8 du SDK Kinect de Microsoft.



--- opencv_core231.dll
--- opencv_highgui231.dll
--- opencv_imgproc231.dll

OpenCV est une biblioth�que de fonctions cross-platforme qui permet le traitement d'images en temps r�el. Nous l'utilisons pour afficher les enregistrements Kinect et travailler dessus (graphes de profondeurs, blob de d�tection, etc...)



--- QuadTowers.exe :
Fichier executable de l'interface d�veloppeur du projet.
Il lance la fen�tre WPF d�crite par le fichier Window1.xaml.

--- QuadTowers.exe.config
--- QuadTowers.pdb
--- QuadTowers.vshost.exe
--- QuadTowers.vshost.exe.confi

Fichiers cr�es par Visual Studio 2013 � la compilation du projet.



--- system.windows.controls.datavisualization.toolkit.dll

Biblioth�que de fonctions permettant le contr�le des graphes.

--- WPFToolkit.dll

Biblioth�que de fonctions rassemblant des fonctions WPF.

--- WriteableBitmapEx.Wpf.dll

Biblioth�que �tendue de fonctions permettant la manipulation et l'�dition d'images.

--- ZedGraph.dll

Biblioth�que de classes, user controls et fonctions permettant de dessiner des lignes, barres de progressions et autres graphiques.



=================================================================

- Images : dossier contenant les images utilis�es dans le code
-- Status.png : image import�e du tutoriel de base


=================================================================

- References : dossier contenant les fichiers .dll n�cessaire � l'utilisation du code sur Visual Studio 2013, et � copier sur le PC au pr�alable

--- Emgu.CV.UI.dll
--- Emgu.CV.UI.xml
--- Emgu.CV.xml
--- Emgu.Util.dll
--- Emgu.Util.xml

Ces biblioth�ques dynamiques Emgu sont des fichiers n�cessaires � la bonne execution du code car elles permettent aux biblioth�ques et fonctions OpenCV d'�tre utilis�es sous C#.



--- Microsoft.Kinect.dll
--- Microsoft.Kinect.xml

Ces biblioth�ques dynamiques Microsoft Kinect contiennent les fonctions li�es � la Kinect afin de faire de l'enregistrement et de la d�tection avec. Elles doivent �tre issues de la version 1.8 du SDK Kinect de Microsoft.




--- opencv_core231.dll
--- opencv_highgui231.dll
--- opencv_imgproc231.dll

OpenCV est une biblioth�que de fonctions cross-platforme qui permet le traitement d'images en temps r�el. Nous l'utilisons pour afficher les enregistrements Kinect et travailler dessus (graphes de profondeurs, blob de d�tection, etc...)



--- system.windows.controls.datavisualization.toolkit.dll

Biblioth�que de fonctions permettant le contr�le des graphes.

--- WPFToolkit.dll

Biblioth�que de fonctions rassemblant des fonctions WPF.

--- WriteableBitmapEx.Wpf.dll

Biblioth�que �tendue de fonctions permettant la manipulation et l'�dition d'images.

--- ZedGraph.dll

Biblioth�que de classes, user controls et fonctions permettant de dessiner des lignes, barres de progressions et autres graphiques.



=================================================================

- affichage.xaml
Fichier contenant un User Control WPF avec un simple canvas.

- affichage.xaml.cs
Code li� au User Control WPF avec un canvas, il contient une fonction afficherTerrain permettant de situer sur le canvas des rectangles repr�sentant la liste de points d'une instance terrain re�ue en argument. Ces rectangles respectent la taille et l'emplacement enregistr�s dans chaque point, en les repr�sentants proportionellement au terrain.

- App.config
- App.xaml
- App.xaml.cs

Fichiers de configuration du projet d'application Windows, ils permettent notamment de distinguer la fen�tre de d�part au lancement du logiciel.

- dataKinect.cs

Structure dans laquelle sont enregistr�s les centres et aires de chaque objet d�tect� par la Kinect, ainsi que le nombre d'objets d�tect�s. Cette structure sert de transition entre la Kinect et tout le reste du code.
 
- drawpoint.cs

Classe h�ritant de Shape qui permet la cr�ation d'un Shape personnalis� de la taille du pion qu'il doit repr�senter.

- ImageHelpers.cs

Code provenant du tutorial de base, aidant � la fabrication de graphes de profondeurs dans MainWindows.xaml.

- INSTALL.txt

Fichier expliquant les �tapes n�cessaires pour utiliser mais aussi modifier le code QuadTowers.

- MainWindow.xaml
- MainWindow.xaml.cs

Fichiers cr�es en important et modifiant un tutoriel en ligne. Cette fen�tre WPF permet finalement d'afficher ce que la Kinect enregistrait, d'en faire un graphe de profondeur et d'en diff�rencier les formes, qu'on fait encadrer en rouge.

- Pion.cs

Classe d�finissant un pion lambda, son nom, son historique de d�placement, au travers d'une liste de PointF, et sa position.

- point.cs

Class interm�diaire repr�sentant un pion de par son nom et ses derni�res positions.

- points_view.xaml

Fichier User Control WPF contenant un listview � trois colonnes : Nom, Avant, Apr�s.

- points_view.xaml.cs

Code associ� au User Control WPF afin d'afficher les pions d'une liste de points quelconque.

- QuadTowers.csproj
- QuadTowers.csproj.user

Code regroupant tout notre projet sous C#.

- README.txt

Le document pr�sent qui permet d'expliquer tous les documents contenus dans le dossier QuadTowers.

- terrain.cs

Classe repr�sentant le terrain du plateau sur lequel se base le projet, afin de facilier les calculs. Cette classe analyse chaque nouvelle structure dataKinect retourn�e apr�s la capture et la rajoute aux points d�j� rep�r�s.

- Window1.xaml

Fichier contenant une fen�tre WPF, c'est la fen�tre lanc�e au d�marrage et contenant les User Controls affichage et points_view.

- Window1.xaml.cs

Code li� � la fen�tre WPF, il permet de choisir le d�but et la fin d'une capture d'�cran avec la Kinect et d'en afficher les enregistrements dans les User Controls pr�snets.




