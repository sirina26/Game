using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;


namespace  PlayWithMac.Model
{
    public class Questions
    {
        public const uint MAX_NUMBER_OF_ITEMS = 3;
        private const string V = @".\game_educatif\police\9SYSTEMA.TTF";
        private int selectedItemIndex;
        private Font font = new Font(V);
        private Text[] _response = new Text[MAX_NUMBER_OF_ITEMS];
        static Texture _background;
        static Sprite backgroundSprite;
       
        int score;
        int nbquestion = 0;
        int _nbfois = 0;
        private string[] _rep = new string[] { "14 Juillet", "Allemagne","Louis XIV" };

        Text _question;

        private string[,] _resultat =
        {
            {"14 Juillet", "30 Mai", "14 Janvier" },
            {"France", "Allemagne", "Corée du Sud" },
            {"Napoléon", "Louis XIV", "Philippe August" }
           
        };



        public Text Qua(int quest)
        {
            Text[] _questions = new Text[3];
            Text _return = new Text();
            _questions[0] = new Text()
            {
                Font = font,
                DisplayedString = "Quelle est la date de la fête nationale française?",
            };
            _questions[1] = new Text()
            {
                Font = font,
                DisplayedString = "Quel equipe a gagné la coupe du monde en 2014 ?",
            };
            _questions[2] = new Text()
            {
                Font = font,
                DisplayedString = "Quel roi est surnommé le 'Roi-Soleil'?",
            };
            

            for (int i = 0; i < _questions.Length; i++)
            {
                if (i == quest)
                {
                    _return = _questions[i];

                }
                else
                {
                    continue;
                }
            }

            return _return;
        }

        public int Score => score;

        public Questions(uint width, uint heigh, int ind)
        {
            score = 0;
          
            _response = DisplayQuestion(ind, width, heigh);

            if (ind == 0)
            {
                _background = new Texture(@".\game_educatif\FE_educatif1.jpg");
                _question = Qua(ind);
            }else if(ind == 2)
            {
                _background = new Texture(@".\game_educatif\roisoleil.jpg");
                _question = Qua(ind);
            }else if(ind == 1)
            {
                _background = new Texture(@".\game_educatif\coupes.jpg");
                _question = Qua(ind);
            }
                

            backgroundSprite = new Sprite(_background);
        }

        public void Draw(RenderWindow window)
        {
            backgroundSprite.Draw(window, RenderStates.Default);
            for (int i = 0; i < MAX_NUMBER_OF_ITEMS; i++)
            {
                window.Draw(_response[i]);
            }
            //Text quas = Qua(ques);
            window.Draw(_question);
        }

        public void MoveUp()
        {
            if (selectedItemIndex - 1 >= 0)
            {
                _response[selectedItemIndex].Color = Color.White;
                selectedItemIndex--;
                _response[selectedItemIndex].Color = Color.Red;
            }
        }

        public void MoveDown()
        {
            if (selectedItemIndex + 1 < MAX_NUMBER_OF_ITEMS)
            {
                _response[selectedItemIndex].Color = Color.White;
                selectedItemIndex++;
                _response[selectedItemIndex].Color = Color.Red;
            }
        }

        public void Move(Keyboard.Key key)
        {
            if (key == Keyboard.Key.Up)
            {
                MoveUp();
                System.Threading.Thread.Sleep(200);
            }
            else if (key == Keyboard.Key.Down)
            {
                MoveDown();
                System.Threading.Thread.Sleep(200);
            }
        }

        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set { selectedItemIndex = value; }
        }

        public void Run(int ind)
        {
            RenderWindow win = new RenderWindow(new VideoMode(1200, 700), "PlayWithMac");

            while (win.IsOpen)
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    this.Move(Keyboard.Key.Up);
                   
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    this.Move(Keyboard.Key.Down);
                    
                }

                else if (Keyboard.IsKeyPressed(Keyboard.Key.B))
                {
                   
                    if (VerifResponse(_response[selectedItemIndex].DisplayedString) == true)
                    {
                            win.Close();
                            if(ind == 2)
                            {
                                LevelView level = new LevelView(1200, 700, 2);
                                level.Run();
                            }
                            else
                            {
                                Questions question = new Questions(1200, 700, ind+1);
                                question.Run(ind+1);
                                score++;
                            }
                            
                            break;
                    }else{
                        win.Close();
                        nbquestion = 0;
                       this.Run(ind);
                       _nbfois++;

                        if(_nbfois >= 3)
                        {
                            win.Close();
                        }
                        else
                        {
                            continue;
                        }
                    }
                    
                   

                        
                   
                }

                this.Draw(win);
                win.Display();
            }
        }

        public bool VerifResponse(string rep)
        {
            bool result = false;

            for(int i= 0; i< _rep.Length; i++)
            {
                if(_rep[i] == rep)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public Text[] DisplayQuestion(int i, uint width, uint heigh)
        {
            Text[] _rep = new Text[3];

            for(int j = 0; j<_resultat.Length; j++)
            {
                if(i == j)
                {
                    _rep[0] = new Text
                    {
                        Font = font,
                        Color = Color.Red,
                        DisplayedString = _resultat[i,0],
                        Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 1))
                    };

                    _rep[1] = new Text
                    {
                        Font = font,
                        Color = Color.White,
                        DisplayedString = _resultat[i, 1],
                        Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 2))
                    };

                    _rep[2] = new Text
                    {
                        Font = font,
                        Color = Color.White,
                        DisplayedString = _resultat[i, 2],
                        Position = new SFML.System.Vector2f(width / 2, (heigh / (MAX_NUMBER_OF_ITEMS + 1) * 3))
                    };

                }
            }

            return _rep;

        }
    }
}

