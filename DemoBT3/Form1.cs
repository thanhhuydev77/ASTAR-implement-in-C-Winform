using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoBT3
{
    public partial class Form1 : Form
    {
        string start = string.Empty;
        string end = string.Empty;
        List<Place> AllPlace = new List<Place>();
        List<Place> OPEN;
        List<Place> CLOSE;
        int Length;
        Pen pen = new Pen(Color.Red, 5);
        Pen pen2 = new Pen(Color.Green, 5);
        Graphics grphx;

        Place FindByName(string name)
        {
            for (int i = 0; i < AllPlace.Count(); i++)
            {
                if (AllPlace[i].Name == name)
                    return AllPlace[i];
            }
            return null;
        }
        public Form1()
        {
            InitializeComponent();
            InitPlace();
            InitRelation();
            grphx = pictureBox1.CreateGraphics();
        }

        private void InitRelation()
        {

            Place Oradea = FindByName("Oradea");
            Place Eforie = FindByName("Eforie");
            Place Hirsova = FindByName("Hirsova");
            Place Vaslui = FindByName("Vaslui");
            Place Iasi = FindByName("Iasi");
            Place Neamt = FindByName("Neamt");
            Place Urziceni = FindByName("Urziceni");
            Place Bucharest = FindByName("Bucharest");
            Place Giurgiu = FindByName("Giurgiu");
            Place Fagaras = FindByName("Fagaras");
            Place Pitesti = FindByName("Pitesti");
            Place Craiova = FindByName("Craiova");
            Place RimnicuVilxea = FindByName("RimnicuVilxea");
            Place Lugoj = FindByName("Lugoj");
            Place Sibiu = FindByName("Sibiu");
            Place Drobeta = FindByName("Drobeta");
            Place Mehadia = FindByName("Mehadia");
            Place Timisoara = FindByName("Timisoara");
            Place Arad = FindByName("Arad");
            Place Zerind = FindByName("Zerind");


            Oradea.SetRoundPlaces(new List<NearPlace> { new NearPlace(Zerind, 71), new NearPlace(Sibiu, 151) });
            Zerind.SetRoundPlaces(new List<NearPlace> { new NearPlace(Oradea, 71), new NearPlace(Arad, 75) });
            Arad.SetRoundPlaces(new List<NearPlace> { new NearPlace(Zerind, 75), new NearPlace(Sibiu, 140), new NearPlace(Timisoara, 118) });
            Timisoara.SetRoundPlaces(new List<NearPlace> { new NearPlace(Arad, 118), new NearPlace(Lugoj, 111) });
            Lugoj.SetRoundPlaces(new List<NearPlace> { new NearPlace(Timisoara, 111), new NearPlace(Mehadia, 70) });
            Mehadia.SetRoundPlaces(new List<NearPlace> { new NearPlace(Lugoj, 70), new NearPlace(Drobeta, 75) });
            Drobeta.SetRoundPlaces(new List<NearPlace> { new NearPlace(Mehadia, 75), new NearPlace(Craiova, 120) });
            Sibiu.SetRoundPlaces(new List<NearPlace> { new NearPlace(Oradea, 151), new NearPlace(Arad, 140), new NearPlace(Fagaras, 99), new NearPlace(RimnicuVilxea, 80) });
            RimnicuVilxea.SetRoundPlaces(new List<NearPlace> { new NearPlace(Sibiu, 80), new NearPlace(Craiova, 146), new NearPlace(Pitesti, 97) });
            Craiova.SetRoundPlaces(new List<NearPlace> { new NearPlace(Drobeta, 120), new NearPlace(RimnicuVilxea, 146), new NearPlace(Pitesti, 138) });
            Pitesti.SetRoundPlaces(new List<NearPlace> { new NearPlace(RimnicuVilxea, 97), new NearPlace(Craiova, 138), new NearPlace(Bucharest, 101) });
            Fagaras.SetRoundPlaces(new List<NearPlace> { new NearPlace(Sibiu, 99), new NearPlace(Bucharest, 211) });
            Bucharest.SetRoundPlaces(new List<NearPlace> { new NearPlace(Giurgiu, 90), new NearPlace(Pitesti, 101), new NearPlace(Fagaras, 211), new NearPlace(Urziceni, 85) });
            Giurgiu.SetRoundPlaces(new List<NearPlace> { new NearPlace(Bucharest, 90) });
            Neamt.SetRoundPlaces(new List<NearPlace> { new NearPlace(Iasi, 87) });
            Iasi.SetRoundPlaces(new List<NearPlace> { new NearPlace(Neamt, 87), new NearPlace(Vaslui, 92) });
            Vaslui.SetRoundPlaces(new List<NearPlace> { new NearPlace(Iasi, 92), new NearPlace(Urziceni, 142) });
            Urziceni.SetRoundPlaces(new List<NearPlace> { new NearPlace(Bucharest, 85), new NearPlace(Vaslui, 142), new NearPlace(Hirsova, 98) });
            Hirsova.SetRoundPlaces(new List<NearPlace> { new NearPlace(Urziceni, 98), new NearPlace(Eforie, 86) });
            Eforie.SetRoundPlaces(new List<NearPlace> { new NearPlace(Hirsova, 86) });

        }

        private void InitPlace()
        {
            foreach (var cb in Controls.OfType<CheckBox>())
            {
                Place a = new Place(cb.Name.Substring(2, cb.Name.Length - 2), cb.Location.X+2, cb.Location.Y+2);
                AllPlace.Add(a);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbOradea_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = ((CheckBox)sender);


            if (check.Checked)
            {
                if (start == string.Empty)
                {
                    start = check.Name.Substring(2, (check.Name.Length - 2));

                }
                else if (end == string.Empty)
                {
                    end = check.Name.Substring(2, ((CheckBox)sender).Name.Length - 2);
                }
                else
                {
                    string tempend = end;
                    check.Checked = false;
                    end = tempend;
                }

            }
            else
            {
                if (check.Name.Substring(2, ((CheckBox)sender).Name.Length - 2) == end)
                {

                    end = string.Empty;

                }
                else if (check.Name.Substring(2, ((CheckBox)sender).Name.Length - 2) == start)
                {
                    start = end;
                    end = string.Empty;
                }
            }
            lbStartPoint.Text = start;
            lbEndPoint.Text = end;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            //search place
            Place startPlace = FindByName(start);
            Place EndPlace = FindByName(end);
            if (startPlace == null || EndPlace == null)
            {
                MessageBox.Show("co loi");
                return;
            }
            calculateH(startPlace);
            
            //MessageBox.Show("start place " + startPlace.Name + " locate:X = " + startPlace.GetPoint().X + " ,Y = " + startPlace.GetPoint().Y + ",H =" + startPlace.GetH());
            //MessageBox.Show("end place " + EndPlace.Name + " locate:X = " + EndPlace.GetPoint().X + " ,Y = " + EndPlace.GetPoint().Y + ",H =" + EndPlace.GetH());
           for(int i = 0; i < AllPlace.Count();i++)
            {
                AllPlace[i].Parent = null;
            }
            bool issuccess = SearchRoute(startPlace, EndPlace);
            if(issuccess)
            {
                pictureBox1.Refresh();
                // print route
                //pictureBox1.Invalidate();
                printRoute();
                lbLength.Text = Length.ToString();
            }

        }

        private void printRoute()
        {
            
            
            Length = 0;
            

            Place curPlace = CLOSE[CLOSE.Count() - 1];
            while(curPlace.Parent!=null)
            {
                grphx.DrawLine(pen2, curPlace.GetX(), curPlace.GetY(), curPlace.Parent.GetX(), curPlace.Parent.GetY());
                Length += curPlace.getW(curPlace.Parent);
                curPlace = curPlace.Parent;
               
            }
            
        }

        private void calculateH(Place StartPlace)
        {
            for (int i = 0; i < AllPlace.Count(); i++)
            {
                AllPlace[i].InitH(StartPlace);
            }
        }
        
        Place getMinF(List<Place> list)
        {
            Place result = list[0];
            for (int i = 1; i < list.Count(); i++)
            {
                if (list[i].GetF() < result.GetF())
                    result = list[i];
            }
            return result;
        }

        private bool SearchRoute(Place startPlace, Place endPlace)
        {
                        //init 2 list OPEN and CLOSE empty
            OPEN = new List<Place>();
            OPEN.Clear();
            CLOSE = new List<Place>();
            CLOSE.Clear();
            
            startPlace.SetG(0);

                //push start place into OPEN
            OPEN.Add(startPlace);
            lbClose.Text = ListToString(CLOSE);
            lbClose.Refresh();
            lbOpen.Text = ListToString(OPEN);
            lbOpen.Refresh();
            //process until OPEN is empty
            // or until the route is found
            while (OPEN.Count() > 0)
            {
                

                //get the place with min f
                var curIdx = this.getMinF(OPEN);
                //remove it from OPEN
                OPEN.Remove(curIdx);
                
                lbOpen.Text = ListToString(OPEN);
                lbOpen.Refresh();
                //Console.WriteLine("standing at : "+curIdx.Name);
                lbStanding.Text = curIdx.Name;
                lbStanding.Refresh();
                //check if the route is found
                if (curIdx == endPlace)
                {
                    CLOSE.Add(curIdx);
                    lbClose.Text = ListToString(CLOSE);
                    lbClose.Refresh();
                    lbStatus.Text = "Đã tìm thấy đích";
                    lbStatus.Refresh();
                    return true;
                }
                
                List<NearPlace> listnearplaces = new List<NearPlace>(curIdx.GetRoundPlace());
                //find all near places 
                for (var i = 0; i < listnearplaces.Count(); i++)
                {
                    //Console.WriteLine("looking at : " + listnearplaces[i].place.Name);
                    
                    lbLooking.Text = listnearplaces[i].place.Name;
                    lbLooking.Refresh();
                    System.Threading.Thread.Sleep(int.Parse(nmTimewait.Value.ToString()));
                    // calculate d(mi) = G(current place) + W(current place , near place[i])
                    int dmi = curIdx.GetG() + curIdx.getW(i);
                    //it exsisted in OPEN
                    if (OPEN.Contains(listnearplaces[i].place))
                    {
                        // if g(current place) < d(Mi) => continue
                        if (listnearplaces[i].place.GetG() < dmi)
                        {
                            lbStatus.Text = "Nằm trong OPEN ,có g bé hơn dmi nên bỏ qua";
                            lbStatus.Refresh();
                            System.Threading.Thread.Sleep(int.Parse(nmTimewait.Value.ToString()));
                            continue;
                        }
                    }
                    //it exsisted in CLOSE
                    else if (CLOSE.Contains(listnearplaces[i].place))
                    {
                        // if g(Mi) < d(Mi) => continue
                        if (listnearplaces[i].place.GetG() < dmi)
                        {
                            lbStatus.Text = "Nằm trong CLOSE ,có g bé hơn dmi nên bỏ qua";
                            lbStatus.Refresh();
                            System.Threading.Thread.Sleep(int.Parse(nmTimewait.Value.ToString()));
                            continue;
                        }
                        //move near place[i] to OPEN
                        OPEN.Add(listnearplaces[i].place);
                        CLOSE.Remove(listnearplaces[i].place);
                        lbClose.Text = ListToString(CLOSE);
                        lbClose.Refresh();
                        lbOpen.Text = ListToString(OPEN);
                        lbOpen.Refresh();
                        lbStatus.Text = "Nằm trong CLOSE ,có g lớn hơn dmi nên chuyển vào OPEN";
                        lbStatus.Refresh();
                    }
                    else
                    {
                        OPEN.Add(listnearplaces[i].place);
                        lbStatus.Text = "Không nằm trong CLOSE và OPEN nên thêm vào OPEN";
                        lbStatus.Refresh();
                        lbOpen.Text = ListToString(OPEN);
                        lbOpen.Refresh();
                    }
                    //update g(Mi) = d(Mi)
                    listnearplaces[i].place.SetG(dmi);
                    lbOpen.Refresh();
                    lbClose.Refresh();
                    listnearplaces[i].place.Parent = curIdx;
                    if(listnearplaces[i].place.Parent != null)
                    grphx.DrawLine(pen, listnearplaces[i].place.GetX(), listnearplaces[i].place.GetY(), listnearplaces[i].place.Parent.GetX(), listnearplaces[i].place.Parent.GetY());
                    
                    System.Threading.Thread.Sleep(int.Parse(nmTimewait.Value.ToString()));


                }

                //move curNode to CLOSE
                CLOSE.Add(curIdx);
                lbClose.Text = ListToString(CLOSE);
                lbClose.Refresh();
                
            }
            return false;
        }
        string ListToString(List<Place> list)
        {
            StringBuilder result = new StringBuilder();
            if (list.Count == 0)
                return "EMPTY";
            result.Append(list[0].Name +"("+list[0].GetF()+")");
            for(int i = 1; i < list.Count();i++)
            {
                result.Append("," + list[i].Name + "(" + list[i].GetF() + ")");
            }
            return result.ToString();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {

        }

        private void lbOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
