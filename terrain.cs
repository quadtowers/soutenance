using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KinectWPFOpenCV
{
    [Serializable]
    public class terrain
    {
        SizeF taille;
        List<Pion> Pions = new List<Pion>();
        int nombre_obj;

        public terrain(float x, float y)
        {
            taille.Width = x;
            taille.Height = y;
            nombre_obj = 0;
        }

        public SizeF myTaille
        {
            get { return taille; }
            set { taille = value; }
        }
        public List<Pion> myPions
        {
            get { return Pions; }
            set { Pions = value; }
        }
        public int myCompte
        {
            get { return nombre_obj; }
            set { nombre_obj = value; }
        }

        public void Save(dataKinect donnees)
        {
            myPions.Clear();
            nombre_obj = 0;
            for(int i=0; i<donnees.nb_obj; i++)
            {
                Pion newPion = new Pion();
                newPion.myPCoord.Add(donnees.centre_obj[i]);
                newPion.myPSize = donnees.aire_obj[i];
                newPion.myPName = i.ToString();

                Pions.Add(newPion);
                nombre_obj++;
                //MessageBox.Show("Added");
            }

        }

        public void Analyse(dataKinect donnees)
        {
            if (Pions.Count < 1)
            {
                Save(donnees);
            }
            else
            {
                List<Pion> tempTab = Pions;
                int changement = 1;
                int count_init = tempTab[0].myPCoord.Count;

                // Compare points
                for (int i = 0; i < donnees.nb_obj; i++)
                {
                    bool trouvé = false;

                    if (changement != 0 && (donnees.nb_obj >= nombre_obj))
                    {
                            IEnumerable<Pion> pions = tempTab as IEnumerable<Pion>;
                            foreach (Pion pion in pions.ToList())
                            {
                                int count = pion.myPCoord.Count;
                                if (((donnees.centre_obj[i].X < (pion.myPCoord[count - 1].X + 0.05 * taille.Width)) && (donnees.centre_obj[i].X > (pion.myPCoord[count - 1].X - 0.05 * taille.Width))) && ((donnees.centre_obj[i].Y < (pion.myPCoord[count - 1].Y + 0.05 * taille.Height)) && (donnees.centre_obj[i].Y > (pion.myPCoord[count - 1].Y - 0.05 * taille.Height))))
                                {
                                    pion.AddCoord(donnees.centre_obj[i].X, donnees.centre_obj[i].Y);
                                    pion.myPSize = donnees.aire_obj[i];
                                    trouvé = true;
                                }
                                else if ((donnees.nb_obj > nombre_obj))
                                {
                                    Pion newPion = new Pion();
                                    newPion.myPCoord.Add(donnees.centre_obj[i]);
                                    newPion.myPSize = donnees.aire_obj[i];
                                    newPion.myPName = i.ToString();

                                    tempTab.Add(newPion);
                                    nombre_obj++;
                                    //MessageBox.Show("Added");
                                    changement = 0;
                                    trouvé = true;
                                }
                            }
                        }

                        if (!trouvé && changement != 0)
                        {
                            //MessageBox.Show("Hello");
                            IEnumerable<Pion> pions = tempTab as IEnumerable<Pion>;
                            foreach (Pion pion in pions.ToList())
                            {
                                if ((pion.myPCoord.Count == count_init) && donnees.nb_obj == nombre_obj && changement != 0)
                                {       pion.AddCoord(donnees.centre_obj[i].X, donnees.centre_obj[i].Y);
                                        pion.myPSize = donnees.aire_obj[i];
                                        changement = 0;
                                       // MessageBox.Show("Changed");
                                    }
                                    
                                }
                             }
                        }


                if (donnees.nb_obj < nombre_obj)
                {
                    IEnumerable<Pion> pions2 = tempTab as IEnumerable<Pion>;
                    foreach (Pion pion in pions2.ToList())
                    {
                        if ((pion.myPCoord.Count == count_init) && donnees.nb_obj < nombre_obj && changement != 0)
                        {
                            tempTab.Remove(pion);
                           // MessageBox.Show("Deleted");
                            changement = 0;
                            nombre_obj--;
                        }
                    }
                }
                
                    Pions = tempTab;
                    //MessageBox.Show(tempTab.Count.ToString());
            }


            }


        


    }
}

