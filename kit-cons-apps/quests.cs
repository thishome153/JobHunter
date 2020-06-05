using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    namespace xb9d8bb5e6df032aa
    {
        using System;

#region Decoder - decompiled IL code:
        public class x1110bdd110cdcea4
        {
            public x1110bdd110cdcea4()
                : base()
            {
            }

                public static string _xaacba899487bce8c(string x5e99b576d2530d13, int x2710752c36f2d14b)
                {
                    ushort usht =(ushort)x2710752c36f2d14b; // typecast "утратит старшие разряды" для ключа (hash`a)
                    char[] arrch = new char[x5e99b576d2530d13.Length / 4];
                    int i =0;
                    ushort usht1;
                
                while (i < (x5e99b576d2530d13.Length / 4 -1))
                    {
                       usht1 = (ushort)((((x5e99b576d2530d13[ 4 * i]      - 'a')+ 
                                         ((x5e99b576d2530d13[(4 * i) + 1] - 'a') << '\u0004')) + 
                                         ((x5e99b576d2530d13[(4 * i) + 2] - 'a') << '\u0008')) + 
                                         ((x5e99b576d2530d13[(4 * i) + 3] - 'a') << '\u000c'));

                         usht1 -= usht; // вычитаем hash (key)
                         arrch[i] = (char)(usht1);  // вариант: Convert.ToChar(usht1);       //Ошибка	1	Не удается неявно преобразовать тип "short" в "char". Существует явное преобразование (возможно, пропущено приведение типов)
                        usht += 1789; // 0x6FD меняем hash
                              i++;  
                    }
                //arrch[x5e99b576d2530d13.Length / 4-1] = '\0'; // add null terminator ???
                return new string(arrch);
                } 
        }
        public static class TestValues
        {
            public static int Key = 7400187;                      //0x0070eafb = 7400187 
                                              // "обрезанный" до 16bit :0xeafb =   60155
            public static string encodedString =
                                          "eflohgcpkgjpegaapahapboajbfbdbmbhedcbekcgfbdkphdlepdgegekdnepcefhdlfiobggcjgadahd" +
                                          "chhmnnhncfiobmiibdjanjjcoakkmhklapkfaglkbnloldmcalmkacngpinfppnepgomknojpeplolpf" +
                                          "pcajojamoabonhbhjobmnfccnmcboddlikdnmbedniegmpeemgfamnfhiegghlghkchiljhglainlhih" +
                                          "goififjdkmjnkdkalkkmkblffilehplojgmeknmjeennjlnmicomijojiapkdhpihopaifaiimapgdbe" +
                                          "ikblhbcfcicegpceggdmbndmgeeoflecgcfhgjflfagkahgicogcdfhfcmhopcipekiaebjkdijeepje" +
                                          "dgkmomkaeelpcllpccmmcjmnnpmmbhnmboneneocbmoomcppakpnababbiadapaibgbmlmbiaecmpkcd" +
                                          "lbddmidnkpdnpgemonehoefaplfmocgpnjgloahfjhhdnohdofimimimndjknkjembkcnikbnpkpmglh" +
                                          "mnlciemlflmifcnekjnhlaoklhocgoomkfpblmpmkdakkkadfbbakibckpbmjgckincmiedcildbjcea" +
                                          "ijeidafbihflhofchfgbhmghhdhjhkhigbidhiinbpioggjggnjebekfflkhfclofjljeamhehmoeome" +
                                          "efnmplnnedoodkoidbpaphpbeppmdgaadnafcebnclbonbcacjcgcadmbhdlbodnbfebbmejmcfhakfb" +
                                          "bbgeaignlognpfhganhcaeifalihpbjjpijnppjkogkcknkepelpollcocmeojmknanajhnbooncnfom" +
                                          "mmoeidpemkpnmbajmiammpahmgbbmnbllecpllcjgcdpkjdblaeaghegloejkffmkmfgkdgbfkgcjbha" +
                                          "jihojphkigioinioiejmiljgicklhjkbialeihlncolkhfmjhmmdhdnlgkndgboofiomgpoiggpacnpp" +
                                          "aeabelamfcblejbdaacefhcfeocpdfdhpldaedekdkemdbfgdifldpffofgecngecehiclhiccincjid" +
                                          "npiechjmbojkmekoamkjadlfbklolamhaimbapmipfnhpmnnpdoppkooobpgkipdpppcpgagonanneba" +
                                          "olbcoccinjcoiadmmhdgnodjmfecimeomdfomkfnlbglligfmpgjlghllnhbleihglinkcjpkjjekakk" +
                                          "khkkkokckfldjmldkdmfjkmijbnejinbfpnaegoggnoaiephdlpnicaaijadiablchbphobggfcahmcd" +
                                          "hddmbkdkfbeegiedbpeffgffgnfofegmelgcfchefjhheaikehigeoifpejidmjoddkodkkjoallcilj" +
                                          "dplbcgmjcnmpceniblniccokbjonbapjbhpennpfmeacbmaladbbakbkpacjaicipocalfdapmdjpdef" +
                                          "pkeipbfcoifbopfpoggijngkoehfolhpicibojimnajpmhjbnojhmfknhmkomdlplkljlbmbhimklpme" +
                                          "lgnglnnaleofllopfcpojjpojaackhackoahkfblfmb";
            public static int length = encodedString.Length;
        }

#endregion

        //Тестовая таблица
        public  class TestLogicData
        {
            public int[,] table = new int[20, 20] {  
                                    {8,  2,22,97,38,15,0 ,40, 0,75, 4, 5, 7,78,52,12,50,77,91, 8},
                                    {49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,04,56,62,00},
                                    {81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,03,49,13,36,65},
                                    {52,70,95,23,04,60,11,42,69,24,68,56,01,32,56,71,37,02,36,91},
                                    {22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80},
                                    {24,47,32,60,99,03,45,02,44,75,33,53,78,36,84,20,35,17,12,50},
                                    {32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70},
                                    {67,26,20,68,02,62,12,20,95,63,94,39,63,08,40,91,66,49,94,21},
                                    {24,55,58,05,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72},
                                    {21,36,23,09,75,00,76,44,20,45,35,14,00,61,33,97,34,31,33,95},
                                    {78,17,53,28,22,75,31,67,15,94,03,80,04,62,16,14,09,53,56,92},
                                    {16,39,05,42,96,35,31,47,55,58,88,24,00,17,54,24,36,29,85,57},
                                    {86,56,00,48,35,71,89,07,05,44,44,37,44,60,21,58,51,54,17,58},
                                    {19,80,81,68,05,94,47,69,28,73,92,13,86,52,17,77,04,89,55,40},
                                    {04,52,08,83,97,35,99,16,07,97,57,32,16,26,26,79,33,27,98,66},
                                    {88,36,68,87,57,62,20,72,03,46,33,67,46,55,12,32,63,93,53,69},
                                    {04,42,16,73,38,25,39,11,24,94,72,18,08,46,29,32,40,62,76,36},
                                    {20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,04,36,16},
                                    {20,73,35,29,78,31,90,01,74,31,49,71,48,86,81,16,23,57,05,54},
                                    {01,70,54,71,83,51,54,69,16,92,33,48,61,43,52,01,89,19,67,48}

            };
        }

        // член матрицы - координаты и значение
        public class Member : Object
        {
            public int Value; // значение 
            public int i; //строка
            public int j; //столбец
        }

        public class CursoR : Member
        {
            public List<CursoR> Neighbors;
            public CursoR()
            {
                Value = 0;
                Neighbors = new List<CursoR>(3);
            }

             ~CursoR()
            {
               // Neighbors = null;
            }

            public int GetMult ()
            {
                if (Neighbors.Count == 3)
                    return this.Value* Neighbors[0].Value
                                     * Neighbors[1].Value
                                     * Neighbors[2].Value;
                else return 0;
            }
        }
        
        public class Matrix
        {
            public CursoR[,] items;
            public int maxi; public int maxj;
            public Matrix(int ix, int ij)
            {
                items = new CursoR[ix, ij];    //сама матрица
                maxi = ix - 1; maxj = ij - 1;  // для указания элементов. 
            }
            public bool Exist(int ii, int jj)
            {
                if ((ii >= 0) && (ii <= maxi) && (jj >= 0) && (jj <= maxj)) return true; else return false;
            }
            
        /// <summary>
            /// Максимальное произведение в матрице
            /// </summary>
            /// <returns></returns>
            private CursoR getMAXMultCursor()
            {
                int maxInt = 0;
                CursoR maxMulti = new CursoR();
                foreach (CursoR cr in items)
                    if (maxInt < cr.GetMult())
                    {
                        maxInt = cr.GetMult();
                        maxMulti = cr;
                    }
                return maxMulti;
            }

            private bool AlreadyPresent(List<CursoR> Already,  int check_i, int check_j) {
                  foreach (CursoR c in Already)
                  {
                      if ((c.i == check_i) &&(c.j == check_j)) return true;
                  }
                  return false;                        
            }

            //Поиск соседей
            private CursoR FindCursorNearMaxValue(CursoR Parent, CursoR cs)
            {
                CursoR maxMember = new CursoR(); int cur_J; int cur_i;
                for (int i = -1 ; i <=  1; i++)  // 0 - от текущей строки
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        cur_J = cs.j + j;
                        cur_i = cs.i + i;        
                        if (Exist(cur_i, cur_J))             // не выходим за границы
                            if (!AlreadyPresent(Parent.Neighbors, cur_i, cur_J))
                            if ((cur_i != Parent.i) || (cur_J != Parent.j))  //и не родителя
                            if ((cur_i != cs.i) || (cur_J != cs.j))  //и не берем себя
                

                                if (maxMember.Value < items[cur_i, cur_J].Value) // ищем маскимального 
                                {
                                    maxMember = items[cur_i, cur_J];
                                }
                    }
                }
                return maxMember;//result;
            }

        //Заполнение соседей - поиск 
        public CursoR FindMult_1()
        {
            //главный цикл - полного сканирования матрицы
            for (int i = 0; i <= maxi; i++)
                for (int j = 0; j <= maxj; j++)
                {

                    CursoR memb1 = new CursoR();
                    CursoR memb2;// = new CursoR();
                    CursoR memb3;// = new CursoR();
                    memb1 = FindCursorNearMaxValue(items[i, j], items[i, j]);
                    items[i, j].Neighbors.Add(memb1);                    //First максимальный сосед
                    memb2 = FindCursorNearMaxValue(items[i, j], memb1); // второй максимальный сосед
                    items[i, j].Neighbors.Add(memb2);

                    memb3 = FindCursorNearMaxValue(items[i, j], memb2); // третий максимальный сосед
                    items[i, j].Neighbors.Add(memb3);
                }
            return getMAXMultCursor();
        }

        //Конвертацио для Binding WPF DatagridView
            public List<int[]> AsBindingList()
            {
                List<int []> res = new List<int[]>();
                for (int i = 0; i <= maxi; i++)
                {
                    int[] strokeee = new int[20];
                    //CursoR[] strokeee = new CursoR[20];

                    for (int j = 0; j <= maxj; j++)
                    {
                        strokeee[j] = this.items[i, j].Value;
                    }
                    res.Add(strokeee);
                }
                return res;
            }

            //Конвертацио для Binding WPF DatagridView
            public List<CursoR> AsBindingList_()
            {
                List<CursoR> res = new List<CursoR>();
                for (int i = 0; i <= maxi; i++)
                {
                    for (int j = 0; j <= maxj; j++)
                    {
                     res.Add(items[i,j]);
                    }

                }
                return res;
            }
        }

        public class TestLogic
        {
            public Matrix Matrix = new Matrix(20,20);
            public void SetMatrix(Matrix matrix, int [,] data)
            {
                for (int i = 0; i <= matrix.maxi; i++)
                {
                    for (int j = 0; j <= matrix.maxj; j++)
                    {
                        matrix.items[i, j] = new CursoR();
                        matrix.items[i, j].i = i; matrix.items[i, j].j = j; matrix.items[i, j].Value = data[i, j];
                    }
                }
            }

        public CursoR FindMult(int[,] data)
            {
                SetMatrix(this.Matrix, data);
                return this.Matrix.FindMult_1();
            }



            

            
        }

#region Задание 2 (Знание основ языка C# и .NetFramework)
        public class SharpeyKnowledge
        {
                
            public void Init_Mentors()
            {
                string a = "";
                for (int i = 0; i < 1000000; i++)
                {
                    a += "a";
                }
            }
            public void Self_Init()
            {
                string a = new string('a', 1000000); // Слава System.String, да продлит C# дни его
            }
            public void Method1(List<int> listDigits)
            {
                listDigits.Add(55);
            }
            public void Method2( int digit)
            {
                digit += 55;
            }


#endregion

#region Задание  4. Избавьтесь от рекурсии, при этом не потерять порядок имен в someData

            public static List<string> Main_with_dict()
            {
                Dictionary<string, List<string>> someData = new Dictionary<string, List<string>>();

                someData["Петр Иванович"] = new List<string>();    // ПетрИванович - это шутка??
                someData["Петр Иванович"].Add("Анна Ивановна");
                someData["Петр Иванович"].Add("Максим Иванович");

                someData["Максим Иванович"] = new List<string>();
                someData["Максим Иванович"].Add("Коля");
                someData["Максим Иванович"].Add("Миша");
                someData["Максим Иванович"].Add("Николай Максимович");

                someData["Анна Ивановна"] = new List<string>();
                someData["Анна Ивановна"].Add("Артем");

                someData["Николай Максимович"] = new List<string>();
                someData["Николай Максимович"].Add("Катя");
                someData["Николай Максимович"].Add("Маша");

                someData["Анна Ивановна"].Add("Саша");

                List<string> lastChilds = new List<string>();

                  RecursFillLastChilds("Петр Иванович", someData, lastChilds);
                       lastChilds.Add("\n No recurse:"); 
                        FillLastChilds("Петр Иванович", someData, lastChilds);
                foreach (var child in lastChilds)
                {
                    Console.WriteLine(child);
                }

                return lastChilds;
            }

            private static void FillLastChilds(string parentName, Dictionary<string, List<string>> someData, List<string> lastChilds)
            {
                foreach (string child in someData[parentName])
                {
                    foreach (string ch_item in someData[child])
                        if (!someData.ContainsKey(ch_item))
                        {
                            lastChilds.Add(ch_item);
                        }
                        else
                        {
                            lastChilds.AddRange(someData[ch_item]);
                        }
                }
            }


     private static void RecursFillLastChilds(string parentName, Dictionary<string, List<string>> someData, List<string> lastChilds)
            {
                if (!someData.ContainsKey(parentName))  // 
                {
                    lastChilds.Add(parentName);
                    return;
                }

                foreach (string child in someData[parentName])
                {
                    RecursFillLastChilds(child, someData, lastChilds);
                }
            }
        }



#endregion


    }

